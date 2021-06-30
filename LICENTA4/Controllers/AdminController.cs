using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LICENTA4.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LICENTA4.Controllers
{
    public class AdminController : Controller
    {
        public RoleManager<IdentityRole> RoleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.RoleManager = roleManager;
        }
        // GET: Admin

        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProjectRole role)
        {
            var roleExist = await RoleManager.RoleExistsAsync(role.RoleName);
            if (!roleExist)
            {
                var result = await RoleManager.CreateAsync(new IdentityRole(role.RoleName));
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}