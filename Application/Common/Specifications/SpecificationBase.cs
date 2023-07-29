using Application.Common.Interfaces.Specifications;
using Domain.Common.Entities;
using System;
using System.Linq.Expressions;


namespace Application.Common.Specifications
{
    public abstract class SpecificationBase<TEntity>: ISpecification<TEntity> where TEntity : EntityBase
    {
        public SpecificationBase(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; }
        public List<Expression<Func<TEntity, object>>> Includes { get; } = new();
        public List<string> IncludeStrings { get; } = new();
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        public int? Skip { get; private set; }
        public int? Take { get;private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> include)
            => Includes.Add(include);

        protected void AddIncludeStrings(Expression<Func<TEntity, object>> include)
            => Includes.Add(include);

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderBy)
            => OrderBy = orderBy;

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescending)
           => OrderBy = orderByDescending;

        protected void AddSkip(int skip)
          => Skip = skip;

        protected void AddTake(int take)
          => Take = take;
    }
}
