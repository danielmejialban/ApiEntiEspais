using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiEntiEspais;

namespace ApiEntiEspais.Controllers
{
    //CONTROL DE ERROR AÑADIDO
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
            String mensaje = "";
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
            catch (DbUpdateConcurrencyException ex)
            {
                //Modificamos nuestra Exception con nuestro método de la clase estatica Utilidades para 
                //tener feedback con el usuario y que este sepa cuál es el error;
                SqlException sqlException = (SqlException)ex.InnerException.InnerException;
                mensaje = Utilidades.Utilidades.MensajeError(sqlException);

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sexes
        [ResponseType(typeof(Sexe))]
        public IHttpActionResult PostSexe(Sexe sexe)
        {
            String mensaje = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sexe.Add(sexe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Modificamos nuestra Exception con nuestro método de la clase estatica Utilidades para 
                //tener feedback con el usuario y que este sepa cuál es el error;
                SqlException sqlException = (SqlException)ex.InnerException.InnerException;
                mensaje = Utilidades.Utilidades.MensajeError(sqlException);

            }
            return BadRequest(mensaje);
        }

        // DELETE: api/Sexes/5
        [ResponseType(typeof(Sexe))]
        public IHttpActionResult DeleteSexe(int id)
        {
            String mensaje = "";
            Sexe sexe = db.Sexe.Find(id);
            if (sexe == null)
            {
                return NotFound();
            }

            db.Sexe.Remove(sexe);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Modificamos nuestra Exception con nuestro método de la clase estatica Utilidades para 
                //tener feedback con el usuario y que este sepa cuál es el error;
                SqlException sqlException = (SqlException)ex.InnerException.InnerException;
                mensaje = Utilidades.Utilidades.MensajeError(sqlException);

            }
            return BadRequest(mensaje);
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