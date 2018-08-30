using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TDentity;
using TDinterface;
using TDrepository;
namespace TDapi.Controllers
{
    [RoutePrefix("api/users/blogs")]
    public class BlogController : ApiController
    {
        private IBlogRepository repo;
        private ICommentRepository repo2;
        public BlogController(IBlogRepository repo,ICommentRepository repo2)
        {
            this.repo = repo;
            this.repo2 = repo2;
        }
        [HttpGet][Route("{id}")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        [Route("{id}")][HttpPost]
        public IHttpActionResult Insert([FromBody]Blogs blog, [FromUri]int id)
        {
            blog.WriterId = id;
            repo.Insert(blog);
            return Ok(blog);
        }
        [Route("delete/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            repo.Delete(repo.Get(id));
            repo2.DelCom(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("update/{id}")][HttpPost]
        public IHttpActionResult Put([FromBody]Blogs blog, [FromUri]int id)
        {
            blog.Id = id;
            repo.Update(blog);
            return Ok(blog);
        }
        [Route("search")][HttpPost]
        public IHttpActionResult Search(SearchString keyword)
        {
            return Ok(repo.SearchBlog(keyword.searchString));
        }
        [Route("userBlog/{id}")][HttpPost]
        public IHttpActionResult InsertCom([FromBody]Comments comm, [FromUri]int id)
        {
            comm.BlogId = id;
            repo2.Insert(comm);
            return Ok(repo2.GetAll());
        }
        [Route("userBlog/{id}")]
        public IHttpActionResult GetC([FromUri]int id)
        {
            GetB(id);
           return Ok(repo2.GetCom(id));
        }
        public IHttpActionResult GetB(int id)
        {
            return Ok(repo.GetBlog(id));
        }
        [Route("userBlog/{id}/rate")]
        public IHttpActionResult Rating([FromBody]Blogs blog,[FromUri]int id)
        {
            SearchString ss = new SearchString();
            ss.rating = blog.Rating;
            Blogs blog2 = repo.GetBlog(id);
            blog2.Rating = blog2.Rating + ss.rating;
            repo.Update(blog2);
            return Ok(blog);
        }
    }
}
