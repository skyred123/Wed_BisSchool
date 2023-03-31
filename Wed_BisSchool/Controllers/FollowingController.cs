using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wed_BisSchool.DTOs;
using Wed_BisSchool.Models;

namespace Wed_BisSchool.Controllers
{
    public class FollowingController : ApiController
    {

        ApplicationDbContext _context;
        public FollowingController() { 
            _context= ApplicationDbContext.Create();
        }
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userid = User.Identity.GetUserId();
            if(_context.Followings.Any(a=>a.FollowerId==userid&&a.FolloweeId== followingDto.FolloweeId)) {
                return BadRequest("Folowing already exists!");
            }
            var following = new Following()
            {
                FollowerId = userid,
                FolloweeId = followingDto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();

        }
    }
}
