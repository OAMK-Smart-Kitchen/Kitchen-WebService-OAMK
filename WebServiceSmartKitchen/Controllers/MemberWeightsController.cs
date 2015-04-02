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
    public class MemberWeightsController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/MemberWeights
        public IQueryable<MemberWeight> GetMemberWeightSet()
        {
            return db.MemberWeightSet;
        }

        // GET: api/MemberWeights/5
        [ResponseType(typeof(MemberWeight))]
        public async Task<IHttpActionResult> GetMemberWeight(int id)
        {
            MemberWeight memberWeight = await db.MemberWeightSet.FindAsync(id);
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

            db.Entry(memberWeight).State = System.Data.Entity.EntityState.Modified;

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

            db.MemberWeightSet.Add(memberWeight);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = memberWeight.Id }, memberWeight);
        }

        // DELETE: api/MemberWeights/5
        [ResponseType(typeof(MemberWeight))]
        public async Task<IHttpActionResult> DeleteMemberWeight(int id)
        {
            MemberWeight memberWeight = await db.MemberWeightSet.FindAsync(id);
            if (memberWeight == null)
            {
                return NotFound();
            }

            db.MemberWeightSet.Remove(memberWeight);
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
            return db.MemberWeightSet.Count(e => e.Id == id) > 0;
        }
    }
}