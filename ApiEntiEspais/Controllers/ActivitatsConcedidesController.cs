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
    //CONTROL ERRORES AÑADIDOS.
    public class ActivitatsConcedidesController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/ActivitatsConcedides
        public IQueryable<ActivitatsConcedides> GetActivitatsConcedides()
        {
            return db.ActivitatsConcedides;
        }

        // GET: api/ActivitatsConcedides/5
        [ResponseType(typeof(ActivitatsConcedides))]
        public IHttpActionResult GetActivitatsConcedides(int id)
        {
            ActivitatsConcedides activitatsConcedides = db.ActivitatsConcedides.Find(id);
            if (activitatsConcedides == null)
            {
                return NotFound();
            }

            return Ok(activitatsConcedides);
        }

        // PUT: api/ActivitatsConcedides/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivitatsConcedides(int id, ActivitatsConcedides activitatsConcedides)
        {
            String mensaje = "";

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activitatsConcedides.id)
            {
                return BadRequest();
            }

            db.Entry(activitatsConcedides).State = EntityState.Modified;

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

        // POST: api/ActivitatsConcedides
        [ResponseType(typeof(ActivitatsConcedides))]
        public IHttpActionResult PostActivitatsConcedides(ActivitatsConcedides activitatsConcedides)
        {
            String mensaje = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActivitatsConcedides.Add(activitatsConcedides);
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

        // DELETE: api/ActivitatsConcedides/5
        [ResponseType(typeof(ActivitatsConcedides))]
        public IHttpActionResult DeleteActivitatsConcedides(int id)
        {
            String mensaje = "";
            ActivitatsConcedides activitatsConcedides = db.ActivitatsConcedides.Find(id);
            if (activitatsConcedides == null)
            {
                return NotFound();
            }

            db.ActivitatsConcedides.Remove(activitatsConcedides);

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

        private bool ActivitatsConcedidesExists(int id)
        {
            return db.ActivitatsConcedides.Count(e => e.id == id) > 0;
        }
    }
}