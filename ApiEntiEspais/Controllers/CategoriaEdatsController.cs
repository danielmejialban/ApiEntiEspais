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
    public class CategoriaEdatsController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/CategoriaEdats
        public IQueryable<CategoriaEdat> GetCategoriaEdat()
        {
            return db.CategoriaEdat;
        }

        // GET: api/CategoriaEdats/5
        [ResponseType(typeof(CategoriaEdat))]
        public IHttpActionResult GetCategoriaEdat(int id)
        {
            CategoriaEdat categoriaEdat = db.CategoriaEdat.Find(id);
            if (categoriaEdat == null)
            {
                return NotFound();
            }

            return Ok(categoriaEdat);
        }

        // PUT: api/CategoriaEdats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoriaEdat(int id, CategoriaEdat categoriaEdat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaEdat.id)
            {
                return BadRequest();
            }

            db.Entry(categoriaEdat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaEdatExists(id))
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

        // POST: api/CategoriaEdats
        [ResponseType(typeof(CategoriaEdat))]
        public IHttpActionResult PostCategoriaEdat(CategoriaEdat categoriaEdat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoriaEdat.Add(categoriaEdat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoriaEdat.id }, categoriaEdat);
        }

        // DELETE: api/CategoriaEdats/5
        [ResponseType(typeof(CategoriaEdat))]
        public IHttpActionResult DeleteCategoriaEdat(int id)
        {
            CategoriaEdat categoriaEdat = db.CategoriaEdat.Find(id);
            if (categoriaEdat == null)
            {
                return NotFound();
            }

            db.CategoriaEdat.Remove(categoriaEdat);
            db.SaveChanges();

            return Ok(categoriaEdat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaEdatExists(int id)
        {
            return db.CategoriaEdat.Count(e => e.id == id) > 0;
        }
    }
}