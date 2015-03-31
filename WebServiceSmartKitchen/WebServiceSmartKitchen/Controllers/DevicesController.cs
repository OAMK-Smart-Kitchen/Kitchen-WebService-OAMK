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
    public class DevicesController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/Devices
        public IQueryable<Devices> GetDevicesSet()
        {
            return db.DevicesSet;
        }

        // GET: api/Devices/5
        [ResponseType(typeof(Devices))]
        public async Task<IHttpActionResult> GetDevices(int id)
        {
            Devices devices = await db.DevicesSet.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }

            return Ok(devices);
        }

        // PUT: api/Devices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDevices(int id, Devices devices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != devices.Id)
            {
                return BadRequest();
            }

            db.Entry(devices).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevicesExists(id))
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

        // POST: api/Devices
        [ResponseType(typeof(Devices))]
        public async Task<IHttpActionResult> PostDevices(Devices devices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DevicesSet.Add(devices);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = devices.Id }, devices);
        }

        // DELETE: api/Devices/5
        [ResponseType(typeof(Devices))]
        public async Task<IHttpActionResult> DeleteDevices(int id)
        {
            Devices devices = await db.DevicesSet.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }

            db.DevicesSet.Remove(devices);
            await db.SaveChangesAsync();

            return Ok(devices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DevicesExists(int id)
        {
            return db.DevicesSet.Count(e => e.Id == id) > 0;
        }
    }
}