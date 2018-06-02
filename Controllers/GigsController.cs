using CourseProject.Models;
using CourseProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseProject.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext DB;
     

        public  GigsController()
        {
           DB = new ApplicationDbContext();
           
        }
        [Authorize]
        public ActionResult Attending()
        {
            var Attendee = User.Identity.GetUserId();

            var Gigs=  DB.Attendances
                .Where(a => a.AttendeeID == Attendee)
                .Select(a => a.gig)
                .Include(g => g.Artist)
                .Include(g => g.genre)
                .ToList();

            var ViewModel = new GigsViewModel()
            {
                Gigs = Gigs,
                Authenticated = User.Identity.IsAuthenticated,
                Heading ="Gigs i'm attending"
         

            };


            return View("Gigs",ViewModel);
        }

        [Authorize]
        public ActionResult Mine() {
            var artist = User.Identity.GetUserId();
            var gigs  = DB.Gigs
                .Where(g => g.ArtistID == artist && g.DateTime > DateTime.Now && g.IsCanceled==false)
                .Include(g=>g.genre)
                .ToList();

            return View(gigs);
        }
      
        [Authorize]
        public ActionResult Update(int gigid)
        {  
            var Artist = User.Identity.GetUserId();
            var gig = DB.Gigs.Single(g => g.id == gigid && g.ArtistID==Artist);


            GigFormViewModel model = new GigFormViewModel()
            {   
                id =gigid,
                Genres = DB.Genres.ToList(),
                Date=gig.DateTime.ToString("d MMM yyyy"),
                Time=gig.DateTime.ToString("HH:mm"),
                Genre=gig.GenreID,
                Venue=gig.Venue,
                Heading="Edit a gig "

                

            };

            return View("GigForm",model);


        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        public ActionResult Update(GigFormViewModel gig)
        {
            if (!ModelState.IsValid)
            {

                gig.Genres = DB.Genres.ToList();

                return View("GigForm", gig);

            }
           var artist = User.Identity.GetUserId();
           var Gig= DB.Gigs.Single(g => g.id == gig.id &&g.ArtistID==artist);
            Gig.GenreID = gig.Genre;
            Gig.Venue = gig.Venue;
            Gig.DateTime = gig.GetDateTime();


            DB.SaveChanges();


            return RedirectToAction("Mine","Gigs");

            
        }


        [Authorize]
        public ActionResult Create()
        {
            
            GigFormViewModel model = new GigFormViewModel()
            {
                Genres = DB.Genres.ToList(),
                Heading="Add a gig"

            };

            return View("GigForm",model);
           

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel Model) {


            if (!ModelState.IsValid)
            {
                
                Model.Genres = DB.Genres.ToList();

                return View("GigForm", Model);
                
            }

            var gig = new Gig()
            {
                ArtistID= User.Identity.GetUserId(),
                GenreID=Model.Genre,
                DateTime=Model.GetDateTime(),
                Venue=Model.Venue
           
            };

            DB.Gigs.Add(gig);
            DB.SaveChanges();


            return RedirectToAction("Mine","Gigs");

        }

           
    }
}