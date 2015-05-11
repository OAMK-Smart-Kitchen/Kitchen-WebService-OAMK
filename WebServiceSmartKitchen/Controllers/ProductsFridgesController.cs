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
    public class ProductsFridgesController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: service/Hardware/Products
        // GET: service/Fridge/Products
        [ActionName("Getproducts")]
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

        // PUT: service/ProductsFridges/5
        [ActionName("Editproduct")]
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

            IEnumerable<ProductsFridge> productFridgeSearchExist = from search in db.ProductsFridgeSet
                                                                   where search.Id == id
                                                                   select search;
            if (!productFridgeSearchExist.Any())
            {
                return Conflict();
            }
            ProductsFridge productEdit = new ProductsFridge();
            productEdit = productFridgeSearchExist.FirstOrDefault();
            productEdit.Calories = productsFridge.Calories;
            productEdit.ExpirationDate = productsFridge.ExpirationDate;
            productEdit.Name = productsFridge.Name;
            productEdit.Quantity = productsFridge.Quantity;
            productEdit.Category = productsFridge.Category;
            productEdit.Available = productsFridge.Available;


            db.Entry(productEdit).State = System.Data.Entity.EntityState.Modified;

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

        // PUT: service/Hardware/Product
        [ActionName("NFCproduct")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductsFridge1(FridgeProductsNfc product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable<ProductsFridge> productFridgeSearchExist = from search in db.ProductsFridgeSet
                                                     where search.IdNFC == product.IdNFC
                                                     select search;
            if (!productFridgeSearchExist.Any())
            {
                return Conflict();
            }
            ProductsFridge productEdit = new ProductsFridge();
            productEdit = productFridgeSearchExist.FirstOrDefault();
            productEdit.Address = product.Address;
            productEdit.Available = product.Available;

            db.Entry(productEdit).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                   return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductsFridges
        [ActionName("Addproduct")]
        [ResponseType(typeof(ProductsFridge))]
        public async Task<IHttpActionResult> PostProductsFridge(int id, ProductsFridge productsFridge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kitchen kitchen = await db.KitchenSet.FindAsync(id);
            if (kitchen == null)
            {
                return NotFound();
            }
            kitchen.ProductsFridge.Add(productsFridge);
            db.KitchenSet.Attach(kitchen);
            await db.SaveChangesAsync();

            return Ok(kitchen);
            
            //return CreatedAtRoute("DefaultApi", new { id = productsFridge.Id }, productsFridge);
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