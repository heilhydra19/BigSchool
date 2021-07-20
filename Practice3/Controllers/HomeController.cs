using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Practice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var upcommingCourse = db.Courses.Where(p => p.DateTime > DateTime.Now).OrderBy(p => p.DateTime).ToList();

            var userID = User.Identity.GetUserId();
            foreach(Course i in upcommingCourse)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(i.LecturerId);
                i.Name = user.Name;
                if(userID != null)
                {
                    i.isLogin = true;
                    Attendance findAtendance = db.Attendances.FirstOrDefault(p => p.CourseId == i.Id && p.Attendee == userID);
                    if(findAtendance == null)
                    {
                        i.isShowGoing = true;
                    }
                    Following findFollow = db.Followings.FirstOrDefault(p => p.FollowerId == userID && p.FolloweeId == i.LecturerId);
                    if(findFollow == null)
                    {
                        i.isShowFollow = true;
                    }
                }
            }
            return View(upcommingCourse);
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