using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Specifications;
using Domain.Common.Entities;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistance.Repositories
{
    internal class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);

        public async Task<IEnumerable<TEntity>> GetBySpecificationAsync(ISpecification<TEntity> specification)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            //criteria
            query = query.Where(specification.Criteria);

            //includes
            query = specification.Includes.Aggregate(query, (cur, include) => cur.Include(include));
            query = specification.IncludeStrings.Aggregate(query, (cur, include) => cur.Include(include));

            //ordering
            if (specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);
            else if (specification.OrderByDescending != null)
                query = query.OrderByDescending(specification.OrderByDescending);

            //pagination
            if (specification.Skip != null)
            {
                query = query.Skip(specification.Skip.Value);

                if (specification.Take != null)
                    query = query.Take(specification.Take.Value);
            }

            return await query.AsNoTracking().ToListAsync();
        }
    }
}
