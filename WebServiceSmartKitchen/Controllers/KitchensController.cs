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

        // POST: api/Kitchens/Login
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


        // GET: api/Kitchens
        public IQueryable<Kitchen> GetKitchenSet()
        {
            return db.KitchenSet;
        }

        // GET: api/Kitchens/5
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

        // PUT: api/Kitchens/5
        [ResponseType(typeof(void))]
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

        // POST: api/Kitchens/Register
        [ActionName("Register")]
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> PostKitchen(Kitchen kitchen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KitchenSet.Add(kitchen);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kitchen.Id }, kitchen);
        }

        // DELETE: api/Kitchens/5
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