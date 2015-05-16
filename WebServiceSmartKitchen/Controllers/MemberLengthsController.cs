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
    public class MemberLengthsController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // POST: service/Member/Length/5
        [ActionName("AddMemberLength")]
        [ResponseType(typeof(MemberLength))]
        public async Task<IHttpActionResult> PostMemberLength(int id, MemberLength memberLength)
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

                member.MemberLength.Add(memberLength);
                db.MembersSet.Attach(member);
                await db.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/MemberLengths/5
        [ResponseType(typeof(MemberLength))]
        public async Task<IHttpActionResult> DeleteMemberLength(int id)
        {
            MemberLength memberLength = await db.MemberLengthSet.FindAsync(id);
            if (memberLength == null)
            {
                return NotFound();
            }

            db.MemberLengthSet.Remove(memberLength);
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
            return db.MemberLengthSet.Count(e => e.Id == id) > 0;
        }
    }
}