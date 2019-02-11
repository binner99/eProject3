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
using Data.Vo;
using RemoteAPI.Models;

namespace RemoteAPI.Controllers
{
    public class MemberController : ApiController
    {
        private ConnectDatabase db = new ConnectDatabase();

        // GET: api/Member
        public IQueryable<Member> GetMembers()
        {
            return db.Members;
        }

        // GET: api/Member/5
        [ResponseType(typeof(Member))]
        public async Task<IHttpActionResult> GetMember(string id)
        {
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Member/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMember(string id, Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.memPhone)
            {
                return BadRequest();
            }

            db.Entry(member).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("check/Member")]
        [ResponseType(typeof(Admin))]
        public IHttpActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var memCheck = db.Members.First(x => x.memPhone == login.memPhone && x.memPass == login.memPass);
            if (memCheck == null)
            {
                return NotFound();
            }
            return Ok(memCheck);
        }

        // POST: api/Member
        [ResponseType(typeof(Member))]
        public async Task<IHttpActionResult> PostMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Members.Add(member);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MemberExists(member.memPhone))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = member.memPhone }, member);
        }

        // DELETE: api/Member/5
        [ResponseType(typeof(Member))]
        public async Task<IHttpActionResult> DeleteMember(string id)
        {
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            db.Members.Remove(member);
            await db.SaveChangesAsync();

            return Ok(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberExists(string id)
        {
            return db.Members.Count(e => e.memPhone == id) > 0;
        }
    }
}