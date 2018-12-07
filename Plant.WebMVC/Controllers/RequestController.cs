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
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RequestService(userId);
            var model = service.GetRequests();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRequestService();

            if (service.CreatesRequest(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Request could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRequestService();
            var model = svc.GetRequestById(id);

            return View(model);
        }

        private RequestService CreateRequestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RequestService(userId);

            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRequestService();
            var detail = service.GetRequestById(id);
            var model =
                new RequestEdit
                {
                    RequestId = detail.RequestId,
                    Content = detail.Content
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RequestEdit model)
        {

            if (!ModelState.IsValid) return View(model);

            if (model.RequestId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRequestService();

            if (service.UpdateRequest(model))
            {
                TempData["SaveResult"] = "Your request has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your request could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRequestService();
            var model = svc.GetRequestById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRequestService();

            service.DeleteRequest(id);

            TempData["SaveResult"] = "Your request has been deleted.";

            return RedirectToAction("Index");
        }
    }
}