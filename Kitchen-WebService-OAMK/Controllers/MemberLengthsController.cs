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
using Kitchen_WebService_OAMK;
using Kitchen_WebService_OAMK.Models;

namespace Kitchen_WebService_OAMK.Controllers
{
    public class MemberLengthsController : ApiController
    {
        private Kitchen_WebService_OAMKContext db = new Kitchen_WebService_OAMKContext();

        // GET: api/MemberLengths
        public IQueryable<MemberLength> GetMemberLengths()
        {
            return db.MemberLengths;
        }

        // GET: api/MemberLengths/5
        [ResponseType(typeof(MemberLength))]
        public async Task<IHttpActionResult> GetMemberLength(int id)
        {
            MemberLength memberLength = await db.MemberLengths.FindAsync(id);
            if (memberLength == null)
            {
                return NotFound();
            }

            return Ok(memberLength);
        }

        // PUT: api/MemberLengths/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMemberLength(int id, MemberLength memberLength)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memberLength.Id)
            {
                return BadRequest();
            }

            db.Entry(memberLength).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberLengthExists(id))
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

        // POST: api/MemberLengths
        [ResponseType(typeof(MemberLength))]
        public async Task<IHttpActionResult> PostMemberLength(MemberLength memberLength)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MemberLengths.Add(memberLength);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = memberLength.Id }, memberLength);
        }

        // DELETE: api/MemberLengths/5
        [ResponseType(typeof(MemberLength))]
        public async Task<IHttpActionResult> DeleteMemberLength(int id)
        {
            MemberLength memberLength = await db.MemberLengths.FindAsync(id);
            if (memberLength == null)
            {
                return NotFound();
            }

            db.MemberLengths.Remove(memberLength);
            await db.SaveChangesAsync();

            return Ok(memberLength);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberLengthExists(int id)
        {
            return db.MemberLengths.Count(e => e.Id == id) > 0;
        }
    }
}