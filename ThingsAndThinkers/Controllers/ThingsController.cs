using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingsAndThinkers.Models;
using ThingsAndThinkers.ViewModels;
using System.Data.Entity;

namespace ThingsAndThinkers.Controllers
{
    public class ThingsController : Controller
    {
        private ApplicationDbContext _context;

        public ThingsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ThingCat
        public ActionResult ThingCatList(string searchString)
        {
            var fullList = _context.ThingTBLs.Include(u => u.Thinker).Include(c => c.ThingCat);

            if (!string.IsNullOrEmpty(searchString))
            {
                fullList = fullList.Where(x => x.ThingName.Contains(searchString));
            }

            return View(fullList);
        }

        [Authorize]
        public ActionResult Create()
        {

            //ViewBag.HelloName = "Hello " + User.Identity.GetUserId();            
            //var userID = User.Identity.GetUserId();
            //ViewBag.CurrentUser = userID;

            var viewmodelObj = new CreateThingFormViewModel
            {
                ThingCatListable = _context.ThingCategoryTBLs.ToList()
            };

            return View(viewmodelObj);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateThingFormViewModel vmObj)
        {

            

            if (!ModelState.IsValid)
            {
                return View(vmObj);
            }
                var thingObj = new ThingTBL
                {
                    ThinkerId = User.Identity.GetUserId(),
                    ThingName = vmObj.ThingNameVM,                                 
                    ThingCatThingCatID = vmObj.ThingCatIDVM,
                    ThoughtName = vmObj.ThoughtNameVM,


                };

                _context.ThingTBLs.Add(thingObj);
                _context.SaveChanges();

                return RedirectToAction("Index", "home");
   
        }
    }
}