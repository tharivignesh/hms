using HMS_DataAccess;
using HMS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS_Backend.CustomAuth
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelAuth
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Boolean Login(string token)
        {
            using (hmsEntities entities = new hmsEntities())
            {
                var user = entities.tblUsers.FirstOrDefault(x => x.LoginHash.Equals(token));

                if (user != null)
                    return true;
                else
                    return false;
            }
        }
    }
}