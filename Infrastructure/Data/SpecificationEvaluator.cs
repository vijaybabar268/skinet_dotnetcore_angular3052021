using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    { 
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> Spec)
        {
            var query = inputQuery;

            if(Spec.Criteria != null)
            {
                query = query.Where(Spec.Criteria);
            }

            if(Spec.OrderBy != null)
            {
                query = query.OrderBy(Spec.OrderBy);
            }

            if(Spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(Spec.OrderByDescending);
            }

            if(Spec.IsPagingEnable)
            {
                query = query.Skip(Spec.Skip).Take(Spec.Take);
            }

            query = Spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}