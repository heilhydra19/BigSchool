using Microsoft.AspNet.Identity;
using Practice3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice3.Controllers
{
    public class FollowingController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Follow(Following follow)
        {
            var userID = User.Identity.GetUserId();
            if(userID == null)
            {
                BadRequest("Login first!!");
            }
            if(userID == follow.FolloweeId)
            {
                BadRequest("Can't Follow Yourself!");
            }
            follow.FollowerId = userID;
            if (FollowingExists(follow))
            {
                db.Followings.Remove(db.Followings.SingleOrDefault(p => p.FollowerId == userID && p.FolloweeId == follow.FolloweeId));
                db.SaveChanges();
                return Ok("cancle");
            }
            db.Followings.Add(follow);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FollowingExists(follow))
                {
                    return BadRequest("Follower Exist!");
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        private bool FollowingExists(Following follow)
        {
            return db.Followings.Any(e => e.FollowerId == follow.FollowerId && e.FolloweeId == follow.FolloweeId);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
