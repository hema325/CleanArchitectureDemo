using Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Extensions
{
    internal static class ModelBuilderExtensions
    {
        public static ModelBuilder AppendGlobalQueryFilter<TInterface>(this ModelBuilder builder,Expression<Func<TInterface,bool>> filter)
        {
            var entities = builder.Model.GetEntityTypes().Where(t => t.ClrType.IsAssignableTo(typeof(TInterface)));

            foreach(var entity in entities)
            {
                var param = Expression.Parameter(entity.ClrType);
                var body = ReplacingExpressionVisitor.Replace(filter.Parameters.Single(), param, filter.Body);
               
                if(entity.GetQueryFilter() is { } existingFilter)
                {
                    var existingbody = ReplacingExpressionVisitor.Replace(existingFilter.Parameters.Single(), param, existingFilter.Body);
                    body = Expression.AndAlso(existingbody, body);
                }
                
                entity.SetQueryFilter(Expression.Lambda(body, param));
            }

            return builder;
        }
    }
}