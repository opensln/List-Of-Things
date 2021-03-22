using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using ThingsAndThinkers.Models;

namespace ThingsAndThinkers.ViewModels
{
    public class CreateThingFormViewModel
    {
        public string ThoughtNameVM { get; set; }

        public string ThingNameVM { get; set; }

        public string ThingCatIconVM { get; set; }

        [DisplayName("Category")]
        public int ThingCatIDVM { get; set; }

        public IEnumerable<ThingCategoryTBL> ThingCatListable { get;set;}
    }
}