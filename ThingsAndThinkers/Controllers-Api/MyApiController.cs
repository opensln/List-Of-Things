using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThingsAndThinkers.Models;
using System.Data.Entity;

namespace ThingsAndThinkers.Controllers_Api
{
    public class MyApiController : ApiController
    {
        private ApplicationDbContext _context;

        public MyApiController()
        {
            _context = new ApplicationDbContext();
        }


        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;

            var allthings = _context.ThingTBLs.Include(t => t.Thinker).Include(c => c.ThingCat).ToList();

         
            if (allthings.Count() > 0)
            {
                ret = Ok(allthings);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        
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