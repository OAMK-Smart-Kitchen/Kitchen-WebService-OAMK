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
using Kitchen_WebService_OAMK.Models;

namespace Kitchen_WebService_OAMK.Controllers
{
    public class KitchensController : ApiController
    {
        private Kitchen_WebService_OAMKContext db = new Kitchen_WebService_OAMKContext();

        // GET: api/Kitchens
        public IQueryable<Kitchen> GetKitchens()
        {
            return db.Kitchen;
        }

        // GET: api/Kitchens/5
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> GetKitchen(int id)
        {
            Kitchen kitchen = await db.Kitchen.FindAsync(id);
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

            db.Entry(kitchen).State = EntityState.Modified;

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

        // POST: api/Kitchens
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> PostKitchen(Kitchen kitchen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kitchen.Add(kitchen);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kitchen.Id }, kitchen);
        }

        // DELETE: api/Kitchens/5
        [ResponseType(typeof(Kitchen))]
        public async Task<IHttpActionResult> DeleteKitchen(int id)
        {
            Kitchen kitchen = await db.Kitchen.FindAsync(id);
            if (kitchen == null)
            {
                return NotFound();
            }

            db.Kitchen.Remove(kitchen);
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
            return db.Kitchen.Count(e => e.Id == id) > 0;
        }
    }
}