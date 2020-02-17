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
using SubirWebAPI.Data;
using SubirWebAPI.Models;

namespace SubirWebAPI.Controllers
{
    public class ObrasController : ApiController
    {
        private ContextoVolumen db = new ContextoVolumen();

        // GET: api/Obras
        public IQueryable<Obra> GetObras()
        {
            return db.Obras;
        }

        // GET: api/Obras/5
        [ResponseType(typeof(Obra))]
        public IHttpActionResult GetObra(int id)
        {
            Obra obra = db.Obras.Find(id);
            if (obra == null)
            {
                return NotFound();
            }

            return Ok(obra);
        }

        // PUT: api/Obras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutObra(int id, Obra obra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != obra.IdLibro)
            {
                return BadRequest();
            }

            db.Entry(obra).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObraExists(id))
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

        // POST: api/Obras
        [ResponseType(typeof(Obra))]
        public IHttpActionResult PostObra(Obra obra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Obras.Add(obra);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ObraExists(obra.IdLibro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = obra.IdLibro }, obra);
        }

        // DELETE: api/Obras/5
        [ResponseType(typeof(Obra))]
        public IHttpActionResult DeleteObra(int id)
        {
            Obra obra = db.Obras.Find(id);
            if (obra == null)
            {
                return NotFound();
            }

            db.Obras.Remove(obra);
            db.SaveChanges();

            return Ok(obra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObraExists(int id)
        {
            return db.Obras.Count(e => e.IdLibro == id) > 0;
        }
    }
}