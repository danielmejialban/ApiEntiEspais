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
    public class DuradasController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Duradas
        public IQueryable<Durada> GetDurada()
        {
            return db.Durada;
        }

        // GET: api/Duradas/5
        [ResponseType(typeof(Durada))]
        public IHttpActionResult GetDurada(int id)
        {
            Durada durada = db.Durada.Find(id);
            if (durada == null)
            {
                return NotFound();
            }

            return Ok(durada);
        }

        // PUT: api/Duradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDurada(int id, Durada durada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != durada.id)
            {
                return BadRequest();
            }

            db.Entry(durada).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuradaExists(id))
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

        // POST: api/Duradas
        [ResponseType(typeof(Durada))]
        public IHttpActionResult PostDurada(Durada durada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Durada.Add(durada);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = durada.id }, durada);
        }

        // DELETE: api/Duradas/5
        [ResponseType(typeof(Durada))]
        public IHttpActionResult DeleteDurada(int id)
        {
            Durada durada = db.Durada.Find(id);
            if (durada == null)
            {
                return NotFound();
            }

            db.Durada.Remove(durada);
            db.SaveChanges();

            return Ok(durada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DuradaExists(int id)
        {
            return db.Durada.Count(e => e.id == id) > 0;
        }
    }
}