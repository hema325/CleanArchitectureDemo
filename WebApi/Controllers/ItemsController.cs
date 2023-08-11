using Application.Items.Commands.CreateItem;
using Application.Items.Commands.DeleteItem;
using Application.Items.Commands.UpdateItem;
using Application.Items.Queries.GetItemById;
using Application.Items.Queries.GetItemsInCsvFile;
using Application.Items.Queries.GetItemsWithPagination;
using Domain.Enums;
using Infrastructure.Authentication.Filters;
using Infrastructure.Authentication.Permissions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[Authorize]
    [HaveRoles(Roles.Admin)]
    [HasPermission(Permissions.ReadWrite)]
    [ApiKey]
    [Route("Items")]
    public class ItemsController : BaseApiController
    {
        private readonly ISender _mediator;

        public ItemsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Paginate")]
        //[EnableCors(CorsPolicyNames.CorsPolicy)]
        //[DisableCors]
        public async Task<IActionResult> Paginate([FromQuery] GetItemsWithPaginationQuery request)
        {
            var items = await _mediator.Send(request);

            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var items = await _mediator.Send(new GetItemByIdQuery { Id = id });

            return Ok(items);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm]CreateItemCommand request)
        {
            var id = await _mediator.Send(request);

            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,UpdateItemCommand request)
        {
            if (id != request.Id)
                return BadRequest();

            await _mediator.Send(request);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteItemCommand { Id = id });

            return NoContent();
        }

        [HttpGet("Download")]
        public async Task<IActionResult> Download()
        {
            var response = await _mediator.Send(new GetItemsInCsvFileQuery());

            return File(response.Content, response.ContentType, response.FileName);
        }

    }
}
