using Application.Identity.Commands.ConfirmEmail;
using Application.Identity.Commands.CreateEmailConfirmationToken;
using Application.Identity.Commands.SignIn;
using Application.Identity.Commands.SignOut;
using Application.Identity.Commands.SignUp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class IdentityController: BaseApiController
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUp(SignUpCommand request)
        {
            var id = await _mediator.Send(request);
            return Ok(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignIn(SignInCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> SignOut(SignOutCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetEmailConfirmationToken(CreateEmailConfirmationTokenCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
