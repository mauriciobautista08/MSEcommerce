using Identity.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Service.EventHandler
{
    public class UserCreateEventHandler : IRequestHandler<UserCreateCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;

        public UserCreateEventHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(UserCreateCommand command, CancellationToken cancellationToken)
        {
            var entry = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                UserName = command.Email
            };

            return await _userManager.CreateAsync(entry, command.Password);
        }

    }
}
