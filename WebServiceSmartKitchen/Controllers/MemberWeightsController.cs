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

        // POST: service/Member/Weight/5
        [ActionName("AddMemberWeight")]
        public async Task<IHttpActionResult> PostMemberWeight(int id, MemberWeight memberWeight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Members member = await db.MembersSet.FindAsync(id);
                
                if (member == null)
                {
                    return NotFound();
                }

                member.MemberWeight.Add(memberWeight);
                db.MembersSet.Attach(member);
                await db.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
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