using Application.Authentication.Common.Specifications;
using Application.Common.Email.Interfaces;
using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.Templates;
using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.Authentication.CreateEmailConfirmationToken
{
    internal class SendEmailConfirmationCommandHandler : IRequestHandler<SendEmailConfirmationCommand>
    {
        private readonly IEmailSender _emailSender;
        private readonly ITemplate _emailTemplate;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTime _dateTime;
        private readonly IRandomTokenGenerator _tokenProvider;
        private readonly ITemplateEnvironment _templateEnvironment;


        public SendEmailConfirmationCommandHandler(IEmailSender emailSender,
                                                   IUnitOfWork unitOfWork,
                                                   IDateTime dateTime,
                                                   IRandomTokenGenerator tokenProvider,
                                                   ITemplate emailTemplate,
                                                   ITemplateEnvironment templateEnvironment)
        {
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
            _dateTime = dateTime;
            _tokenProvider = tokenProvider;
            _emailTemplate = emailTemplate;
            _templateEnvironment = templateEnvironment;
        }

        public async Task<Unit> Handle(SendEmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Users.GetBySpecificationAsync(new GetUserByEmailSpecification(request.Email))).FirstOrDefault();
            
            if (user == null)
                throw new NotFoundException(nameof(User), new { request.Email });

            var token = new Token
            {
                Value = _tokenProvider.GeneratorToken(),
                Type = TokenTypes.EmailVerificationToken,
                CreatedOn = _dateTime.Now,
                ExpiresOn = _dateTime.Now.AddHours(1),
                UserId = user.Id
            };

            await _unitOfWork.Tokens.CreateAsync(token);
            await _unitOfWork.SaveChangesAsync();

            var link = UrlHelper.AddLinkToQuery(request.CallbackUrl, new { userId = user.Id, token = token.Value });

            await SendEmailVerification(request.Email, link);

            return Unit.Value;
        }

        private async Task SendEmailVerification(string to, string link)
        {
            var subject = "Email Verification";
            var body = await _emailTemplate.GetTemplateByNameAsync(_templateEnvironment.EmailConfirmationTemplate, new EmailConfirmation { Url = link });
            await _emailSender.SendAsync(to, subject, body);
        }
    }
}
