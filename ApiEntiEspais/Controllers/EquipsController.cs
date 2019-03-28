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
    public class EquipsController : ApiController
    {
        private EntiespaisEntities1 db = new EntiespaisEntities1();

        // GET: api/Equips
        public IQueryable<Equip> GetEquip()
        {
            return db.Equip;
        }

        // GET: api/Equips/5
        [ResponseType(typeof(Equip))]
        public IHttpActionResult GetEquip(int id)
        {
            Equip equip = db.Equip.Find(id);
            if (equip == null)
            {
                return NotFound();
            }

            return Ok(equip);
        }

        // PUT: api/Equips/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEquip(int id, Equip equip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equip.id)
            {
                return BadRequest();
            }

            db.Entry(equip).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipExists(id))
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

        // POST: api/Equips
        [ResponseType(typeof(Equip))]
        public IHttpActionResult PostEquip(Equip equip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Equip.Add(equip);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equip.id }, equip);
        }

        // DELETE: api/Equips/5
        [ResponseType(typeof(Equip))]
        public IHttpActionResult DeleteEquip(int id)
        {
            Equip equip = db.Equip.Find(id);
            if (equip == null)
            {
                return NotFound();
            }

            db.Equip.Remove(equip);
            db.SaveChanges();

            return Ok(equip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipExists(int id)
        {
            return db.Equip.Count(e => e.id == id) > 0;
        }
    }
}