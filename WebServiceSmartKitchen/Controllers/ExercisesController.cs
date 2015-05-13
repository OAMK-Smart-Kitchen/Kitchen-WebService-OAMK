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
    public class ExercisesController : ApiController
    {
        private ModelContainer db = new ModelContainer();

        // GET: api/Exercises
        [ActionName("GetExercises")]
        public IQueryable<Exercises> GetExercisesSet()
        {
            return db.ExercisesSet;
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(Exercises))]
        public async Task<IHttpActionResult> GetExercises(int id)
        {
            Exercises exercises = await db.ExercisesSet.FindAsync(id);
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

            db.Entry(exercises).State = System.Data.Entity.EntityState.Modified;

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

            db.ExercisesSet.Add(exercises);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = exercises.Id }, exercises);
        }

        // DELETE: api/Exercises/5
        [ResponseType(typeof(Exercises))]
        public async Task<IHttpActionResult> DeleteExercises(int id)
        {
            Exercises exercises = await db.ExercisesSet.FindAsync(id);
            if (exercises == null)
            {
                return NotFound();
            }

            db.ExercisesSet.Remove(exercises);
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
            return db.ExercisesSet.Count(e => e.Id == id) > 0;
        }
    }
}