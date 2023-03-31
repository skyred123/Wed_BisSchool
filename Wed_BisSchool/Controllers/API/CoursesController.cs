using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wed_BisSchool.Models;

namespace Wed_BisSchool.Controllers.Api
{
    public class CoursesController : ApiController
    {
        public ApplicationDbContext context;
        public CoursesController()
        {
            context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userid = User.Identity.GetUserId();
            var course = context.Sources.Single(e => e.Id == id && e.LecturerId == userid);
            if (course.IsCanceled)
            {
                return NotFound();
            }
            course.IsCanceled= true;
            context.SaveChanges();
            return Ok();
        }
    }
}
