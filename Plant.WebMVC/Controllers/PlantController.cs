using Plant.Models;
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
            var model = new PlantListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}