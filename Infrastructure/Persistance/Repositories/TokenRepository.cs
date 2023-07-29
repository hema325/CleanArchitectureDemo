


using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistance.Context;

namespace Infrastructure.Persistance.Repositories
{
    internal class TokenRepository : BaseRepository<Token>, ITokenRepository
    {
        public TokenRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
