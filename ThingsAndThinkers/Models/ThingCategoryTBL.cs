using System.ComponentModel.DataAnnotations;

namespace ThingsAndThinkers.Models
{
    public class ThingCategoryTBL
    {
        [Key]
        public int ThingCatID { get; set; }

        [Required]
        public string ThingCatName { get; set; }

        public string ThingCatIcon { get; set; }

    }
}