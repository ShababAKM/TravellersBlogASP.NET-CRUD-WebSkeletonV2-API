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
    public class CommentRepository : Repository<Comments>, ICommentRepository
    {
        public List<Comments> Search(string keyword)
        {
            return null;
        }
        public List<Comments> GetCom(int id)
        {
            return this.context.Comments.Where(p => p.BlogId==id).ToList(); ;
        }
        public List<Comments> DelCom(int id)
        {
            context.Comments.RemoveRange(context.Comments.Where(x => x.Id == id));
            context.SaveChanges();
            return this.context.Comments.Where(p => p.BlogId == id).ToList();
        }
    }
}
