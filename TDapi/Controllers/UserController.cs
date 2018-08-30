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
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private IUserRepository repo;

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet][Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        [Route("")][HttpPost]
        public IHttpActionResult Insert(User user)
        {
            repo.Insert(user);
            return Ok(user);
        }

        [Route("getUser")][HttpPost]
        public IHttpActionResult GetU(User user)
        {
            if (user.UserName != "" && user.Password != "")
                return Ok(repo.GetUser(user.UserName, user.Password));
            else if(repo.GetUser(user.UserName, user.Password)==null)
                return StatusCode(HttpStatusCode.Unauthorized);
            else return StatusCode(HttpStatusCode.Unauthorized);
        }

        [Route("{id}/update")]
        public IHttpActionResult Put([FromBody]User user, [FromUri]int id)
        {
            user.Id = id;
            repo.Update(user);
            return Ok(user);
        }

        [Route("{id}/delete")][HttpPost]
        public IHttpActionResult Delete(User user)
        {
            if (repo.GetUser(user.UserName, user.Password) != null)
            {
                user = repo.GetUser(user.UserName, user.Password);
                repo.Delete(user);
                return Ok(user);
            }
            else return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
