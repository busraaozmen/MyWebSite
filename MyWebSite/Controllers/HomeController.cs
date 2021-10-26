using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyWebSite.MailServis;
using MyWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebSite.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;

        }


        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Index(Email model)
        {

            return View();
        }

        [HttpPost]
        public IActionResult MailGonder([FromBody] Email model)
        {

            return Json(mailWebServis.MailGonder(_configuration, model));
        }
    }
}
