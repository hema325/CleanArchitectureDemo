using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.ConfirmEmail
{
    public class ConfirmEmailCommand: IRequest
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
