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
using PSAWebAPI.Models;

namespace PSAWebAPI.Controllers
{
    public class SubDivisionsController : ApiController
    {
        private PSAWebAPIContext db = new PSAWebAPIContext();

        // GET: api/SubDivisions
        public IQueryable<SubDivision> GetSubDivisions()
        {
            return db.SubDivisions;
        }

        // GET: api/SubDivisions/5
        [ResponseType(typeof(SubDivision))]
        public IHttpActionResult GetSubDivision(int id)
        {
            SubDivision subDivision = db.SubDivisions.Find(id);
            if (subDivision == null)
            {
                return NotFound();
            }

            return Ok(subDivision);
        }

        // PUT: api/SubDivisions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubDivision(int id, SubDivision subDivision)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subDivision.Id)
            {
                return BadRequest();
            }

            db.Entry(subDivision).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubDivisionExists(id))
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

        // POST: api/SubDivisions
        [ResponseType(typeof(SubDivision))]
        public IHttpActionResult PostSubDivision(SubDivision subDivision)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubDivisions.Add(subDivision);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subDivision.Id }, subDivision);
        }

        // DELETE: api/SubDivisions/5
        [ResponseType(typeof(SubDivision))]
        public IHttpActionResult DeleteSubDivision(int id)
        {
            SubDivision subDivision = db.SubDivisions.Find(id);
            if (subDivision == null)
            {
                return NotFound();
            }

            db.SubDivisions.Remove(subDivision);
            db.SaveChanges();

            return Ok(subDivision);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubDivisionExists(int id)
        {
            return db.SubDivisions.Count(e => e.Id == id) > 0;
        }
    }
}