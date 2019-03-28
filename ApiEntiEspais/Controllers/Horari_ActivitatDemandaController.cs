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
    public class Horari_ActivitatDemandaController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Horari_ActivitatDemanda
        public IQueryable<Horari_ActivitatDemanda> GetHorari_ActivitatDemanda()
        {
            return db.Horari_ActivitatDemanda;
        }

        // GET: api/Horari_ActivitatDemanda/5
        [ResponseType(typeof(Horari_ActivitatDemanda))]
        public IHttpActionResult GetHorari_ActivitatDemanda(int id)
        {
            Horari_ActivitatDemanda horari_ActivitatDemanda = db.Horari_ActivitatDemanda.Find(id);
            if (horari_ActivitatDemanda == null)
            {
                return NotFound();
            }

            return Ok(horari_ActivitatDemanda);
        }

        // PUT: api/Horari_ActivitatDemanda/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHorari_ActivitatDemanda(int id, Horari_ActivitatDemanda horari_ActivitatDemanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horari_ActivitatDemanda.id)
            {
                return BadRequest();
            }

            db.Entry(horari_ActivitatDemanda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Horari_ActivitatDemandaExists(id))
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

        // POST: api/Horari_ActivitatDemanda
        [ResponseType(typeof(Horari_ActivitatDemanda))]
        public IHttpActionResult PostHorari_ActivitatDemanda(Horari_ActivitatDemanda horari_ActivitatDemanda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horari_ActivitatDemanda.Add(horari_ActivitatDemanda);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = horari_ActivitatDemanda.id }, horari_ActivitatDemanda);
        }

        // DELETE: api/Horari_ActivitatDemanda/5
        [ResponseType(typeof(Horari_ActivitatDemanda))]
        public IHttpActionResult DeleteHorari_ActivitatDemanda(int id)
        {
            Horari_ActivitatDemanda horari_ActivitatDemanda = db.Horari_ActivitatDemanda.Find(id);
            if (horari_ActivitatDemanda == null)
            {
                return NotFound();
            }

            db.Horari_ActivitatDemanda.Remove(horari_ActivitatDemanda);
            db.SaveChanges();

            return Ok(horari_ActivitatDemanda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Horari_ActivitatDemandaExists(int id)
        {
            return db.Horari_ActivitatDemanda.Count(e => e.id == id) > 0;
        }
    }
}