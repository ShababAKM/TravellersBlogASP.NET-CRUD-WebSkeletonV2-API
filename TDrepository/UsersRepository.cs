using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDdata;
using TDentity;
using TDinterface;

namespace TDrepository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public List<Users> Search(string keyword)
        {
            return null;
        }
        public Users GetUser(string uname, string pass)
        {
            return this.context.Users.SingleOrDefault(a => a.UserName == uname && a.Password == pass);
        }
    }

}
