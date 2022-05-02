using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess.infra
{
    /// <summary>
    /// 
    /// </summary>
    public class DBFactory : IDbFactory
    {
        hmsEntities entitiesContext;

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (entitiesContext != null)
            {
                entitiesContext.Dispose();
            }
        }

        //public static hmsEntities Instance
        //{
        //    get
        //    {
        //        if (entitiesContext == null)
        //        {
        //            lock (syncRoot)
        //            {
        //                if (entitiesContext == null)
        //                {
        //                    entitiesContext = new hmsEntities();
        //                }
        //            }
        //        }
        //        return entitiesContext;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public hmsEntities Init()
        {
            return entitiesContext ?? (entitiesContext = new hmsEntities());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDbFactory : IDisposable
    {
        hmsEntities Init();
    }
}