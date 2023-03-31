using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using Wed_BisSchool.DTOs;
using Wed_BisSchool.Models;

namespace Wed_BisSchool.Controllers
{
    [Authorize]
    public class AttendacencesController : ApiController
    {
        ApplicationDbContext _context;
        public AttendacencesController() {
            _context =  ApplicationDbContext.Create();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendancenDto attendancenDto)
        {
            var userid = User.Identity.GetUserId();
            if(_context.Attendances.Any(a=>a.AttendeeId== userid && a.CourceId==attendancenDto.CourseId)) { 
                return BadRequest("The Attendancence already exists!");
            }
            var attendance = new Attendance()
            {
                CourceId = attendancenDto.CourseId,
                AttendeeId = User.Identity.GetUserId(),
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
    
}