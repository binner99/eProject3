using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using Data;
using RemoteAPI.Models;

namespace RemoteAPI.Controllers
{
    public class AdminController : ApiController
    {
        private ConnectDatabase db = new ConnectDatabase();

        // GET: api/Admin
        public IQueryable<Admin> GetAdmins()
        {
            return db.Admins;
        }

        // GET: api/Admin/5
        [ResponseType(typeof(Admin))]
        public IHttpActionResult GetAdmin(string id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [Route("check/Admin")]
        [HttpPost]
        public IHttpActionResult Login(Admin admin)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var adCheck = db.Admins.First(x => x.adName == admin.adName && x.adPass == admin.adPass);
            if (adCheck == null)
            {
                return NotFound();
            }            
            return Ok();
        }

        // POST: api/Admin
        [ResponseType(typeof(Admin))]
        public IHttpActionResult PostAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Admins.Add(admin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdminExists(admin.adName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = admin.adName }, admin);
        }

        // DELETE: api/Admin/5
        [ResponseType(typeof(Admin))]
        public IHttpActionResult DeleteAdmin(string id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            db.Admins.Remove(admin);
            db.SaveChanges();

            return Ok(admin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminExists(string id)
        {
            return db.Admins.Count(e => e.adName == id) > 0;
        }
    }
}