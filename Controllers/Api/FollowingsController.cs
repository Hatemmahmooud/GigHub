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
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext DB;

        public FollowingsController()
        {
            DB = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow (FollowingDto Dto)
        { var follower = User.Identity.GetUserId();

             if(DB.Followings.Any(m=>m.FolloweeID ==Dto.FolloweeID && m.FollowerID ==follower))
            {

                return BadRequest("Already Followed !");

            }            

            var Follow = new Following()
            {
                FollowerID=follower,
                FolloweeID=Dto.FolloweeID


            };

            DB.Followings.Add(Follow);
            DB.SaveChanges();

            return Ok();

        }




    }
}
