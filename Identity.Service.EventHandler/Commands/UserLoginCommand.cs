using Identity.Service.EventHandler.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Identity.Service.EventHandler.Commands
{
    public class UserLoginCommand : IRequest<IdentityAccess>
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
