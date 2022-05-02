using HMS_DataAccess;
using HMS_DataAccess.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_Service
{

    /// <summary>
    /// 
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        bool AddBooking(tblBooking booking);

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<tblBooking> GetBookings();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<tblBooking> GetUserBookings(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        IEnumerable<tblBooking> GetBookings(DateTime startDate, DateTime endDate);
    }


    /// <summary>
    /// 
    /// </summary>
    public class BookingService : IBookingService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IBookingRespository bookingRepo;


        public BookingService(IBookingRespository bookingRespository)
        {
            this.bookingRepo = bookingRespository;
        }

        public bool AddBooking(tblBooking booking)
        {
            this.bookingRepo.Add(booking);
            return true;
        }

        public IEnumerable<tblBooking> GetBookings()
        {
            return this.bookingRepo.GetAll();
        }

        public IEnumerable<tblBooking> GetBookings(DateTime startDate, DateTime endDate)
        {
            return this.bookingRepo.GetMany(x => (x.StartDate.Date >= startDate.Date && x.EndDate.Date <= endDate.Date));
        }

        public IEnumerable<tblBooking> GetUserBookings(int userId)
        {
            return this.bookingRepo.GetMany(x => x.BookedBy == userId);
        }
    }
}
