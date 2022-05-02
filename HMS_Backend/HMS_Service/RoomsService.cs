using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS_DataAccess;
using HMS_DataAccess.repo;

namespace HMS_Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRoomsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        bool AddRoom(tblRoom booking);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<tblRoom> GetRooms();
    }


    public class RoomsService : IRoomsService
    {
        private readonly IRoomRepository roomsRepository;

        public RoomsService(IRoomRepository roomsRepository)
        {
            this.roomsRepository = roomsRepository;
        }

        public bool AddRoom(tblRoom booking)
        {
            this.roomsRepository.Add(booking);
            return true;
        }

        public IEnumerable<tblRoom> GetRooms()
        {
            return this.roomsRepository.GetAll();
        }
    }
}
