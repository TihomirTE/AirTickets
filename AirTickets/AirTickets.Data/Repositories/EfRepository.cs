using AirTickets.Data.Contracts;
using AirTickets.Data.Model.Contracts;
using Bytes2you.Validation;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace AirTickets.Data.Repositories
{
    public class EfRepository<T> : IEfRepository<T>
        where T : class, IDeletable
    {
        private readonly SqlDbContext context;
        private readonly IDbSet<T> dbSet;

        public EfRepository(SqlDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> All
        {
            get
            {
                return this.context.Set<T>();
            }
        }

        public IQueryable<T> AllAndDeleted
        {
            get
            {
                return this.context.Set<T>();
            }
        }

        public IQueryable<T> AllWithInclude<TProperty>(Expression<Func<T, TProperty>> includeExpression)
        {
            return this.All.Include(includeExpression);
        }

        public T GetById(Guid id)
        {
            return this.dbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.context.Set<T>().Add(entity);
            }
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;

            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        

        public void Update(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
