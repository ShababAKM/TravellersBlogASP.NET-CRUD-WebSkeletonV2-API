using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDentity
{
    public class Blogs : Entity
    {
        public int WriterId { get; set; }
        public string BlogName { get; set; }
        public string Blog { get; set; }
        public int Rating { get; set; }
    }
}
