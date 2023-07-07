using Application.Items.Commands.CreateItem;
using Application.Items.Commands.DeleteItem;
using Application.Items.Commands.UpdateItem;
using Application.Items.Queries.GetItemsWithPagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ItemsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(int pageNumber,int pageSize)
        {
            var request = new GetItemsWithPaginationQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var items = await _mediator.Send(request);

            if (items == null)
                return NotFound();

            return Ok(items);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CreateItemCommand request)
        {
            var id = await _mediator.Send(request);

            return Ok(id);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateItemCommand request)
        {
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteItemCommand
            {
                Id = id
            };

            try
            {
                await _mediator.Send(request);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

    }
}
