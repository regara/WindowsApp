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
    public class LotsController : ApiController
    {
        private PSAWebAPIContext db = new PSAWebAPIContext();

        // GET: api/Lots
        public IQueryable<Lot> GetLots()
        {
            return db.Lots;
        }

        // GET: api/Lots/5
        [ResponseType(typeof(Lot))]
        public IHttpActionResult GetLot(int id)
        {
            Lot lot = db.Lots.Find(id);
            if (lot == null)
            {
                return NotFound();
            }

            return Ok(lot);
        }

        // PUT: api/Lots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLot(int id, Lot lot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lot.Id)
            {
                return BadRequest();
            }

            db.Entry(lot).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LotExists(id))
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

        // POST: api/Lots
        [ResponseType(typeof(Lot))]
        public IHttpActionResult PostLot(Lot lot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lots.Add(lot);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lot.Id }, lot);
        }

        // DELETE: api/Lots/5
        [ResponseType(typeof(Lot))]
        public IHttpActionResult DeleteLot(int id)
        {
            Lot lot = db.Lots.Find(id);
            if (lot == null)
            {
                return NotFound();
            }

            db.Lots.Remove(lot);
            db.SaveChanges();

            return Ok(lot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LotExists(int id)
        {
            return db.Lots.Count(e => e.Id == id) > 0;
        }
    }
}