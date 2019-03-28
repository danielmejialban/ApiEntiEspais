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
    public class Horari_activitatController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Horari_activitat
        public IQueryable<Horari_activitat> GetHorari_activitat()
        {
            return db.Horari_activitat;
        }

        // GET: api/Horari_activitat/5
        [ResponseType(typeof(Horari_activitat))]
        public IHttpActionResult GetHorari_activitat(int id)
        {
            Horari_activitat horari_activitat = db.Horari_activitat.Find(id);
            if (horari_activitat == null)
            {
                return NotFound();
            }

            return Ok(horari_activitat);
        }

        // PUT: api/Horari_activitat/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHorari_activitat(int id, Horari_activitat horari_activitat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horari_activitat.id)
            {
                return BadRequest();
            }

            db.Entry(horari_activitat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Horari_activitatExists(id))
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

        // POST: api/Horari_activitat
        [ResponseType(typeof(Horari_activitat))]
        public IHttpActionResult PostHorari_activitat(Horari_activitat horari_activitat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horari_activitat.Add(horari_activitat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = horari_activitat.id }, horari_activitat);
        }

        // DELETE: api/Horari_activitat/5
        [ResponseType(typeof(Horari_activitat))]
        public IHttpActionResult DeleteHorari_activitat(int id)
        {
            Horari_activitat horari_activitat = db.Horari_activitat.Find(id);
            if (horari_activitat == null)
            {
                return NotFound();
            }

            db.Horari_activitat.Remove(horari_activitat);
            db.SaveChanges();

            return Ok(horari_activitat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Horari_activitatExists(int id)
        {
            return db.Horari_activitat.Count(e => e.id == id) > 0;
        }
    }
}