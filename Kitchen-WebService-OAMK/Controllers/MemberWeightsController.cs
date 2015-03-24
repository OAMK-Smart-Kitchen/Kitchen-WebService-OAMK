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
    public class MemberWeightsController : ApiController
    {
        private Kitchen_WebService_OAMKContext db = new Kitchen_WebService_OAMKContext();

        // GET: api/MemberWeights
        public IQueryable<MemberWeight> GetMemberWeights()
        {
            return db.MemberWeights;
        }

        // GET: api/MemberWeights/5
        [ResponseType(typeof(MemberWeight))]
        public async Task<IHttpActionResult> GetMemberWeight(int id)
        {
            MemberWeight memberWeight = await db.MemberWeights.FindAsync(id);
            if (memberWeight == null)
            {
                return NotFound();
            }

            return Ok(memberWeight);
        }

        // PUT: api/MemberWeights/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMemberWeight(int id, MemberWeight memberWeight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memberWeight.Id)
            {
                return BadRequest();
            }

            db.Entry(memberWeight).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberWeightExists(id))
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

        // POST: api/MemberWeights
        [ResponseType(typeof(MemberWeight))]
        public async Task<IHttpActionResult> PostMemberWeight(MemberWeight memberWeight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MemberWeights.Add(memberWeight);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = memberWeight.Id }, memberWeight);
        }

        // DELETE: api/MemberWeights/5
        [ResponseType(typeof(MemberWeight))]
        public async Task<IHttpActionResult> DeleteMemberWeight(int id)
        {
            MemberWeight memberWeight = await db.MemberWeights.FindAsync(id);
            if (memberWeight == null)
            {
                return NotFound();
            }

            db.MemberWeights.Remove(memberWeight);
            await db.SaveChangesAsync();

            return Ok(memberWeight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberWeightExists(int id)
        {
            return db.MemberWeights.Count(e => e.Id == id) > 0;
        }
    }
}