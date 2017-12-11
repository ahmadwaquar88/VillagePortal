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
using VillagePortal.Models;

namespace VillagePortal.Controllers
{
    
    public class VillagesController : ApiController
    {
        private VillagePortalContext db = new VillagePortalContext();

        // GET: api/Villages
        public IQueryable<Village> GetVillages()
        {
            return db.Villages;
            //sasasas
        }

        // GET: api/Villages/5
        [ResponseType(typeof(Village))]
        public IHttpActionResult GetVillage(int id)
        {
            Village village=null;//= db.Villages.Find(id);
            if (village == null)
            {
                village = new Village
                {
                    NumberOfMosque = 1,
                    NumberOfSchool = 2,
                    NumberOfTemple = 0,
                    VillageDescription = "It is situated alongside the road or raniganj to Supaul",
                    VillageID = 1,
                    VillageName = "Manullah Patty",
                };
            }

            return Ok(village);
        }

        // PUT: api/Villages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVillage(int id, Village village)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != village.VillageID)
            {
                return BadRequest();
            }

            db.Entry(village).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VillageExists(id))
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

        // POST: api/Villages
        [ResponseType(typeof(Village))]
        public IHttpActionResult PostVillage(Village village)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Villages.Add(village);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = village.VillageID }, village);
        }

        // DELETE: api/Villages/5
        [ResponseType(typeof(Village))]
        public IHttpActionResult DeleteVillage(int id)
        {
            Village village = db.Villages.Find(id);
            if (village == null)
            {
                return NotFound();
            }

            db.Villages.Remove(village);
            db.SaveChanges();

            return Ok(village);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VillageExists(int id)
        {
            return db.Villages.Count(e => e.VillageID == id) > 0;
        }
    }
}