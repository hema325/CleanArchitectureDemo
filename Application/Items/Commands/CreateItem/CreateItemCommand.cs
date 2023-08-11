using Microsoft.AspNetCore.Http;

namespace Application.Items.Commands.CreateItem
{
    public sealed record CreateItemCommand(string Name,IFormFile Image): IRequest<int>;
    
}
