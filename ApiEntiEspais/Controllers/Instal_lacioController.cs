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
    public class Instal_lacioController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Instal_lacio
        public IQueryable<Instal_lacio> GetInstal_lacio()
        {
            return db.Instal_lacio;
        }

        // GET: api/Instal_lacio/5
        [ResponseType(typeof(Instal_lacio))]
        public IHttpActionResult GetInstal_lacio(int id)
        {
            Instal_lacio instal_lacio = db.Instal_lacio.Find(id);
            if (instal_lacio == null)
            {
                return NotFound();
            }

            return Ok(instal_lacio);
        }

        // PUT: api/Instal_lacio/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInstal_lacio(int id, Instal_lacio instal_lacio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instal_lacio.id)
            {
                return BadRequest();
            }

            db.Entry(instal_lacio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Instal_lacioExists(id))
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

        // POST: api/Instal_lacio
        [ResponseType(typeof(Instal_lacio))]
        public IHttpActionResult PostInstal_lacio(Instal_lacio instal_lacio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Instal_lacio.Add(instal_lacio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = instal_lacio.id }, instal_lacio);
        }

        // DELETE: api/Instal_lacio/5
        [ResponseType(typeof(Instal_lacio))]
        public IHttpActionResult DeleteInstal_lacio(int id)
        {
            Instal_lacio instal_lacio = db.Instal_lacio.Find(id);
            if (instal_lacio == null)
            {
                return NotFound();
            }

            db.Instal_lacio.Remove(instal_lacio);
            db.SaveChanges();

            return Ok(instal_lacio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Instal_lacioExists(int id)
        {
            return db.Instal_lacio.Count(e => e.id == id) > 0;
        }
    }
}