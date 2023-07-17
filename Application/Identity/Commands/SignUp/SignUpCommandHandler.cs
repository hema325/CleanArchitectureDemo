using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.SignUp
{
    internal class SignUpCommandHandler : IRequestHandler<SignUpCommand, string>
    {
        private readonly IUser _user;

        public SignUpCommandHandler(IUser user)
        {
            _user = user;
        }

        public async Task<string> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new UserModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var (id,result) = await _user.CreateUserAsync(user,request.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(",", result.Errors));

            await _user.AddToRoleAsync(id, request.Role);

            return id;
        }
    }
}
