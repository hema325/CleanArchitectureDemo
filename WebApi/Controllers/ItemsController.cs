using Application.Common.Interfaces.FilesStorage;
using Application.Items.Commands.CreateItem;
using Application.Items.Commands.DeleteItem;
using Application.Items.Commands.UpdateItem;
using Application.Items.Queries.GetItemImage;
using Application.Items.Queries.GetItemsInCsvFile;
using Application.Items.Queries.GetItemsWithPagination;
using Domain.Enums;
using Infrastructure.Authentication.Filters;
using Infrastructure.Authentication.Permissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace WebApi.Controllers
{
    //[Authorize]
    //[HaveRoles(Roles.Admin)]
    //[HasPermission(Permissions.ReadWrite)]
    //[ApiKey]
    public class ItemsController : BaseApiController
    {
        private readonly ISender _mediator;

        public ItemsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] GetItemsWithPaginationQuery request)
        {
            Console.WriteLine(new { request.PageNumber, request.PageSize }.ToString());
            var items = await _mediator.Send(request);

            if (items == null)
                return NotFound();

            return Ok(items);
        }

        [HttpPost("[action]")]
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

        [HttpGet("[action]")]
        public async Task<IActionResult> Download()
        {
            var response = await _mediator.Send(new GetItemsInCsvFileQuery());

            return File(response.Content, response.ContentType, response.FileName);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Image([FromQuery]GetItemImageQuery query)
        {
             var response = await _mediator.Send(query);

            return PhysicalFile(response.PhysicalPath, response.ContentType, response.FileName);
        }

    }
}
