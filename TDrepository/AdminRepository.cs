using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDentity;
using TDinterface;

namespace TDrepository
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public List<Admin> Search(string keyword)
        {
            return null;
        }

        public Admin GetAdmin(string email, string pass)
        {
            return this.context.Admins.SingleOrDefault(a => a.Email == email && a.Password == pass);
        }
    }
}
