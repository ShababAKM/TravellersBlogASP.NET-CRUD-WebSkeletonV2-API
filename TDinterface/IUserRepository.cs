using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDentity;

namespace TDinterface
{
    public interface IUserRepository:IRepository<User>
    {
        List<User> Search(string keyword);
        User GetUser(string uname, string pass);
    }
}
