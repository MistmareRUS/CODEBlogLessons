using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class CashDesk
    {
        CRMContext db = new CRMContext();
        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> Queue { get; set; }
        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; } = true;
        public CashDesk(int number,Seller seller)
        {
            Seller = seller;
            Number = number;
            Queue = new Queue<Cart>();
        }
        public void Enqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            else { ExitCustomer++; }
        }
        public decimal Dequeue()
        {
            decimal sum=0;
            var cart=Queue.Dequeue();
            if (cart != null)
            {
                var check = new Check()
                {
                    SellerID = Seller.SellerID,
                    Seller = Seller,
                    CustomerID = cart.Customer.CustomerID,
                    Customer = cart.Customer,
                    Created = DateTime.Now
                };
                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckID = 0;
                }
                var sells = new List<Sell>();
                foreach (Product p in cart)
                {
                    if (p.Count > 0)
                    {

                        var sell = new Sell()
                        {
                            CheckOD = check.CheckID,
                            Check = check,
                            ProductID = p.ProductID,
                            Product = p
                        };
                        sells.Add(sell);
                        if (!IsModel)
                        {
                            db.Sells.Add(sell);
                        }
                        p.Count--;
                        sum += p.Price;
                    }
                }
                if (!IsModel)
                {
                    db.SaveChanges(); 
                }
            }
            return sum;
        }
    }
}
