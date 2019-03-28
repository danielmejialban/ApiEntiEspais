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
    public class DiasController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Dias
        public IQueryable<Dia> GetDia()
        {
            return db.Dia;
        }

        // GET: api/Dias/5
        [ResponseType(typeof(Dia))]
        public IHttpActionResult GetDia(int id)
        {
            Dia dia = db.Dia.Find(id);
            if (dia == null)
            {
                return NotFound();
            }

            return Ok(dia);
        }

        // PUT: api/Dias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDia(int id, Dia dia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dia.id)
            {
                return BadRequest();
            }

            db.Entry(dia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaExists(id))
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

        // POST: api/Dias
        [ResponseType(typeof(Dia))]
        public IHttpActionResult PostDia(Dia dia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dia.Add(dia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dia.id }, dia);
        }

        // DELETE: api/Dias/5
        [ResponseType(typeof(Dia))]
        public IHttpActionResult DeleteDia(int id)
        {
            Dia dia = db.Dia.Find(id);
            if (dia == null)
            {
                return NotFound();
            }

            db.Dia.Remove(dia);
            db.SaveChanges();

            return Ok(dia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiaExists(int id)
        {
            return db.Dia.Count(e => e.id == id) > 0;
        }
    }
}