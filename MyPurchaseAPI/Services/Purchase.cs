using Microsoft.EntityFrameworkCore.Storage;
using MyPurchaseAPI.DB;
using MyPurchaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPurchaseAPI.Services
{
    public class Purchase
    {
        private PurchaseHistoryContext dbcontext;

        public Purchase(PurchaseHistoryContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<PurchaseHistory> GetPurchaseHistories(User user)
        {
            List<PurchaseHistory> purchaseHistories = dbcontext.PurchaseHistories
                .Where(item=>item.UserId==user.Id).ToList<PurchaseHistory>();
            if (purchaseHistories != null)
            {
                foreach (PurchaseHistory purchase in purchaseHistories)
                {
                    purchase.ActivationCodes = dbcontext.PurchaseActivationCodes.Where(
                        model => model.PurchaseHistoryId == purchase.Id
                        ).ToList<PurchaseActivationCode>();
                }
            }
            return purchaseHistories;
        }

        public IsDone Checkout(List<Cart> cartList,User user)
        {
            IDbContextTransaction transcat = dbcontext.Database.BeginTransaction();
            try
            {
                //// Get the matching cart and user instances
                List<PurchaseHistory> purchaseHistories = new List<PurchaseHistory>();
                foreach (Cart cart in cartList)
                {
                    //purchaseHistory= dbcontext.PurchaseHistories
                    //    .Where(item => item.UserId == user.Id && item.ProductId == cart.ProductId).FirstOrDefault();
                    //if (purchaseHistory != null)
                    //{
                    //    purchaseHistory.Quantity += cart.Quantity;
                    //}
                    //else
                    //{
                    PurchaseHistory purchaseHistory = new PurchaseHistory()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserId = user.Id,
                            ProductId = cart.ProductId,
                            PurchaseDate = DateTime.UtcNow,
                            Quantity = cart.Quantity
                        };
                        dbcontext.PurchaseHistories.Add(purchaseHistory);
                    //}
                    purchaseHistories.Add(purchaseHistory);
                    //for (int i = 0; i < cart.Quantity; i++)
                    //{
                    //    PurchaseActivationCode purchaseActivationCode = new PurchaseActivationCode()
                    //    {
                    //        Id = Guid.NewGuid().ToString(),
                    //        PurchaseHistoryId = purchaseHistory.Id,
                    //        ActivationCode = Guid.NewGuid().ToString()
                    //    };
                    //    dbcontext.PurchaseActivationCodes.Add(purchaseActivationCode);
                    //}
                }
                foreach(PurchaseHistory item in purchaseHistories)
                {
                    for(int i = 0; i < item.Quantity; i++)
                    {
                        PurchaseActivationCode purchaseActivationCode = new PurchaseActivationCode()
                        {
                            Id = Guid.NewGuid().ToString(),
                            PurchaseHistoryId = item.Id,
                            ActivationCode = Guid.NewGuid().ToString()
                        };
                        dbcontext.PurchaseActivationCodes.Add(purchaseActivationCode);
                    }
                }

                dbcontext.SaveChanges();
                transcat.Commit();
                return new IsDone() { Done=true};
            }
            catch (Exception)
            {
                transcat.Rollback();
                return new IsDone() { Done = false };
            }
        }
    }
}
