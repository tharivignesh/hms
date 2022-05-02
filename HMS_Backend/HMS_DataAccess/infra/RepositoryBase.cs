using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess.infra
{
    public abstract class RepositoryBase<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        private hmsEntities dataContext;

        /// <summary>
        /// 
        /// </summary>
        private readonly IDbSet<T> dbSet;

        /// <summary>
        /// 
        /// </summary>
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }


        /// <summary>
        /// 
        /// </summary>
        protected hmsEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbFactory"></param>
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }


        #region Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Add(T entity)
        {
            this.DbContext.Entry(entity).State = EntityState.Added;
            dbSet.Add(entity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        #endregion
    }
}
