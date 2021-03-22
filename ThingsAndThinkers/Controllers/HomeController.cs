using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Web.Mvc;
using ThingsAndThinkers.HotstaModels;
using ThingsAndThinkers.Models;

namespace ThingsAndThinkers.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return RedirectToAction("ThingCatList","Things");
        }

        [Authorize]
        [HttpGet]
        public ActionResult PostPage()
        {
            ViewBag.Instructions = "Enter your details and upload an image";
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult PostPage(PosterTBL posterTBL)
        {

            posterTBL.PosterName = User.Identity.GetUserName();
            posterTBL.DatePosted = DateTime.Now.ToUniversalTime().ToString();
            


            //---------------------------------------------------------------------------------------------------

            string imagename = Path.GetFileNameWithoutExtension(posterTBL.ImageFile.FileName);
            string extension = Path.GetExtension(posterTBL.ImageFile.FileName);
            imagename = $"{DateTime.Now.ToBinary()}{imagename}{extension}";
            posterTBL.ImageName = imagename;


            imagename = Path.Combine(Server.MapPath("~/Content/crewimages/"), imagename);
            posterTBL.ImageFile.SaveAs(imagename);

            //---------------------------------------------------------------------------------------------------

            if (!ModelState.IsValid)
            {
                ViewBag.Instructions = "Enter your details";
                return View();
            }
            return RedirectToAction("ShowInput", posterTBL);
        }

        public ActionResult ShowInput(PosterTBL posterTBLinput)
        {
            //var fullList = _context.ThingTBLs.Include(u => u.Thinker).Include(c => c.ThingCat).ToList();

            ViewBag.Message = "Please check your details";
            ViewBag.PosterID = posterTBLinput.PosterId;
            //ViewBag.PosterName = $"posted by: {posterTBLinput.PosterName}";
            ViewBag.PostersName = posterTBLinput.PosterName;

            ViewBag.NewFileName = $"Your new imageFile name is: {posterTBLinput.ImageName}";
            ViewBag.Image = posterTBLinput.ImageName;
            ViewBag.DatePosted = posterTBLinput.DatePosted;
            ViewBag.Caption = posterTBLinput.Caption;

            return View();
        }
    }
}