using Application.Common.Interfaces.Specifications;
using Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity: EntityBase
    {
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetBySpecificationAsync(ISpecification<TEntity> specification);
    }
}
