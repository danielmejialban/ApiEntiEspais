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
    public class Horari_Instal_lacioController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Horari_Instal_lacio
        public IQueryable<Horari_Instal_lacio> GetHorari_Instal_lacio()
        {
            return db.Horari_Instal_lacio;
        }

        // GET: api/Horari_Instal_lacio/5
        [ResponseType(typeof(Horari_Instal_lacio))]
        public IHttpActionResult GetHorari_Instal_lacio(int id)
        {
            Horari_Instal_lacio horari_Instal_lacio = db.Horari_Instal_lacio.Find(id);
            if (horari_Instal_lacio == null)
            {
                return NotFound();
            }

            return Ok(horari_Instal_lacio);
        }

        // PUT: api/Horari_Instal_lacio/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHorari_Instal_lacio(int id, Horari_Instal_lacio horari_Instal_lacio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != horari_Instal_lacio.id)
            {
                return BadRequest();
            }

            db.Entry(horari_Instal_lacio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Horari_Instal_lacioExists(id))
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

        // POST: api/Horari_Instal_lacio
        [ResponseType(typeof(Horari_Instal_lacio))]
        public IHttpActionResult PostHorari_Instal_lacio(Horari_Instal_lacio horari_Instal_lacio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Horari_Instal_lacio.Add(horari_Instal_lacio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = horari_Instal_lacio.id }, horari_Instal_lacio);
        }

        // DELETE: api/Horari_Instal_lacio/5
        [ResponseType(typeof(Horari_Instal_lacio))]
        public IHttpActionResult DeleteHorari_Instal_lacio(int id)
        {
            Horari_Instal_lacio horari_Instal_lacio = db.Horari_Instal_lacio.Find(id);
            if (horari_Instal_lacio == null)
            {
                return NotFound();
            }

            db.Horari_Instal_lacio.Remove(horari_Instal_lacio);
            db.SaveChanges();

            return Ok(horari_Instal_lacio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Horari_Instal_lacioExists(int id)
        {
            return db.Horari_Instal_lacio.Count(e => e.id == id) > 0;
        }
    }
}