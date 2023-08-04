﻿using Application.Authentication.Models;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.SignIn
{
    public class AuthenticateCommand : IRequest<AuthResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}