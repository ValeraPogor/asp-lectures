using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feedback.Models
{
    public class FeedbackModel
    {
        //private Guid Id { get; set; }

        //public FeedbackModel()
        //{
        //    Id = Guid.NewGuid();
        //}

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Feedback")]
        public string Feedback { get; set; }
    }
}