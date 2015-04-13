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
using WebServiceSmartKitchen.Models;

namespace WebServiceSmartKitchen.Controllers
{
    public class MembersController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/Members
        public IQueryable<Members> GetMembersSet()
        {
            return db.MembersSet;
        }

        // GET: api/Members/5
        [ResponseType(typeof(Members))]
        public async Task<IHttpActionResult> GetMembers(int id)
        {
            Members members = await db.MembersSet.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }

            return Ok(members);
        }

        // PUT: api/Members/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembers(int id, Members members)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != members.Id)
            {
                return BadRequest();
            }

            db.Entry(members).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersExists(id))
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

        // POST: api/Members
        [ActionName("Register")]
        [ResponseType(typeof(Members))]
        public async Task<IHttpActionResult> PostMembers(Members members)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MembersSet.Add(members);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = members.Id }, members);
        }

        // DELETE: api/Members/5
        [ResponseType(typeof(Members))]
        public async Task<IHttpActionResult> DeleteMembers(int id)
        {
            Members members = await db.MembersSet.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }

            db.MembersSet.Remove(members);
            await db.SaveChangesAsync();

            return Ok(members);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MembersExists(int id)
        {
            return db.MembersSet.Count(e => e.Id == id) > 0;
        }
    }
}