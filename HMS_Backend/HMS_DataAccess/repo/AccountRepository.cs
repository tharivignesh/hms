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
    public interface IAccountRepository : IRepository<tblUser>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class AccountRepository : RepositoryBase<tblUser>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
