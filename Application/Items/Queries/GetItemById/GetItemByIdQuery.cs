namespace Application.Items.Queries.GetItemById
{
    public sealed record GetItemByIdQuery(int Id): IRequest<GetItemByIdDTO>;
}
