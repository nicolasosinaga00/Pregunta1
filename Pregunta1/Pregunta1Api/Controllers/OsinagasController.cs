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
using Pregunta1Api.Models;

namespace Pregunta1Api.Controllers
{
    public class OsinagasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Osinagas
        [Authorize]
        public IQueryable<Osinaga> GetOsinagas()
        {
            return db.Osinagas;
        }

        // GET: api/Osinagas/5
        [Authorize]
        [ResponseType(typeof(Osinaga))]
        public IHttpActionResult GetOsinaga(int id)
        {
            Osinaga osinaga = db.Osinagas.Find(id);
            if (osinaga == null)
            {
                return NotFound();
            }

            return Ok(osinaga);
        }

        // PUT: api/Osinagas/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOsinaga(int id, Osinaga osinaga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != osinaga.OsinagaID)
            {
                return BadRequest();
            }

            db.Entry(osinaga).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsinagaExists(id))
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

        // POST: api/Osinagas
        [Authorize]
        [ResponseType(typeof(Osinaga))]
        public IHttpActionResult PostOsinaga(Osinaga osinaga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Osinagas.Add(osinaga);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = osinaga.OsinagaID }, osinaga);
        }

        // DELETE: api/Osinagas/5
        [Authorize]
        [ResponseType(typeof(Osinaga))]
        public IHttpActionResult DeleteOsinaga(int id)
        {
            Osinaga osinaga = db.Osinagas.Find(id);
            if (osinaga == null)
            {
                return NotFound();
            }

            db.Osinagas.Remove(osinaga);
            db.SaveChanges();

            return Ok(osinaga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OsinagaExists(int id)
        {
            return db.Osinagas.Count(e => e.OsinagaID == id) > 0;
        }
    }
}