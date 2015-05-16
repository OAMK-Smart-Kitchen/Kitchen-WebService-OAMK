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
    public class KitchensController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // POST: service/Kitchens/Login
        [ActionName("Login")]
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> PostLogin(KitchenLogin login)
        {
            try
            {
                // Members member = await db.MembersSet.FindAsync(login.Email); //Only keys can send, use other method function.
                IEnumerable<Members> memberSearch = from search in db.MembersSet
                                                    where search.Email == login.Email
                                                    select search;
                Members member = new Members();
                member = memberSearch.FirstOrDefault();
                if (member == null)
                {
                    return NotFound();
                }
                else if (member.Password == login.Password)
                {
                    Kitchen kitchen = await db.KitchenSet.FindAsync(member.Kitchen.Id);
                    return Ok(kitchen);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, e.Message));
            }

        }


        // GET: service/Kitchens
        public IQueryable<Kitchen> GetKitchenSet()
        {
            return db.KitchenSet;
        }

        // GET: service/Kitchens/5
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> GetKitchen(int id)
        {
            Kitchen kitchen = await db.KitchenSet.FindAsync(id);
            if (kitchen == null)
            {
                return NotFound();
            }

            return Ok(kitchen);
        }

        // PUT: service/Kitchens/5
        
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> PutKitchen(int id, Kitchen kitchen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kitchen.Id)
            {
                return BadRequest();
            }

            db.Entry(kitchen).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
                return Ok(kitchen);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitchenExists(id))
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

        // POST: service/Kitchens/Register
        [ActionName("Register")]
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> PostKitchen(KitchenRegister register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable<Members> memberSearchExist = from search in db.MembersSet
                                                where search.Email == register.Email
                                                select search;
            if (memberSearchExist.Any())
            {
                return Conflict();
            }
            Kitchen kitchen = new Kitchen();
            Members addMember = new Members();
            kitchen.Name = register.KitchenName;
            addMember.Active = register.Active;
            addMember.Admin = register.Admin;
            addMember.DateOfBirth = register.DateOfBirth;
            addMember.Email = register.Email;
            addMember.Firstname = register.Firstname;
            addMember.Lastname = register.Lastname;
            addMember.Password = register.Password;
            addMember.GamePoints = "100";
            kitchen.Members.Add(addMember);
            db.KitchenSet.Add(kitchen);
            await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = kitchen.Id }, kitchen);
            return Ok(kitchen);
        }

        // POST: service/Kitchen/Member/{id}
        [ActionName("Member")]
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> PostMember(int id, Members member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IEnumerable<Members> memberSearchExist = from search in db.MembersSet
                                                     where search.Email == member.Email
                                                     select search;
            if (memberSearchExist.Any())
            {
                return Conflict();
            }

            Kitchen kitchen = await db.KitchenSet.FindAsync(id);
            if (kitchen == null)
            {
                return NotFound();
            }
            member.GamePoints = "100";
            kitchen.Members.Add(member);
            db.KitchenSet.Attach(kitchen);
            await db.SaveChangesAsync();

            return Ok(kitchen);
        }

        // DELETE: service/Kitchens/5
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> DeleteKitchen(int id)
        {
            Kitchen kitchen = await db.KitchenSet.FindAsync(id);
            if (kitchen == null)
            {
                return NotFound();
            }

            db.KitchenSet.Remove(kitchen);
            await db.SaveChangesAsync();

            return Ok(kitchen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KitchenExists(int id)
        {
            return db.KitchenSet.Count(e => e.Id == id) > 0;
        }
    }
}