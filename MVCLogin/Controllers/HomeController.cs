﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCLogin.Models;
using MVCLogin.Data;
using Microsoft.EntityFrameworkCore;
using MVCLogin.Helpers;

namespace MVCLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VitecContext _context;
        private Helpers.APIHelper _apiHelper;

        public HomeController(ILogger<HomeController> logger, VitecContext context, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _context = context;
            _apiHelper = new APIHelper(clientFactory);
        }

        public async Task<IActionResult> Index()
        {

            return View(await _apiHelper.GetObjectsFromAPI<List<Product>>("http://soelvkikkertproductsapi.azurewebsites.net/api/Products"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
