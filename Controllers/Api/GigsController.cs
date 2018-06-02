using CourseProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourseProject.Controllers.Api
{   [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext db;

        public GigsController()
        {
            db = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel (int id)
        {
            var Artist = User.Identity.GetUserId();

            var gig = db.Gigs.Single(m => m.id == id&&m.ArtistID==Artist);

            if (gig.IsCanceled)
            {

                return NotFound();

            }

            gig.IsCanceled = true;

            db.SaveChanges();

            return Ok();
        }
    }
}
