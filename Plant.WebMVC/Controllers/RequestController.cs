using Plant.Models;
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
            var model = new RequestListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}