using Application.Authentication.Commands.RequestJwtToken;
using Application.Authentication.ConfirmEmail;
using Application.Authentication.CreateEmailConfirmationToken;
using Application.Authentication.SignIn;
using Application.Authentication.SignOut;
using Application.Authentication.SignUp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly ISender _mediator;

        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(RegisterCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Authenticate(AuthenticateCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> RevokeToken(RevokeTokenCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RequestJwtToken(RequestJwtTokenCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SendEmailConfirmationToken(SendEmailConfirmationCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]ConfirmEmailCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

    }
}
