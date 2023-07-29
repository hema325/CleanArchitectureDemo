using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistance.Context;

namespace Infrastructure.Persistance.Repositories
{
    internal class ItemRepository: BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context): base(context)  { }

    }
}
