using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebShoppingCart_1A.Models;
using WebShoppingCart_1A.Services;

namespace WebShoppingCart_1A.Controllers
{
    public class ViewCartController : Controller
    {
        //List<Cart> carts = new List<Cart>();
        List<Product> products = new List<Product>();
        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;
        public ViewCartController(HttpClient httpClient, IConfiguration cfg,
          DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }


        public IActionResult Index() //this renders the entire cart view
        {
            //retrieve all product from productAPI
            string productAPIurl = cfg.GetValue<string>("Hosts:ProductsAPI") + "/Home/getProducts";
            Result p_result = new Result();
            p_result = dataFetcher.GetData(httpClient, productAPIurl, p_result);
            products = JsonConvert.DeserializeObject<List<Product>>(p_result.Value.ToString());

            //retrieve productId from cookie
            List<string> currentcartid = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["CartState"]);
            List<Product> currentcart = new List<Product>();
            foreach (string ItemId in currentcartid)
            {
                foreach (Product product in products)
                {
                    if (ItemId == product.Id)
                        currentcart.Add(product);
                }
            }

            ViewData["totalprice"] = currentcart.Sum(item => item.unitPrice).ToString("c");
            ViewData["CartView"] = currentcart;
            return View();

        }

        public void MinusCart(string ItemId)
        {
            List<string> currentcart = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["CartState"]);
            currentcart.Remove(ItemId);
            Response.Cookies.Append("CartState", JsonConvert.SerializeObject(currentcart));

        }

        public void RemoveAllSimilarItem(string ItemId) //unused for now, delete if not needed
        {
            List<string> oldcart = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["CartState"]);
            oldcart.RemoveAll(item => item == ItemId);
            Response.Cookies.Append("CartState", JsonConvert.SerializeObject(oldcart));
        }


        public IActionResult Checkout()
        {
            //check if userID available. if no, redirect to login action in cart controller
            //if yes, redirect to paymentAPI, wait for success response.
            //upon receving successful response, push all info to Orders API, and send response to CartAPI to clear data and clear cookie cart state
            if (Request.Cookies["UserId"] == null)
            {
                return Redirect("https://localhost:44334/Home/Index");
            }
            else
                return RedirectToAction("SuccessPayment","Orders"); //orderscontroller
        }

        //public IActionResult Logout(Result result)
        //{
        //    List<string> currentcartid = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["CartState"]);
        //    result.Value = currentcartid;
        //    string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/receivecartfromapi";
        //    result = dataFetcher.GetData(httpClient, url, result);
        //    Response.Cookies.Delete("CartState");
        //    //Response.Cookies.Delete("UserId");
        //    return RedirectToAction("Index", "Product");

        //}
    }
}



        //public IActionResult Showcart() //work in progress, sunday morning
        //{
        //    //retrieve all product from productAPI
        //    string productAPIurl = cfg.GetValue<string>("Hosts:ProductsAPI") + "/Home/getProducts";
        //    Result p_result = new Result();
        //    p_result = dataFetcher.GetData(httpClient, productAPIurl, p_result);
        //    products = JsonConvert.DeserializeObject<List<Product>>(p_result.Value.ToString());

        //    //retrieve a list of productID and userId/sessionId from CartAPI
        //    string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/RetrieveCart";
        //    Result result = new Result();
        //    result = dataFetcher.GetData(httpClient, url, result);
        //    carts = JsonConvert.DeserializeObject<List<Cart>>(result.Value.ToString());
        //    ViewData["cartcounter"] = carts.Count; //To display under total quantity

        //    List<Product> currentcart = new List<Product>();

        //    foreach (Cart cart in carts)
        //    {
        //        foreach (Product product in products)
        //        {
        //            if (cart.productId == product.Id)
        //            {
        //                currentcart.Add(product);
        //            }
        //        }
        //    }
        //}


