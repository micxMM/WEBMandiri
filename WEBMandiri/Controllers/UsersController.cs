﻿using Microsoft.AspNetCore.Mvc;

namespace WEBMandiri.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
