using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.CreateEmailConfirmationToken
{
    public class CreateEmailConfirmationTokenCommandHandler : IRequestHandler<CreateEmailConfirmationTokenCommand>
    {
        private readonly IEmailSender _emailSender;
        private readonly IAuthentication _authentication;
        private readonly IUser _user;
        private readonly ILinkGenerator _linkGenerator;

        public CreateEmailConfirmationTokenCommandHandler(IEmailSender emailSender, IAuthentication authentication, IUser user, ILinkGenerator linkGenerator)
        {
            _emailSender = emailSender;
            _authentication = authentication;
            _user = user;
            _linkGenerator = linkGenerator;
        }

        public async Task<Unit> Handle(CreateEmailConfirmationTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _user.GetByEmailAsync(request.Email);
            if (user == null)
                throw new NotFoundException(nameof(User), new { request.Email });

            var token = await _authentication.GenerateEmailConfirmationTokenAsync(request.Email);
            var link = _linkGenerator.Generate("/api/identity/confirmEmail", new { userId = user.Id,token = token });

            await SendEmailVerification(request.Email, link);

            return Unit.Value;
        }

        private async Task SendEmailVerification(string to, string link)
        {
            var message = new MailMessage
            {
                Subject = "Email Verification",
                Body = $"Please <a href=\"{link}\">Click Here</a> To Verify Your Email",
                IsBodyHtml = true,
            };

            message.To.Add(new MailAddress(to));

            await _emailSender.SendAsync(message);
        }
    }
}
