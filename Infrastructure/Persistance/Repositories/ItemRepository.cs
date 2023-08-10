using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    internal class ItemRepository: BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context): base(context)  { }

    }
}
