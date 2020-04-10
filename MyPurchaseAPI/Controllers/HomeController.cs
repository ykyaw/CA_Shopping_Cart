using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPurchaseAPI.Models;
using MyPurchaseAPI.Services;

namespace MyPurchaseAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Purchase purchase;

        public HomeController(ILogger<HomeController> logger,Purchase purchase)
        {
            _logger = logger;
            this.purchase = purchase;
        }

        public IActionResult Index()
        {
            return View();
        }

        //get purchase list
        public string Purchases([FromBody] Operand operand)
        {
            string sessionId = Request.Cookies["sessionId"];
            string userId = HttpContext.Session.GetString(sessionId);
            List<PurchaseHistory> purchaseHistories = purchase.GetPurchaseHistories();
            operand.Value = purchaseHistories;
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
