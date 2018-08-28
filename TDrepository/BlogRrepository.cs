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
    public class BlogRrepository : Repository<Blogs>, IBlogRepository
    {
        public List<Blogs> Search(string keyword)
        {
            return null;
        }
        public Blogs GetBlog(int id)
        {
            return this.context.Blogs.SingleOrDefault(a => a.Id==id);
        }
    }
}
