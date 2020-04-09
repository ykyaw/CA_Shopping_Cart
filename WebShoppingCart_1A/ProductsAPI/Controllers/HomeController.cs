using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAPI.Models;
using ProductsAPI.ProductDB;
using ProductsAPI.Service;

namespace ProductsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ProductContext dbcontext;
        public HomeController(ILogger<HomeController> logger, ProductContext dbcontext)
        {
            _logger = logger;
            this.dbcontext = dbcontext;
        }
        
     
      
        public string getProducts(Result result)
        {
            result.Value = dbcontext.Product_tbl.ToList();
            return JsonSerializer.Serialize(result);

            //List<Product> softwares = dbcontext.Product_tbl.ToList();

        //    public IActionResult PullData()
        //{
        //    List<Product> softwares=pulldata.getProducts();
            //foreach (Product product in softwares)
            //{
            //    Debug.WriteLine("Id=", product.Id);
            //    Debug.WriteLine("Product Name=", product.productName);
            //    Debug.WriteLine("product Description=", product.productDescription);
            //    Debug.WriteLine("unit Price=", product.unitPrice);
            //    Debug.WriteLine("product Rating", product.productRating);
            //}

           
        }

        public IActionResult Index()
        {
            return View();
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
