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
    public class ActivitatsDemanadesController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/ActivitatsDemanades
        public IQueryable<ActivitatsDemanades> GetActivitatsDemanades()
        {
            return db.ActivitatsDemanades;
        }

        // GET: api/ActivitatsDemanades/5
        [ResponseType(typeof(ActivitatsDemanades))]
        public IHttpActionResult GetActivitatsDemanades(int id)
        {
            ActivitatsDemanades activitatsDemanades = db.ActivitatsDemanades.Find(id);
            if (activitatsDemanades == null)
            {
                return NotFound();
            }

            return Ok(activitatsDemanades);
        }

        // PUT: api/ActivitatsDemanades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivitatsDemanades(int id, ActivitatsDemanades activitatsDemanades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activitatsDemanades.id)
            {
                return BadRequest();
            }

            db.Entry(activitatsDemanades).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivitatsDemanadesExists(id))
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

        // POST: api/ActivitatsDemanades
        [ResponseType(typeof(ActivitatsDemanades))]
        public IHttpActionResult PostActivitatsDemanades(ActivitatsDemanades activitatsDemanades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActivitatsDemanades.Add(activitatsDemanades);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activitatsDemanades.id }, activitatsDemanades);
        }

        // DELETE: api/ActivitatsDemanades/5
        [ResponseType(typeof(ActivitatsDemanades))]
        public IHttpActionResult DeleteActivitatsDemanades(int id)
        {
            ActivitatsDemanades activitatsDemanades = db.ActivitatsDemanades.Find(id);
            if (activitatsDemanades == null)
            {
                return NotFound();
            }

            db.ActivitatsDemanades.Remove(activitatsDemanades);
            db.SaveChanges();

            return Ok(activitatsDemanades);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivitatsDemanadesExists(int id)
        {
            return db.ActivitatsDemanades.Count(e => e.id == id) > 0;
        }
    }
}