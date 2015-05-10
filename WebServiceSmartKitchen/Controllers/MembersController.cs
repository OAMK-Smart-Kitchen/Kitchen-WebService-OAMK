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
using WebServiceSmartKitchen.ViewModels;

namespace WebServiceSmartKitchen.Controllers
{
    public class MembersController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: service/Members
        public IQueryable<Members> GetMembersSet()
        {
            return db.MembersSet;
        }

        // GET: service/Members/Profile/5
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

        // PUT: service/Member/5
        [ActionName("Update")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembers(int id, MemberUpdate member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Members> memberSearchExist = from search in db.MembersSet
                                                     where search.Id == id 
                                                     select search;
            if (!memberSearchExist.Any())
            {
                return Conflict();
            }

            try
            {
                Members memberChanged = memberSearchExist.FirstOrDefault();
                memberChanged.Firstname = member.Firstname;
                memberChanged.Lastname = member.Lastname;
                memberChanged.DateOfBirth = member.DateOfBirth;
                memberChanged.DefaultColor = member.DefaultColor;
                memberChanged.Email = member.Email;
                memberChanged.GameActivated = member.GameActivated;
                memberChanged.Active = member.Active;

                db.Entry(memberChanged).State = System.Data.Entity.EntityState.Modified;

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

        // POST: service/Kitchen/AddMember
        [ActionName("AddMember")]
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

        // DELETE: service/Members/5
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