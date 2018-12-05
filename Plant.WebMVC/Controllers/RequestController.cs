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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RequestService(userId);

            service.CreatesRequest(model);

            return RedirectToAction("Index");
        }
    }
}