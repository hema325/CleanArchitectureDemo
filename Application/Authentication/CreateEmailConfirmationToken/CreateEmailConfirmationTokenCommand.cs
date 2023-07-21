using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.CreateEmailConfirmationToken
{
    public class CreateEmailConfirmationTokenCommand: IRequest
    {
        public string Email { get; set; }
    }
}
