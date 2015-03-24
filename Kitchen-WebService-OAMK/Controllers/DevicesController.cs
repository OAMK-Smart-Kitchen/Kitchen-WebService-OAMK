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
    public class DevicesController : ApiController
    {
        private Kitchen_WebService_OAMKContext db = new Kitchen_WebService_OAMKContext();

        // GET: api/Devices
        public IQueryable<Devices> GetDevices()
        {
            return db.Devices;
        }

        // GET: api/Devices/5
        [ResponseType(typeof(Devices))]
        public async Task<IHttpActionResult> GetDevices(int id)
        {
            Devices devices = await db.Devices.FindAsync(id);
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

            db.Entry(devices).State = EntityState.Modified;

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

            db.Devices.Add(devices);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = devices.Id }, devices);
        }

        // DELETE: api/Devices/5
        [ResponseType(typeof(Devices))]
        public async Task<IHttpActionResult> DeleteDevices(int id)
        {
            Devices devices = await db.Devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }

            db.Devices.Remove(devices);
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
            return db.Devices.Count(e => e.Id == id) > 0;
        }
    }
}