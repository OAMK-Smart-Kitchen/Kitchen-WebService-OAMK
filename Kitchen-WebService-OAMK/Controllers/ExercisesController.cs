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
    public class ExercisesController : ApiController
    {
        private Kitchen_WebService_OAMKContext db = new Kitchen_WebService_OAMKContext();

        // GET: api/Exercises
        public IQueryable<Exercises> GetExercises()
        {
            return db.Exercises;
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(Exercises))]
        public async Task<IHttpActionResult> GetExercises(int id)
        {
            Exercises exercises = await db.Exercises.FindAsync(id);
            if (exercises == null)
            {
                return NotFound();
            }

            return Ok(exercises);
        }

        // PUT: api/Exercises/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExercises(int id, Exercises exercises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercises.Id)
            {
                return BadRequest();
            }

            db.Entry(exercises).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercisesExists(id))
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

        // POST: api/Exercises
        [ResponseType(typeof(Exercises))]
        public async Task<IHttpActionResult> PostExercises(Exercises exercises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercises.Add(exercises);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = exercises.Id }, exercises);
        }

        // DELETE: api/Exercises/5
        [ResponseType(typeof(Exercises))]
        public async Task<IHttpActionResult> DeleteExercises(int id)
        {
            Exercises exercises = await db.Exercises.FindAsync(id);
            if (exercises == null)
            {
                return NotFound();
            }

            db.Exercises.Remove(exercises);
            await db.SaveChangesAsync();

            return Ok(exercises);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExercisesExists(int id)
        {
            return db.Exercises.Count(e => e.Id == id) > 0;
        }
    }
}