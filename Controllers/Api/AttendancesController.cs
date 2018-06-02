using CourseProject.Dtos;
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
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext DB;

        public AttendancesController()
        {
            DB = new ApplicationDbContext();

        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        { var userID = User.Identity.GetUserId();

            if(DB.Attendances.Any(a=>a.AttendeeID == userID && a.GigID == dto.GigID))
            {

                return BadRequest("The attendance is already exists");

            }
            var Attendance = new Attendance
            {
                GigID = dto.GigID,
                AttendeeID = userID


            };

            DB.Attendances.Add(Attendance);
            DB.SaveChanges();

            return Ok();
        }

    }
}
