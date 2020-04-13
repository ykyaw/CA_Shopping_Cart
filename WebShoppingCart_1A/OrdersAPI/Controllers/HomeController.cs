using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrdersAPI.Models;
using System.Text.Json;
using Newtonsoft.Json;
using OrdersAPI.OrdersDB;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using WebShoppingCart_1A.Services;

namespace OrdersAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public OrdersContext dbcontext;


        public HomeController(ILogger<HomeController> logger, OrdersContext dbcontext)
        {
            _logger = logger;
            this.dbcontext = dbcontext;

        }

        public string receiveorders([FromBody]Result result)
        {
            List<Orders> receivedorders = new List<Orders>();
            receivedorders = JsonConvert.DeserializeObject<List<Orders>>(result.Value.ToString());
            Orders neworder = new Orders();
            foreach(Orders order in receivedorders)
            {
                neworder.Id = Guid.NewGuid().ToString(); //activation code
                neworder.imageURL = order.imageURL;
                neworder.productId = order.productId;
                neworder.timestamp = order.timestamp;
                neworder.unitPrice = order.unitPrice;
                neworder.userId = order.userId;
                dbcontext.Add(neworder);
                dbcontext.SaveChanges();
            }

            return System.Text.Json.JsonSerializer.Serialize(result);
        }

        public string OrderHistory(Result result)
        {
            result.Value = dbcontext.Orders_tbl.ToList();
            return System.Text.Json.JsonSerializer.Serialize(result);
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
