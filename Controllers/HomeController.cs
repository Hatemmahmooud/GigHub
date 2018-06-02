using CourseProject.Models;
using System.Data.Entity;
using CourseProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext DB;
        public HomeController()
        {
            DB = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            Session["User"] = User.Identity.GetUserId();

            var upcomingGigs = DB.Gigs.
                Include(m=>m.Artist).
                Include(m=>m.genre).
                Where(m=>m.DateTime>DateTime.Now&&!m.IsCanceled);


            var viewModel = new GigsViewModel()
            {
                Gigs=upcomingGigs,
                Authenticated=User.Identity.IsAuthenticated,
                Heading="Upcoming gigs"

            };
            return View("Gigs",viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}