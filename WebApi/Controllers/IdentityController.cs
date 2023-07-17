using Application.Common.Interfaces;
using Application.Identity.Commands.ConfirmEmail;
using Application.Identity.Commands.CreateEmailConfirmationToken;
using Application.Identity.Commands.SignIn;
using Application.Identity.Commands.SignOut;
using Application.Identity.Commands.SignUp;
using Domain.Constanst;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace WebApi.Controllers
{
    [Authorize(Roles = $"{Roles.Admin}")]
    public class IdentityController: BaseApiController
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpCommand request)
        {
            var id = await _mediator.Send(request);
            return Ok(id);
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignOut(SignOutCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SendEmailConfirmationToken(CreateEmailConfirmationTokenCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommand request)
        { 
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
