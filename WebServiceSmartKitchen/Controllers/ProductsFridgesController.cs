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
    public class ProductsFridgesController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/ProductsFridges
        public IQueryable<ProductsFridge> GetProductsFridgeSet()
        {
            return db.ProductsFridgeSet;
        }

        // GET: api/ProductsFridges/5
        [ResponseType(typeof(ProductsFridge))]
        public async Task<IHttpActionResult> GetProductsFridge(int id)
        {
            ProductsFridge productsFridge = await db.ProductsFridgeSet.FindAsync(id);
            if (productsFridge == null)
            {
                return NotFound();
            }

            return Ok(productsFridge);
        }

        // PUT: api/ProductsFridges/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductsFridge(int id, ProductsFridge productsFridge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productsFridge.Id)
            {
                return BadRequest();
            }

            db.Entry(productsFridge).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsFridgeExists(id))
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

        // POST: api/ProductsFridges
        [ResponseType(typeof(ProductsFridge))]
        public async Task<IHttpActionResult> PostProductsFridge(ProductsFridge productsFridge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductsFridgeSet.Add(productsFridge);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productsFridge.Id }, productsFridge);
        }

        // DELETE: api/ProductsFridges/5
        [ResponseType(typeof(ProductsFridge))]
        public async Task<IHttpActionResult> DeleteProductsFridge(int id)
        {
            ProductsFridge productsFridge = await db.ProductsFridgeSet.FindAsync(id);
            if (productsFridge == null)
            {
                return NotFound();
            }

            db.ProductsFridgeSet.Remove(productsFridge);
            await db.SaveChangesAsync();

            return Ok(productsFridge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsFridgeExists(int id)
        {
            return db.ProductsFridgeSet.Count(e => e.Id == id) > 0;
        }
    }
}