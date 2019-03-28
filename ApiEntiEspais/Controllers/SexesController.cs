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
    public class SexesController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Sexes
        public IQueryable<Sexe> GetSexe()
        {
            return db.Sexe;
        }

        // GET: api/Sexes/5
        [ResponseType(typeof(Sexe))]
        public IHttpActionResult GetSexe(int id)
        {
            Sexe sexe = db.Sexe.Find(id);
            if (sexe == null)
            {
                return NotFound();
            }

            return Ok(sexe);
        }

        // PUT: api/Sexes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSexe(int id, Sexe sexe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sexe.id)
            {
                return BadRequest();
            }

            db.Entry(sexe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SexeExists(id))
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

        // POST: api/Sexes
        [ResponseType(typeof(Sexe))]
        public IHttpActionResult PostSexe(Sexe sexe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sexe.Add(sexe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sexe.id }, sexe);
        }

        // DELETE: api/Sexes/5
        [ResponseType(typeof(Sexe))]
        public IHttpActionResult DeleteSexe(int id)
        {
            Sexe sexe = db.Sexe.Find(id);
            if (sexe == null)
            {
                return NotFound();
            }

            db.Sexe.Remove(sexe);
            db.SaveChanges();

            return Ok(sexe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SexeExists(int id)
        {
            return db.Sexe.Count(e => e.id == id) > 0;
        }
    }
}