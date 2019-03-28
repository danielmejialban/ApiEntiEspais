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
    public class EntitatsController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Entitats
        public IQueryable<Entitat> GetEntitat()
        {
            return db.Entitat;
        }

        // GET: api/Entitats/5
        [ResponseType(typeof(Entitat))]
        public IHttpActionResult GetEntitat(int id)
        {
            Entitat entitat = db.Entitat.Find(id);
            if (entitat == null)
            {
                return NotFound();
            }

            return Ok(entitat);
        }

        // PUT: api/Entitats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntitat(int id, Entitat entitat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entitat.id)
            {
                return BadRequest();
            }

            db.Entry(entitat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntitatExists(id))
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

        // POST: api/Entitats
        [ResponseType(typeof(Entitat))]
        public IHttpActionResult PostEntitat(Entitat entitat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entitat.Add(entitat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entitat.id }, entitat);
        }

        // DELETE: api/Entitats/5
        [ResponseType(typeof(Entitat))]
        public IHttpActionResult DeleteEntitat(int id)
        {
            Entitat entitat = db.Entitat.Find(id);
            if (entitat == null)
            {
                return NotFound();
            }

            db.Entitat.Remove(entitat);
            db.SaveChanges();

            return Ok(entitat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntitatExists(int id)
        {
            return db.Entitat.Count(e => e.id == id) > 0;
        }
    }
}