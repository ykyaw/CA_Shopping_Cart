using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShoppingCart_1A.Services;
using Microsoft.Extensions.Configuration;
using WebShoppingCart_1A.Models;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Web.Providers.Entities;



namespace WebShoppingCart_1A.Controllers
{

    public class AccountController : Controller
    {
        List<Account> accounts = new List<Account>();
        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;
        public AccountController(HttpClient httpClient, IConfiguration cfg,
          DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }
        public IActionResult Index()
        {
            string url;
            url = cfg.GetValue<string>("Hosts:AccountAPI") + "/Home/getAccounts";
            Result result = new Result();
            result = dataFetcher.GetData(httpClient, url, result);
            accounts = JsonConvert.DeserializeObject<List<Account>>(result.Value.ToString());

            if (Request.Cookies["UserId"] != null) //this block of code pull unpaid cart item back to cookies
            {
                //pull all unpaid ItemId from CartAPI based on UserId
                Result result2 = new Result();
                result.Value = Request.Cookies["UserId"];
                string url2 = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/getProducts";
                result2 = dataFetcher.GetData(httpClient, url2, result);
                List<Cart> carthistory = new List<Cart>();
                carthistory = JsonConvert.DeserializeObject<List<Cart>>(result2.Value.ToString());
                List<string> cartid = new List<string>();
                foreach (Cart x in carthistory)
                {
                    cartid.Add(x.productId);
                }
                if (Request.Cookies["CartState"] == null)
                {
                    Response.Cookies.Append("CartState", JsonConvert.SerializeObject(cartid));
                }
                else
                {
                    List<string> currentcart = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["CartState"]);
                    currentcart.AddRange(cartid);
                    Response.Cookies.Append("CartState", JsonConvert.SerializeObject(currentcart));
                }
            }
            ViewData["accounts"] = accounts;
            return View();
        }    
        public IActionResult Logout(Result result)
        {
            if(Request.Cookies["CartState"]==null)
            {
                return RedirectToAction("Emptycartlogout");
            }
            string userid = JsonConvert.DeserializeObject<string>(Request.Cookies["UserId"]);
            List<string> currentcartid = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["CartState"]);
            Cart ctosave = new Cart();
            List<Cart> CartPasstoAPI = new List<Cart>();
            foreach (string x in currentcartid)
            {
                ctosave.userId = userid;
                ctosave.productId = x;
                CartPasstoAPI.Add(ctosave);
            }
            result.Value = JsonConvert.SerializeObject(CartPasstoAPI);
            string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/receivecartfromlogout";
            result = dataFetcher.GetData(httpClient, url, result);
            Response.Cookies.Delete("UserId");
            Response.Cookies.Delete("CartState");
            return RedirectToAction("Index", "Product");
           
        }

        public IActionResult Emptycartlogout(Result result) //this method request CartAPI to empty state upon nothing in cart or successful checkout
        {
            int empty = 0;
            result.Value = JsonConvert.SerializeObject(empty);
            string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/clearcart";
            result = dataFetcher.GetData(httpClient, url, result);
            return RedirectToAction("Index", "Product");
        }
    }
}

 //result.Value = JsonConvert.SerializeObject(currentcartid);
            //string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/receivecartfromlogout";
            //result = dataFetcher.GetData(httpClient, url, result);
            //Response.Cookies.Delete("UserId");
            //return RedirectToAction("Index", "Product");