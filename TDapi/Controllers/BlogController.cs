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
        public BlogController(IBlogRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet][Route("")]
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
            return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("update/{id}")][HttpPost]
        public IHttpActionResult Put([FromBody]Blogs blog, [FromUri]int id)
        {
            blog.Id = id;
            repo.Update(blog);
            return Ok(blog);
        }
    }
}
