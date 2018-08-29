using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDentity;

namespace TDinterface
{
    public interface ICommentRepository : IRepository<Comments>
    {
        List<Comments> Search(string keyword);
        List<Comments> GetCom(int id);
        List<Comments> DelCom(int id);
    }
}
