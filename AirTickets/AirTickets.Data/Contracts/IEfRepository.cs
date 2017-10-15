using AirTickets.Data.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Contracts
{
    public interface IEfRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        IQueryable<T> AllWithInclude<TProperty>(Expression<Func<T, TProperty>> includeExpression);

        T GetById(Guid id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
