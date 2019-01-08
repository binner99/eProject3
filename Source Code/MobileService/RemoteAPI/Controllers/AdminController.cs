using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
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
        public async Task<IHttpActionResult> GetAdmin(string id)
        {
            Admin admin = await db.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }
        
        // POST: api/Admin
        [ResponseType(typeof(Admin))]
        public async Task<IHttpActionResult> PostAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            admin.adRole = false;
            db.Admins.Add(admin);

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> DeleteAdmin(string id)
        {
            Admin admin = await db.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            db.Admins.Remove(admin);
            await db.SaveChangesAsync();

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