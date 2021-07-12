﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _01._07._21_EXAM_Internet_Shop.Models;
using _01._07._21_EXAM_Online_Store;

namespace _01._07._21_EXAM_Internet_Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly OnlineStoreDbContext _context;

        public ProductsController(OnlineStoreDbContext context)
        {
            _context = context;
        }

        // GET: Products
        //[HttpGet]
        //public async Task<IActionResult> AllProducts()
        //{
        //    return View(await _context.Products.ToListAsync());
        //}

        [Route("")]
        [Route("{skip:int}/{pages:int}")]
        [HttpGet]
        public async Task<IActionResult> AllProducts(int skip = 0, int pages = 1)
        {
            return View(await _context.Products
                .Skip(skip * 12)
                .Take(pages * 12)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Product>> ShowProduct(int product)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == product);

            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> SearchProductsByName(string nameProduct)
        {
            var items = await _context.Products
                                    .Where(p => p.Name.Contains(nameProduct))
                                    .ToListAsync();

            return View("AllProducts", items);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int? category)
        {
            var items = await _context.Products
                                    .Where(p => p.CategoryId == category)
                                    .ToListAsync();

            return View("AllProducts", items);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
