using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PayPal.Api;
using APIContext = PayPal.APIContext;
using OAuthTokenCredential = PayPal.OAuthTokenCredential;

namespace LICENTA4.Controllers
{
    public class AdministrationController : Controller
    {
        public RoleManager<IdentityRole> roleManager;
        // GET: Administration
        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {

            this.roleManager = roleManager;
        }

        

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

    }
}