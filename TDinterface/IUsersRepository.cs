using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDentity;

namespace TDinterface
{
    public interface IUsersRepository:IRepository<Users>
    {
        List<Users> Search(string keyword);
    }
}
