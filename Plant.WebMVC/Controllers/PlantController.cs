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
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlantService();

            if (service.CreatePlants(model))
            {
                TempData["SaveResult"] = "The plant was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Plant could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlantService();
            var model = svc.GetPlantById(id);

            return View(model);
        }

        public PlantService CreatePlantService()
        {
            var UserId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlantService(UserId);

            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlantService();
            var detail = service.GetPlantById(id);
            var model =
                new PlantEdit
                {
                    Quantity = detail.Quantity,
                    TypeOfPlant = detail.TypeOfPlant,
                    PlantName = detail.PlantName,
                    PlantId = detail.PlantId,
                    Price = detail.Price,
                    OwnerId = detail.OwnerId,
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlantEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlantId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlantService();

            if ( service.UpdatePlant(model))
            {
                TempData["SaveResult"] = "The plant item was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The plant item could not be updated.");
            return View(model);
        }
           
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlantService();
            var model = svc.GetPlantById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlantService();

            service.DeletePlant(id);

            TempData["SaveResult"] = "Your plant item was deleted";

            return RedirectToAction("Index");

        }
    }
}