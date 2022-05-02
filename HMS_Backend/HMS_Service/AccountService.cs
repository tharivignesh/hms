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
    public interface IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<tblUser> GetUsers();
    }


    /// <summary>
    /// 
    /// </summary>
    public class AccountService : IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IAccountRepository accountRepository;


        public AccountService(IAccountRepository accountRepo)
        {
            this.accountRepository = accountRepo;
        }

        IEnumerable<tblUser> IAccountService.GetUsers()
        {
            return this.accountRepository.GetAll();
        }
    }
}
