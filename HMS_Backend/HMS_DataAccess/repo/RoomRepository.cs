using HMS_DataAccess.infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess.repo
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRoomRepository : IRepository<tblRoom>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class RoomRepository : RepositoryBase<tblRoom>, IRoomRepository
    {
        public RoomRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
