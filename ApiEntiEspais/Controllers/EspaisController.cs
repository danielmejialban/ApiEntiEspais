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
    public class EspaisController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Espais
        public IQueryable<Espai> GetEspai()
        {
            return db.Espai;
        }

        // GET: api/Espais/5
        [ResponseType(typeof(Espai))]
        public IHttpActionResult GetEspai(int id)
        {
            Espai espai = db.Espai.Find(id);
            if (espai == null)
            {
                return NotFound();
            }

            return Ok(espai);
        }

        // PUT: api/Espais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEspai(int id, Espai espai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != espai.id)
            {
                return BadRequest();
            }

            db.Entry(espai).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspaiExists(id))
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

        // POST: api/Espais
        [ResponseType(typeof(Espai))]
        public IHttpActionResult PostEspai(Espai espai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Espai.Add(espai);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = espai.id }, espai);
        }

        // DELETE: api/Espais/5
        [ResponseType(typeof(Espai))]
        public IHttpActionResult DeleteEspai(int id)
        {
            Espai espai = db.Espai.Find(id);
            if (espai == null)
            {
                return NotFound();
            }

            db.Espai.Remove(espai);
            db.SaveChanges();

            return Ok(espai);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EspaiExists(int id)
        {
            return db.Espai.Count(e => e.id == id) > 0;
        }
    }
}