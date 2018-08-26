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
            //string url = /*Url.Link("getUser", new { id = user.Id })*/Url.Link("getUser", new { id = user.Id });
            return Created("", user);
        }
    }
}
