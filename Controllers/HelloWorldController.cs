using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace BowlsApp.Controllers
{
    public class HelloWorldController : Controller
    {
        //GET: /HellowWorld/
        public IActionResult Index()
        {
            return View();
        }

        //GET: /HelloWold/Welcome
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
