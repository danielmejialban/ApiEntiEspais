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
    public class HorarisController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Horaris
        public IQueryable<Horari> GetHorari()
        {
            return db.Horari;
        }

        // GET: api/Horaris/5
        [ResponseType(typeof(Horari))]
        public IHttpActionResult GetHorari(int id)
        {
            Horari horari = db.Horari.Find(id);
            if (horari == null)
            {
                return NotFound();
            }

            return Ok(horari);
        }

        // PUT: api/Horaris/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHorari(int id, Horari horari)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horari.id)
            {
                return BadRequest();
            }

            db.Entry(horari).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorariExists(id))
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

        // POST: api/Horaris
        [ResponseType(typeof(Horari))]
        public IHttpActionResult PostHorari(Horari horari)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horari.Add(horari);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = horari.id }, horari);
        }

        // DELETE: api/Horaris/5
        [ResponseType(typeof(Horari))]
        public IHttpActionResult DeleteHorari(int id)
        {
            Horari horari = db.Horari.Find(id);
            if (horari == null)
            {
                return NotFound();
            }

            db.Horari.Remove(horari);
            db.SaveChanges();

            return Ok(horari);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HorariExists(int id)
        {
            return db.Horari.Count(e => e.id == id) > 0;
        }
    }
}