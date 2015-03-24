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
    public class ShoppingBagsController : ApiController
    {
        private Kitchen_WebService_OAMKContext db = new Kitchen_WebService_OAMKContext();

        // GET: api/ShoppingBags
        public IQueryable<ShoppingBags> GetShoppingBags()
        {
            return db.ShoppingBags;
        }

        // GET: api/ShoppingBags/5
        [ResponseType(typeof(ShoppingBags))]
        public async Task<IHttpActionResult> GetShoppingBags(int id)
        {
            ShoppingBags shoppingBags = await db.ShoppingBags.FindAsync(id);
            if (shoppingBags == null)
            {
                return NotFound();
            }

            return Ok(shoppingBags);
        }

        // PUT: api/ShoppingBags/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShoppingBags(int id, ShoppingBags shoppingBags)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shoppingBags.Id)
            {
                return BadRequest();
            }

            db.Entry(shoppingBags).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingBagsExists(id))
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

        // POST: api/ShoppingBags
        [ResponseType(typeof(ShoppingBags))]
        public async Task<IHttpActionResult> PostShoppingBags(ShoppingBags shoppingBags)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShoppingBags.Add(shoppingBags);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shoppingBags.Id }, shoppingBags);
        }

        // DELETE: api/ShoppingBags/5
        [ResponseType(typeof(ShoppingBags))]
        public async Task<IHttpActionResult> DeleteShoppingBags(int id)
        {
            ShoppingBags shoppingBags = await db.ShoppingBags.FindAsync(id);
            if (shoppingBags == null)
            {
                return NotFound();
            }

            db.ShoppingBags.Remove(shoppingBags);
            await db.SaveChangesAsync();

            return Ok(shoppingBags);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShoppingBagsExists(int id)
        {
            return db.ShoppingBags.Count(e => e.Id == id) > 0;
        }
    }
}