using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LICENTA4.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LICENTA4.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Roles).ToList();
            return View(users);
        }
        // public ActionResult Create()
        // {
        //     var role = new IdentityUser();
        //     return View(role);
        // }

        [HttpPost]
        public ActionResult Create(IdentityUser user)
        {
           // IdentityUser.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}