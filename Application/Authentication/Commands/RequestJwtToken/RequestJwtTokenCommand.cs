using Application.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.RequestJwtToken
{
    public class RequestJwtTokenCommand: IRequest<AuthResult>
    {
        public string RefreshToken { get; set; }
    }
}
