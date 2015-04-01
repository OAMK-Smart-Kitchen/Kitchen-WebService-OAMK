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
    public class ShoppingBagsController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/ShoppingBags
        public IQueryable<ShoppingBags> GetShoppingBagsSet()
        {
            return db.ShoppingBagsSet;
        }

        // GET: api/ShoppingBags/5
        [ResponseType(typeof(ShoppingBags))]
        public async Task<IHttpActionResult> GetShoppingBags(int id)
        {
            ShoppingBags shoppingBags = await db.ShoppingBagsSet.FindAsync(id);
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

            db.Entry(shoppingBags).State = System.Data.Entity.EntityState.Modified;

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

            db.ShoppingBagsSet.Add(shoppingBags);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shoppingBags.Id }, shoppingBags);
        }

        // DELETE: api/ShoppingBags/5
        [ResponseType(typeof(ShoppingBags))]
        public async Task<IHttpActionResult> DeleteShoppingBags(int id)
        {
            ShoppingBags shoppingBags = await db.ShoppingBagsSet.FindAsync(id);
            if (shoppingBags == null)
            {
                return NotFound();
            }

            db.ShoppingBagsSet.Remove(shoppingBags);
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
            return db.ShoppingBagsSet.Count(e => e.Id == id) > 0;
        }
    }
}