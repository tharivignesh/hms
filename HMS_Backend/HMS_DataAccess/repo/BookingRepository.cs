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
    public interface IBookingRespository : IRepository<tblBooking>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class BookingRepository : RepositoryBase<tblBooking>, IBookingRespository
    {
        public BookingRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
