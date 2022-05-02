using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMS_Backend.CustomAuth;
using HMS_DataAccess;
using HMS_Service;

namespace HMS_Backend.Controllers
{
    [HMSAuthentication]
    public class BookingsController : ApiController
    {
        private readonly IBookingService bookingService;
        private readonly IRoomsService roomsService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="booking"></param>
        public BookingsController(IBookingService booking, IRoomsService roomsService)
        {
            this.bookingService = booking;
            this.roomsService = roomsService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblBooking> Get()
        {
            return this.bookingService.GetBookings();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("mybookings")]
        public IEnumerable<tblBooking> GetMyBookings(int userId)
        {
            return this.bookingService.GetUserBookings(userId);           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("getavailability")]
        public IEnumerable<tblRoom> GetAvailability(DateTime startDate, DateTime endDate)
        {
            var rooms = this.roomsService.GetRooms();
            var bookedRoomIds =  this.bookingService.GetBookings(startDate, endDate).Select(y => y.RoomId).Distinct().ToList();
            var availableRooms = rooms.Where(x => !bookedRoomIds.Contains(x.Id)).ToList();
            return availableRooms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="booking"></param>
        public void Post([FromBody]tblBooking booking)
        {
            bool isSuccess = this.bookingService.AddBooking(booking);
        }
    }
}
