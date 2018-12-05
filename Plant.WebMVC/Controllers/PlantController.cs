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
    public class PlantController : Controller
    {
        // GET: Plant
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlantService(userId);
            var model = service.GetPlants();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlantCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlantService(userId);

            service.CreatePlants(model);

            return RedirectToAction("Index");
        }
    }
}