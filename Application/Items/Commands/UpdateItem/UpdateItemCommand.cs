namespace Application.Items.Commands.UpdateItem
{
    public sealed record UpdateItemCommand(int Id,string Name): IRequest;
}
