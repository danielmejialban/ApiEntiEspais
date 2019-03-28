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
using ApiEntiEspais;

namespace ApiEntiEspais.Controllers
{
    public class ActivitatsConcedidesController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/ActivitatsConcedides
        public IQueryable<ActivitatsConcedides> GetActivitatsConcedides()
        {
            return db.ActivitatsConcedides;
        }

        // GET: api/ActivitatsConcedides/5
        [ResponseType(typeof(ActivitatsConcedides))]
        public IHttpActionResult GetActivitatsConcedides(int id)
        {
            ActivitatsConcedides activitatsConcedides = db.ActivitatsConcedides.Find(id);
            if (activitatsConcedides == null)
            {
                return NotFound();
            }

            return Ok(activitatsConcedides);
        }

        // PUT: api/ActivitatsConcedides/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivitatsConcedides(int id, ActivitatsConcedides activitatsConcedides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activitatsConcedides.id)
            {
                return BadRequest();
            }

            db.Entry(activitatsConcedides).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivitatsConcedidesExists(id))
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

        // POST: api/ActivitatsConcedides
        [ResponseType(typeof(ActivitatsConcedides))]
        public IHttpActionResult PostActivitatsConcedides(ActivitatsConcedides activitatsConcedides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActivitatsConcedides.Add(activitatsConcedides);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activitatsConcedides.id }, activitatsConcedides);
        }

        // DELETE: api/ActivitatsConcedides/5
        [ResponseType(typeof(ActivitatsConcedides))]
        public IHttpActionResult DeleteActivitatsConcedides(int id)
        {
            ActivitatsConcedides activitatsConcedides = db.ActivitatsConcedides.Find(id);
            if (activitatsConcedides == null)
            {
                return NotFound();
            }

            db.ActivitatsConcedides.Remove(activitatsConcedides);
            db.SaveChanges();

            return Ok(activitatsConcedides);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivitatsConcedidesExists(int id)
        {
            return db.ActivitatsConcedides.Count(e => e.id == id) > 0;
        }
    }
}