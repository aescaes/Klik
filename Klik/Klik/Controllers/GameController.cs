using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Klik.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("players")]
        public ActionResult Players()
        {
            return View();
        }
    }
}