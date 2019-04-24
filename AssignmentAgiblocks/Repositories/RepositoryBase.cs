using AssignmentAgiblocks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected CustomerContext CustomerContext { get; set; }

        public RepositoryBase(CustomerContext customerContext)
        {
            this.CustomerContext = customerContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.CustomerContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.CustomerContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.CustomerContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.CustomerContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.CustomerContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.CustomerContext.SaveChanges();
        }
    }
}
