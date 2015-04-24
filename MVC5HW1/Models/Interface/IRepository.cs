using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC5HW1.Models.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Create(TEntity instance);

        void Update(TEntity instance);

        void Delete(TEntity instance);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        void SaveChanges();

        IQueryable<TEntity> GetStoreProcedureWithoutParameters(string storeProcedureName);
    }
}
