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
    public class ShoppingBagProductsController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/ShoppingBagProducts
        public IQueryable<ShoppingBagProducts> GetShoppingBagProductsSet()
        {
            return db.ShoppingBagProductsSet;
        }

        // GET: api/ShoppingBagProducts/5
        [ResponseType(typeof(ShoppingBagProducts))]
        public async Task<IHttpActionResult> GetShoppingBagProducts(int id)
        {
            ShoppingBagProducts shoppingBagProducts = await db.ShoppingBagProductsSet.FindAsync(id);
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

            db.Entry(shoppingBagProducts).State = System.Data.Entity.EntityState.Modified;

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

            db.ShoppingBagProductsSet.Add(shoppingBagProducts);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shoppingBagProducts.Id }, shoppingBagProducts);
        }

        // DELETE: api/ShoppingBagProducts/5
        [ResponseType(typeof(ShoppingBagProducts))]
        public async Task<IHttpActionResult> DeleteShoppingBagProducts(int id)
        {
            ShoppingBagProducts shoppingBagProducts = await db.ShoppingBagProductsSet.FindAsync(id);
            if (shoppingBagProducts == null)
            {
                return NotFound();
            }

            db.ShoppingBagProductsSet.Remove(shoppingBagProducts);
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
            return db.ShoppingBagProductsSet.Count(e => e.Id == id) > 0;
        }
    }
}