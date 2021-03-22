using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThingsAndThinkers.Models;

namespace ThingsAndThinkers.Controllers_Api
{
    public class CategoryController : ApiController
    {

        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>
        [HttpGet()]
        //[Route("api/Category/GetSearchCat")]
        public IHttpActionResult GetSearchCat()
        {
           IHttpActionResult ret = null;

           var categoryList = _context.ThingCategoryTBLs.ToList();

            if (categoryList.Count() > 0)
            {
                // Add category for 'Search All'
                ThingCategoryTBL defaultCat = new ThingCategoryTBL();

                defaultCat.ThingCatID = 0;
                defaultCat.ThingCatName = "-- Search All Categories --";
                
                //SearchCategories.AddRange(Categories);
                // Insert "Search" at the top
                categoryList.Insert(0, defaultCat);

                ret = Ok(categoryList);
            }
            else
            {
               ret = NotFound();
            }

            return ret;
            //return Ok("Hello from Category controller");
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}