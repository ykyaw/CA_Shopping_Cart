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

        public List<PurchaseHistory> GetPurchaseHistories()
        {
            List<PurchaseHistory> purchaseHistories = dbcontext.PurchaseHistories.ToList<PurchaseHistory>();
            foreach(PurchaseHistory purchase in purchaseHistories)
            {
                purchase.ActivationCodes = dbcontext.PurchaseActivationCodes.Where(
                    model=>model.PurchaseHistoryId==purchase.Id
                    ).ToList<PurchaseActivationCode>();
            }
            return purchaseHistories;
        }
    }
}
