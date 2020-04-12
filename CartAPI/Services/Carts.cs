using CartAPI.DB;
using CartAPI.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Services
{
    public class Carts
    {
        private CartContext db;

        public Carts(CartContext db)
        {
            this.db = db;
        }

        //this is to retrieve user shopping cart
        public List<Cart> GetCartList(User user)
        {
            string userId = user.Id;
            return db.Carts.Where(cart => cart.UserId == userId).ToList<Cart>();

        }
        // Added by Yuanchang for add to cart post
        public void AddToCart(List<Cart> cartList, User user)
        {
            IDbContextTransaction transcat = db.Database.BeginTransaction();
            try
            {
                //// Get the matching cart and user instances
                foreach(Cart cart in cartList)
                {
                    Cart cartRecord = db.Carts.Where(
                    item => item.ProductId == cart.ProductId
                    && item.UserId == user.Id).SingleOrDefault();
                    if (cartRecord == null)
                    {
                        Cart newCart = new Cart
                        {
                            // Create a new cart item if no cart item exists
                            Id = System.Guid.NewGuid().ToString(),
                            UserId = user.Id,
                            ProductId = cart.ProductId,
                            Quantity = cart.Quantity
                        };
                        db.Add(newCart);
                    }
                    else
                    {
                        cartRecord.Quantity++;
                    }
                }
                
                db.SaveChanges();
                transcat.Commit();
            }
            catch (Exception) { 
                transcat.Rollback(); 
            }
        }
        // Added by Yuanchang to count items in cart
        public int GetCount(User user)
        {
            //Get the count of each item in the cart and sum them up
            int? count = (from cartItems in db.Carts
                          where cartItems.UserId == user.Id
                          select (int?)cartItems.Quantity).Sum(); ;
            return count ?? 0;
        }

        //change the quantity of cart
        public bool ChangeQuantity(Cart cart)
        {
            IDbContextTransaction transcat = db.Database.BeginTransaction();
            try
            {
                Cart cartRecord = db.Carts.Where(
                item => item.Id == cart.Id).SingleOrDefault();
                if (cart.Quantity == 0)
                {
                    db.Carts.Remove(cartRecord);
                }
                else
                {
                    cartRecord.Quantity = cart.Quantity;
                }
                db.SaveChanges();
                transcat.Commit();
                return true;
            }
            catch (Exception)
            {
                transcat.Rollback();
                return false;
            }
        }


        public IsDone Checkout(User user)
        {
            IDbContextTransaction transcat = db.Database.BeginTransaction();
            try
            {
                List<Cart> cartList = db.Carts.Where(
                item => item.UserId == user.Id).ToList<Cart>();
                if (cartList != null)
                {
                    foreach(Cart cart in cartList)
                    {
                        db.Carts.Remove(cart);
                    }
                }
                db.SaveChanges();
                transcat.Commit();
                return new IsDone() { Done = true };
            }
            catch (Exception)
            {
                transcat.Rollback();
                return new IsDone() { Done = false };
            }
        }

    }


}
