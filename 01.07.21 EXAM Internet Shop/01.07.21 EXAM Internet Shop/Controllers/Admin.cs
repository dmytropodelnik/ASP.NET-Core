﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01._07._21_EXAM_Internet_Shop.Controllers
{
    [Route("admin")]
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
