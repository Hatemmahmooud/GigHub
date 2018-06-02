using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.ViewModels
{
    public class GigsViewModel
    {

        public IEnumerable<Gig> Gigs { get; set; }
        public bool Authenticated { get; set; }
        public string Heading { get; set; }
    }
}