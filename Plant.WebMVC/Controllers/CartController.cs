using Microsoft.AspNet.Identity;
using Plant.Models;
using Plant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plant.WebMVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var model = new CartListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CartCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(userId);

            service.CreateCart(model);

            return RedirectToAction("Index");
        }
    }
}