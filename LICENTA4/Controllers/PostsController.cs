using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LICENTA4.Models;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace LICENTA4.Controllers
{
    //[Authorize]
    public class PostsController : Controller
    {
        //private string rn = RoleName.CanManagePosts;
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult InCursDeAprobare()
        {
            var posts = db.Posts.Include(p => p.Genre).Include(p => p.Platform).Where(p =>p.Aprobare==0);
            return View(posts);
        }

        public ActionResult Aproba(int id)
        {
            var post = db.Posts.SingleOrDefault(p => p.Id == id);
            if (post == null)
                return HttpNotFound();
            post.Aprobare = 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Posts
        // [Authorize]
        public ActionResult Index()
        {
            // DateTime dt = null;
            // Console.WriteLine(dt.ToString());
            // var ceva = db.Roles
            var isAdmin = User.IsInRole(RoleName.Admin);
            var ui = User.Identity.GetUserId();
             // var posts = isAdmin || ui.IsNullOrWhiteSpace() ? db.Posts.Include(p => p.Genre) : db.Posts.Include(p => p.Genre)
             //     .Where(p => p.UserId == ui);

            var posts = db.Posts.Include(p => p.Genre).Include(p => p.Platform).Where(p =>p.Aprobare==1);
            
            // var items = posts;
             var cart = new CartController();


             // .Select(p => p.UserId);
            // var UserId = User.Identity.GetUserId();
            // posts = db.Posts.Include(p => p.UserId);
           // if (User.IsInRole(RoleName.User) || isAdmin)
                return View("Index", posts.ToList());
            //return View("ReadOnly", posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Include(p=>p.Genre).Include(p => p.Platform).SingleOrDefault(p => p.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            
            return View(post);
        }

        // GET: Posts/Create

        //ceva

        //ceva
        

        [Authorize]
        public ActionResult Create()
        {
            Post post = new Post();
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name");
            // ViewBag.UserId = User.Identity.GetUserId();
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            post.DateRelease = null;
            post.DateAdded = DateTime.Now;
            
            return View(post);
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = RoleName.Admin + ", " + RoleName.User)]
        [Authorize]
        public ActionResult Create( Post post)
        {
            if (post.Image != null && post.Image != "")
            {
                string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
                string extension = Path.GetExtension(post.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                post.Image = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                post.ImageFile.SaveAs(fileName);
            }

            //var user = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {   
                post.UserId = User.Identity.GetUserId();
                var Date = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", post.GenreId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name", post.PlatformId);
            
            return View(post);
        }

        // GET: Posts/Edit/5
        // [Authorize(Roles = RoleName.Admin + ", " + RoleName.User)]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", post.GenreId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name", post.PlatformId);

            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin + ", " + RoleName.User)]
        public ActionResult Edit([Bind(Include = "Id,Title,GenreId,Description,DateAdded,DateRelease,Price,Image,UserId,PlatformId")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", post.GenreId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name", post.PlatformId);
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = RoleName.Admin + ", " + RoleName.User)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [Authorize(Roles = RoleName.Admin + ", " + RoleName.User)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
