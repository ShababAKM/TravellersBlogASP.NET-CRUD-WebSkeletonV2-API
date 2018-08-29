using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Admin
namespace TDentity
{
    public class Admin : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Division { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
