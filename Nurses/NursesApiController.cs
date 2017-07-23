using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication9.Context;

namespace WebApplication9.Nurses
{
    public class NursesApiController : ApiController
    {
        private HospitalContext db = new HospitalContext();

        // GET: api/NursesApi
        public IQueryable<Nurse> GetNurses()
        {
            return db.Nurses;
        }

        // GET: api/NursesApi/5
        [ResponseType(typeof(Nurse))]
        public IHttpActionResult GetNurse(int id)
        {
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return NotFound();
            }

            return Ok(nurse);
        }

        // PUT: api/NursesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNurse(int id, Nurse nurse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nurse.NurseID)
            {
                return BadRequest();
            }

            db.Entry(nurse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseExists(id))
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

        // POST: api/NursesApi
        [ResponseType(typeof(Nurse))]
        public IHttpActionResult PostNurse(Nurse nurse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nurses.Add(nurse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nurse.NurseID }, nurse);
        }

        // DELETE: api/NursesApi/5
        [ResponseType(typeof(Nurse))]
        public IHttpActionResult DeleteNurse(int id)
        {
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return NotFound();
            }

            db.Nurses.Remove(nurse);
            db.SaveChanges();

            return Ok(nurse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NurseExists(int id)
        {
            return db.Nurses.Count(e => e.NurseID == id) > 0;
        }
    }
}