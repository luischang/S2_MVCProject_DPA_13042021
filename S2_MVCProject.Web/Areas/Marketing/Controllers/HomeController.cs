using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S2_MVCProject.Web.Areas.Marketing.Controllers
{
    [Area("Marketing")]
    //[Area(nameof(Marketing))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
