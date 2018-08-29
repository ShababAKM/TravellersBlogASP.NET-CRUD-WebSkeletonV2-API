using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TDentity;

namespace TDdata
{
    public class TDDBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
