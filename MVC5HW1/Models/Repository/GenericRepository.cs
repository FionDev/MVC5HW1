using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC5HW1.Models.Interface;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq.Expressions;


namespace MVC5HW1.Models.Repository
{
    public class GenericRepository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        private readonly string _InstanceError = "Null Instance";
        private DbContext Context { get; set; }

        public GenericRepository()
            : this(new CustmerEntities())
        { 
        }

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context error");
            }
            this.Context = context;
        }

        public GenericRepository(ObjectContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context error");
            }
            this.Context = new DbContext(context, true);
        }


        public void Create(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(_InstanceError);
            }
            else 
            { 
                this.Context.Set<TEntity>().Add(instance);
                this.SaveChanges();
            }
        }

        public void Update(TEntity instance)
        {
            if(instance==null)
            {
                throw new ArgumentNullException(_InstanceError);
            }
            else
            {
                this.Context.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }
        }

        public void Delete(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(_InstanceError);
            }
            else
            {
                this.Context.Entry(instance).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.Context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetStoreProcedureWithoutParameters(string storeProcedureName)
        {
            IQueryable<TEntity> result = null;
            if (string.IsNullOrEmpty(storeProcedureName))
                return result;
            string exeSql = "exec " + storeProcedureName.Trim(); ;
            result = this.Context.Database.SqlQuery<TEntity>(exeSql).AsQueryable();
            return result;
        }


        public void SaveChanges() 
        {
            this.Context.SaveChanges();
        }


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool diposing)
        {
            if (diposing)
            {
                if (this.Context != null)
                {
                    this.Context.Dispose();
                    this.Context = null;
                }
            }
        }

    }
}