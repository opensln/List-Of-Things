using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThingsAndThinkers.Models
{
    public class ThingTBL
    {
        [Key]
        public int ThingID { get; set; }

        public ApplicationUser Thinker { get; set; } //This will be sent to the screen via ThinkerId.Name

        [Required]
        public string ThinkerId { get; set; } //For associating each entry with a logged in user

        [Required]
        public string ThingName { get; set; } //For storing things


        public string ThingImage { get; set; } //For storing things


        public ThingCategoryTBL ThingCat { get; set; } //For displaying to the screen

        [Required]
        public int ThingCatThingCatID { get; set; } //For entering the integer when saving



        
        public string ThoughtName { get; set; } //For storing thoughts


        //public string ThingCategoryIcon { get; set; }
    }
}