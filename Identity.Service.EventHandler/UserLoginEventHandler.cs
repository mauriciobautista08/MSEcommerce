﻿using Identity.Domain;
using Identity.Persistence.Database;
using Identity.Service.EventHandler.Commands;
using Identity.Service.EventHandler.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Service.EventHandler
{
    public class UserLoginEventHandler : IRequestHandler<UserLoginCommand, IdentityAccess>
    {
        private readonly SignInManager<User> _signinManager;
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;

        public UserLoginEventHandler(SignInManager<User> signInManager, ApplicationDBContext context, IConfiguration configuration)
        {
            _signinManager = signInManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task<IdentityAccess> Handle(UserLoginCommand command, CancellationToken cancellationToken)
        {
            var result = new IdentityAccess();

            var user = await _context.Users.SingleAsync(x => x.Email == command.Email);
            var response = await _signinManager.CheckPasswordSignInAsync(user, command.Password, false);

            if(response.Succeeded)
            {
                result.Succedded = true;
                await GenerateToken(user, result);
            }

            return result;
        }

        private async Task GenerateToken(User user, IdentityAccess identity)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var roles = await _context.Roles
                .Where(x => x.UserRoles.Any(y => y.UserId == user.Id))
                .ToListAsync();

            foreach (var role in roles)
            {
                claims.Add(
                new Claim(ClaimTypes.Role, role.Name));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            
            identity.AccessToken = tokenHandler.WriteToken(createdToken);

        }

    }
}
