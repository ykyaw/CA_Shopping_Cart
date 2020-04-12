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
        List<Cart> carts = new List<Cart>();
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

        [HttpGet]
        public IActionResult Search(string keyword)
        {
            string url;
            url = cfg.GetValue<string>("Hosts:ProductsAPI") + "/Home/getProducts";
            Result result = new Result();
            result = dataFetcher.GetData(httpClient, url, result);
            products = JsonConvert.DeserializeObject<List<Product>>(result.Value.ToString());

            List<Product> searchedproduct = new List<Product>();

            var allproducts = from x in products
                              select x;

            if (keyword == null)
            {
                searchedproduct.AddRange(allproducts);
            }
            else
            {
                foreach (Product product in products)
                {
                    if (product.productName.ToLower().Contains(keyword.ToLower()) || product.productDescription.ToLower().Contains(keyword.ToLower()))
                    {
                        searchedproduct.Add(product);
                    }
                }
            };
            ViewData["searchedproducts"] = searchedproduct;
            return View();
        }

        [HttpGet]
        public ActionResult Detail(string productid)
        {
            string url;
            url = cfg.GetValue<string>("Hosts:ProductsAPI") + "/Home/getProducts";
            Result result = new Result();
            result = dataFetcher.GetData(httpClient, url, result);
            products = JsonConvert.DeserializeObject<List<Product>>(result.Value.ToString());

            List<Product> clickedproduct = new List<Product>();

            var clickedproducts = from x in products
                                  select x;

            foreach (Product product in products)
            {
                if (product.Id.Contains(productid))
                {
                    clickedproduct.Add(product);
                }
            }
            ViewData["clickedproduct"] = clickedproduct;

            return View();
        }

        public void AddToCart(string ItemId)
        {
            if (Request.Cookies["CartState"] == null)
            {
                List<string> currentcart = new List<string>();
                currentcart.Add(ItemId);
                Response.Cookies.Append("CartState", JsonConvert.SerializeObject(currentcart));
            }
            else
            {
                List<string> currentcart = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["CartState"]);
                currentcart.Add(ItemId);
                Response.Cookies.Append("CartState", JsonConvert.SerializeObject(currentcart));
            }
        }

        public IActionResult Cartcounter(string ItemId) //not sure how to get it working. leave it for now
        {
            string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/RetrieveCart";
            Result result = new Result();
            result = dataFetcher.GetData(httpClient, url, result);
            carts = JsonConvert.DeserializeObject<List<Cart>>(result.Value.ToString());
            //ViewData["cartcounter"] = carts.Count;
            return Json(JsonConvert.SerializeObject(carts.Count));
        }

        //return JsonSerializer.Serialize(Result);
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