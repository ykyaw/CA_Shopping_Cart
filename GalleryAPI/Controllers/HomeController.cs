using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GalleryAPI.Models;
using GalleryAPI.Services;
using System.Text.Json;

namespace GalleryAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Gallery gallery;

        public HomeController(ILogger<HomeController> logger, Gallery gallery)
        {
            _logger = logger;
            this.gallery = gallery;
        }

        public IActionResult Index()
        {
            return View();
        }


        //get all product list in object format
        public string Products([FromBody] Operand operand)
        {
            List<Product> productGallery = gallery.GetAllProducts();
            operand.Value = productGallery;
            return JsonSerializer.Serialize(operand);
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
