using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDentity;

namespace TDinterface
{
    public interface IBlogRepository : IRepository<Blogs>
    {
        List<Blogs> Search(string keyword);
        Blogs GetBlog(int id);
        List<Blogs> SearchBlog(string searchString);
    }
}
