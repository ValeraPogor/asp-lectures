using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feedback.Models;

namespace Feedback.Controllers
{
    public class AddFeedbackController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(FeedbackModel feedback)
        {
            using (var entites = new FeedbackDBEntities())
            {

                var info = new Feedbacks()
                {
                    UserName = feedback.UserName,
                    Feedback = feedback.Feedback
                };
                entites.Feedbacks.Add(info);
                entites.SaveChanges();
            }
            return View();
        }
    }
}