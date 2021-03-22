using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ThingsAndThinkers.Models;

namespace ThingsAndThinkers.HotstaModels
{
    public class PosterTBL
    {
        public string PosterId { get; set; }

        public ApplicationUser Thinker { get; set; }

        [Required]
        [DisplayName("Name Field")]
        public string PosterName { get; set; } /*= "Bruno";*/

        //[Required]
        //[DisplayName("Image Name")]
        public string ImageName { get; set; } /*= $"{DateTime.Now.ToUniversalTime()}Demo.jpg";*/

        public HttpPostedFileBase ImageFile { get; set; }

        public string DatePosted { get; set; }

        public string Caption { get; set; }

        //public PosterTBL()//Constructor
        //{
        //    PosterName = "Bruno";
        //    ImageName = "Demo.jpg";

        //}

    }
}