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
    public class TelefonsController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Telefons
        public IQueryable<Telefon> GetTelefon()
        {
            return db.Telefon;
        }

        // GET: api/Telefons/5
        [ResponseType(typeof(Telefon))]
        public IHttpActionResult GetTelefon(int id)
        {
            Telefon telefon = db.Telefon.Find(id);
            if (telefon == null)
            {
                return NotFound();
            }

            return Ok(telefon);
        }

        // PUT: api/Telefons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelefon(int id, Telefon telefon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefon.id)
            {
                return BadRequest();
            }

            db.Entry(telefon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonExists(id))
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

        // POST: api/Telefons
        [ResponseType(typeof(Telefon))]
        public IHttpActionResult PostTelefon(Telefon telefon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telefon.Add(telefon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telefon.id }, telefon);
        }

        // DELETE: api/Telefons/5
        [ResponseType(typeof(Telefon))]
        public IHttpActionResult DeleteTelefon(int id)
        {
            Telefon telefon = db.Telefon.Find(id);
            if (telefon == null)
            {
                return NotFound();
            }

            db.Telefon.Remove(telefon);
            db.SaveChanges();

            return Ok(telefon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefonExists(int id)
        {
            return db.Telefon.Count(e => e.id == id) > 0;
        }
    }
}