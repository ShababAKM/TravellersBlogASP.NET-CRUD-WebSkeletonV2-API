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
        private IUsersRepository repo;

        public UserController(IUsersRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet][Route("")]
        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }
        [Route("")][HttpPost]
        public IHttpActionResult Insert(Users user)
        {
            repo.Insert(user);
            return Ok(user);
        }
        [Route("getUser")][HttpPost]
        public IHttpActionResult GetU(Users user)
        {
            return Ok(repo.GetUser(user.UserName,user.Password));
        }
        [Route("{id}/update")]
        public IHttpActionResult Put([FromBody]Users user, [FromUri]int id)
        {
            user.Id = id;
            repo.Update(user);
            return Ok(user);
        }
        [Route("{id}/delete")][HttpPost]
        public IHttpActionResult Delete(Users user)
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
