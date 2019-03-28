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
    public class EsportsController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Esports
        public IQueryable<Esport> GetEsport()
        {
            return db.Esport;
        }

        // GET: api/Esports/5
        [ResponseType(typeof(Esport))]
        public IHttpActionResult GetEsport(int id)
        {
            Esport esport = db.Esport.Find(id);
            if (esport == null)
            {
                return NotFound();
            }

            return Ok(esport);
        }

        // PUT: api/Esports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEsport(int id, Esport esport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != esport.id)
            {
                return BadRequest();
            }

            db.Entry(esport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EsportExists(id))
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

        // POST: api/Esports
        [ResponseType(typeof(Esport))]
        public IHttpActionResult PostEsport(Esport esport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Esport.Add(esport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = esport.id }, esport);
        }

        // DELETE: api/Esports/5
        [ResponseType(typeof(Esport))]
        public IHttpActionResult DeleteEsport(int id)
        {
            Esport esport = db.Esport.Find(id);
            if (esport == null)
            {
                return NotFound();
            }

            db.Esport.Remove(esport);
            db.SaveChanges();

            return Ok(esport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EsportExists(int id)
        {
            return db.Esport.Count(e => e.id == id) > 0;
        }
    }
}