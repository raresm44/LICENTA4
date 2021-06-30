using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.Internal;
using LICENTA4.Models;

namespace LICENTA4.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Buy(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);
            if (post == null)
                return HttpNotFound();

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                
                cart.Add(new Item{ post = post, Quantity = 1});
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var item = cart.SingleOrDefault(c => c.post.Id == id);
                if (item != null)
                {
                    item.Quantity++;
                }
                else
                {
                    cart.Add(new Item{post = post, Quantity = 1});
                }

                Session["cart"] = cart;

            }

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            List<Item> cart = (List<Item>) Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].post.Id.Equals(id))
                    return i;
            return -1;
        }
    }
}