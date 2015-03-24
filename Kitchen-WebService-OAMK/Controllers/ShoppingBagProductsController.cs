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
    public class ShoppingBagProductsController : ApiController
    {
        private Kitchen_WebService_OAMKContext db = new Kitchen_WebService_OAMKContext();

        // GET: api/ShoppingBagProducts
        public IQueryable<ShoppingBagProducts> GetShoppingBagProducts()
        {
            return db.ShoppingBagProducts;
        }

        // GET: api/ShoppingBagProducts/5
        [ResponseType(typeof(ShoppingBagProducts))]
        public async Task<IHttpActionResult> GetShoppingBagProducts(int id)
        {
            ShoppingBagProducts shoppingBagProducts = await db.ShoppingBagProducts.FindAsync(id);
            if (shoppingBagProducts == null)
            {
                return NotFound();
            }

            return Ok(shoppingBagProducts);
        }

        // PUT: api/ShoppingBagProducts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShoppingBagProducts(int id, ShoppingBagProducts shoppingBagProducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shoppingBagProducts.Id)
            {
                return BadRequest();
            }

            db.Entry(shoppingBagProducts).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingBagProductsExists(id))
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

        // POST: api/ShoppingBagProducts
        [ResponseType(typeof(ShoppingBagProducts))]
        public async Task<IHttpActionResult> PostShoppingBagProducts(ShoppingBagProducts shoppingBagProducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShoppingBagProducts.Add(shoppingBagProducts);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shoppingBagProducts.Id }, shoppingBagProducts);
        }

        // DELETE: api/ShoppingBagProducts/5
        [ResponseType(typeof(ShoppingBagProducts))]
        public async Task<IHttpActionResult> DeleteShoppingBagProducts(int id)
        {
            ShoppingBagProducts shoppingBagProducts = await db.ShoppingBagProducts.FindAsync(id);
            if (shoppingBagProducts == null)
            {
                return NotFound();
            }

            db.ShoppingBagProducts.Remove(shoppingBagProducts);
            await db.SaveChangesAsync();

            return Ok(shoppingBagProducts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShoppingBagProductsExists(int id)
        {
            return db.ShoppingBagProducts.Count(e => e.Id == id) > 0;
        }
    }
}