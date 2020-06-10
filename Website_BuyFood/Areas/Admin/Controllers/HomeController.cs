using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website_BuyFood.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Hom
        public ActionResult Index()
        {
            return View();
        }
    }
}