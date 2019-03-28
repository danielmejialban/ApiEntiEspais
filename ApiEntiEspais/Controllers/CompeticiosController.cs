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
    public class CompeticiosController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Competicios
        public IQueryable<Competicio> GetCompeticio()
        {
            return db.Competicio;
        }

        // GET: api/Competicios/5
        [ResponseType(typeof(Competicio))]
        public IHttpActionResult GetCompeticio(int id)
        {
            Competicio competicio = db.Competicio.Find(id);
            if (competicio == null)
            {
                return NotFound();
            }

            return Ok(competicio);
        }

        // PUT: api/Competicios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompeticio(int id, Competicio competicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != competicio.id)
            {
                return BadRequest();
            }

            db.Entry(competicio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompeticioExists(id))
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

        // POST: api/Competicios
        [ResponseType(typeof(Competicio))]
        public IHttpActionResult PostCompeticio(Competicio competicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Competicio.Add(competicio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = competicio.id }, competicio);
        }

        // DELETE: api/Competicios/5
        [ResponseType(typeof(Competicio))]
        public IHttpActionResult DeleteCompeticio(int id)
        {
            Competicio competicio = db.Competicio.Find(id);
            if (competicio == null)
            {
                return NotFound();
            }

            db.Competicio.Remove(competicio);
            db.SaveChanges();

            return Ok(competicio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompeticioExists(int id)
        {
            return db.Competicio.Count(e => e.id == id) > 0;
        }
    }
}