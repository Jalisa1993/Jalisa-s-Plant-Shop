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
            var UserId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(UserId);
            var model = service.GetCart();

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
            if (ModelState.IsValid) return View(model);

            var service = CreateCartService();

            if (service.CreateCart(model))
            {
                TempData["SaveResult"] = "Your cart was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Cart could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCartService();
            var model = svc.GetCartById(id);

            return View(model);
        }

        private CartService CreateCartService()
        {
            var UserId = Guid.Parse(User.Identity.GetUserId());
            var service = new CartService(UserId);

            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCartService();
            var detail = service.GetCartById(id);
            var model =
                new CartEdit
                {
                    CartId = detail.CartId,
                    PlantId = detail.PlantId,
                    TotalPrice = detail.TotalPrice,
                    Plant = detail.Plants,
                };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CartEdit model)
        {

            if (!ModelState.IsValid) return View(model);
            if (model.CartId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCartService();

            if (service.UpdateCart(model))
            {
                TempData["SaveResult"] = "Your cart has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your cart could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCartService();
            var model = svc.GetCartById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCartService();

            service.DeleteCart(id);

            TempData["SaveResult"] = "Your cart was deleted.";

            return RedirectToAction("Index");
        
        }
    }
}