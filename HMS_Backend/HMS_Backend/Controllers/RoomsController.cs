using System;
using System.Collections.Generic;
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
    public class RoomsController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IRoomsService roomsService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomsService"></param>
        public RoomsController(IRoomsService roomsService)
        {
            this.roomsService = roomsService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblRoom> Get()
        {
            return this.roomsService.GetRooms();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="room"></param>
        public void Post([FromBody]tblRoom room)
        {
            bool isSuccess = this.roomsService.AddRoom(room);
        }
    }
}
