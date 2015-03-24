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
    public class ProductsFridgesController : ApiController
    {
        private Kitchen_WebService_OAMKContext db = new Kitchen_WebService_OAMKContext();

        // GET: api/ProductsFridges
        public IQueryable<ProductsFridge> GetProductsFridges()
        {
            return db.ProductsFridges;
        }

        // GET: api/ProductsFridges/5
        [ResponseType(typeof(ProductsFridge))]
        public async Task<IHttpActionResult> GetProductsFridge(int id)
        {
            ProductsFridge productsFridge = await db.ProductsFridges.FindAsync(id);
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

            db.Entry(productsFridge).State = EntityState.Modified;

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

            db.ProductsFridges.Add(productsFridge);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productsFridge.Id }, productsFridge);
        }

        // DELETE: api/ProductsFridges/5
        [ResponseType(typeof(ProductsFridge))]
        public async Task<IHttpActionResult> DeleteProductsFridge(int id)
        {
            ProductsFridge productsFridge = await db.ProductsFridges.FindAsync(id);
            if (productsFridge == null)
            {
                return NotFound();
            }

            db.ProductsFridges.Remove(productsFridge);
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
            return db.ProductsFridges.Count(e => e.Id == id) > 0;
        }
    }
}