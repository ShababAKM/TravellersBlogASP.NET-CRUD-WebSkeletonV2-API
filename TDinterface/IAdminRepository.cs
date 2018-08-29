using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDentity;

namespace TDinterface
{
    public interface IAdminRepository : IRepository<Admin>
    {
        List<Admin> Search(string keyword);
        Admin GetAdmin(string email, string pass);
    }
}
