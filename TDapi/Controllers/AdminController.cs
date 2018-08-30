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
    [RoutePrefix("api/admins")]
    public class AdminController : ApiController
    {
        private IAdminRepository aRepo;
        private IUserRepository uRepo;

        public AdminController(IAdminRepository aRepo, IUserRepository uRepo)
        {
            this.aRepo = aRepo;
            this.uRepo = uRepo;
        }

        [HttpGet][Route("")]
        public IHttpActionResult Get()
        {
            return Ok(aRepo.GetAll());
        }

        [Route("{id}", Name = "GetAdmin")]
        public IHttpActionResult Get(int id)
        {
            Admin adm = aRepo.Get(id);

            //return adm == null ? StatusCode(HttpStatusCode.NoContent) : Ok(adm);

            if (adm == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return Ok(adm);
            }

        }

        [Route("getAdmin")][HttpPost]
        public IHttpActionResult GetA(Admin admin)
        {
            return Ok(aRepo.GetAdmin(admin.Email, admin.Password));
        }

        [Route("")][HttpPost]
        public IHttpActionResult Insert(Admin admin)
        {
            aRepo.Insert(admin);
            //string url = Url.Link("GetAdmin", new { id = admin.Id });
            //return Created(url, admin);
            return Ok(admin);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Admin admin, [FromUri]int id)
        {
            admin.Id = id;
            aRepo.Update(admin);
            return Ok(admin);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            aRepo.Delete(aRepo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(uRepo.GetAll());
        }
    }
}
