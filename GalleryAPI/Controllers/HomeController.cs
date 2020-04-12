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
using Newtonsoft.Json;

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

        public string PurchasesProduct([FromBody] Operand operand)
        {
            List<PurchaseHistory> list = JsonConvert.DeserializeObject<List<PurchaseHistory>>(operand.Value.ToString());
            operand.Value=gallery.PurchasesProduct(list);
            return System.Text.Json.JsonSerializer.Serialize(operand);
        }


        //get all product list in object format
        public string Products([FromBody] Operand operand)
        {
            List<Product> productGallery = gallery.GetAllProducts();
            operand.Value = productGallery;
            return System.Text.Json.JsonSerializer.Serialize(operand);
        }

        public string CartProduct([FromBody] Operand operand)
        {
            List<Cart> cartList = System.Text.Json.JsonSerializer.Deserialize<List<Cart>>(operand.Value.ToString());
            operand.Value=gallery.CartProduct(cartList);
            return System.Text.Json.JsonSerializer.Serialize(operand);
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
