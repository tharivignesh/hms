using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using Newtonsoft.Json.Linq;
using HMS_Service;

namespace HMS_Backend.Controllers
{
    public class AccountController : ApiController
    {
        string sSourceData;
        byte[] tmpSource;
        byte[] tmpHash;

        private readonly IAccountService accountService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accService"></param>
        public AccountController(IAccountService accService)
        {
            this.accountService = accService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public tblUser Post([FromBody]JObject paramList)
        {
            sSourceData = paramList["userName"].ToString() + ":" + paramList["password"].ToString();
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < tmpHash.Length; i++)
            {
                strBuilder.Append(tmpHash[i].ToString("x2"));
            }

            string hashToken = strBuilder.ToString();

            var userList = this.accountService.GetUsers();
            var user = userList.FirstOrDefault(x => x.LoginHash.Equals(hashToken));

            if (user != null)
                return user;
            else
                return null;

        }
    }
}
