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
    public class UsuarisController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Usuaris
        public IQueryable<Usuaris> GetUsuaris()
        {
            return db.Usuaris;
        }

        // GET: api/Usuaris/5
        [ResponseType(typeof(Usuaris))]
        public IHttpActionResult GetUsuaris(int id)
        {
            Usuaris usuaris = db.Usuaris.Find(id);
            if (usuaris == null)
            {
                return NotFound();
            }

            return Ok(usuaris);
        }

        // PUT: api/Usuaris/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuaris(int id, Usuaris usuaris)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuaris.id)
            {
                return BadRequest();
            }

            db.Entry(usuaris).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarisExists(id))
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

        // POST: api/Usuaris
        [ResponseType(typeof(Usuaris))]
        public IHttpActionResult PostUsuaris(Usuaris usuaris)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuaris.Add(usuaris);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuaris.id }, usuaris);
        }

        // DELETE: api/Usuaris/5
        [ResponseType(typeof(Usuaris))]
        public IHttpActionResult DeleteUsuaris(int id)
        {
            Usuaris usuaris = db.Usuaris.Find(id);
            if (usuaris == null)
            {
                return NotFound();
            }

            db.Usuaris.Remove(usuaris);
            db.SaveChanges();

            return Ok(usuaris);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarisExists(int id)
        {
            return db.Usuaris.Count(e => e.id == id) > 0;
        }
    }
}