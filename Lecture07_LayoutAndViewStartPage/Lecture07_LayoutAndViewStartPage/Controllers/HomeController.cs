﻿using Microsoft.AspNetCore.Mvc;

namespace Lecture07_LayoutAndViewStartPage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult About()
        {
            return View();
        }


        public IActionResult Service()
        {
            return View();
        }
    }
}
