
using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistance.Context;

namespace Infrastructure.Persistance.Repositories
{
    internal class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IItemRepository Items { get; }
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public ITokenRepository Tokens { get; }
        public IUserRolesRepository UserRoles { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Items = new ItemRepository(_context);
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            Tokens = new TokenRepository(_context);
            UserRoles = new UserRolesRepository(_context);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);
    }
}
