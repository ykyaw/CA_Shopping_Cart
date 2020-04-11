using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShoppingCart_1A.Services;
//using System.Windows;
//using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using WebShoppingCart_1A.Models;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Web.Providers.Entities;
//using System.Net;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Text;
//using System.Web;



namespace WebShoppingCart_1A.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products = new List<Product>();
        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;

        public ProductController(HttpClient httpClient, IConfiguration cfg,
          DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }
        public IActionResult Index()
        {
            string url;
            url = cfg.GetValue<string>("Hosts:ProductsAPI") + "/Home/getProducts";
            Result result = new Result();
            result = dataFetcher.GetData(httpClient, url, result);  
            products = JsonConvert.DeserializeObject<List<Product>>(result.Value.ToString());
            ViewData["products"] = products;
            return View();
        }

        public void AddToCart(string ItemId, Result result /*Product product*/)
        {
            
            result.Value = ItemId;
            string sessionID = Request.Cookies["SessionId"];
            string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/receivecartfromapi";
            result = dataFetcher.GetData(httpClient, url, result);

            //return JsonSerializer.Serialize(Result);
        }


        //public string getProducts(Result result)
        //{
        //    result.Value = dbcontext.Product_tbl.ToList();
        //    return JsonSerializer.Serialize(result);
        //}


        //HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(listofcartitem));
        //            TempData["UserCartinfo"] = cart; //cart is passed to CartController through this method
        //use TempData["happy"] to pass info btwn controller

        //public void AddToCart(string ItemId /*Product product*/)
        //{

        //    Product findproductinfo = products.Find(x => x.productName == ItemId);
        //    string findproductinfo_descrip = findproductinfo.productDescription;
        //    string findproductinfo_name = findproductinfo.productName;
        //    string findproductinfo_Id = findproductinfo.Id;
        //    double findproductinfo_unitprice = findproductinfo.unitPrice;
        //}


        //public JsonResult Index(string ItemId)
        //{
        //    return Json(data: "", JsonRequestBehaviour.AllowGet);
        //}
    }
}