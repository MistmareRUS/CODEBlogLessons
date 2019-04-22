using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            //arrange
            var customer1 = new Customer()
            {
                Name = "TestUser1",
                CustomerID = 1
            };
            var customer2 = new Customer()
            {
                Name = "TestUser2",
                CustomerID = 2
            };
            var seller = new Seller()
            {
                 Name="TestSeller",
                 SellerID=1
            };
            var product1 = new Product() { Name = "TestPR1", Price = 5, Count = 5, ProductID = 1 };
            var product2 = new Product() { Name = "TestPR2", Price = 10, Count = 10, ProductID = 2 };
            var cart1 = new Cart(customer1);
            var cart2 = new Cart(customer2);

            cart1.Add(product1);
            cart1.Add(product1);
            cart1.Add(product2);

            cart2.Add(product2);
            cart2.Add(product2);
            var cashDesk = new CashDesk(1, seller);
            cashDesk.MaxQueueLenght = 10;
            cashDesk.Enqueue(cart1);
            cashDesk.Enqueue(cart2);

            var cart1Res = 20;
            var cart2Res = 20;
            //act
            var cart1ActualResult = cashDesk.Dequeue();
            var cart2ActualResult = cashDesk.Dequeue();


            //assert
            Assert.AreEqual(cart1Res, cart1ActualResult);
            Assert.AreEqual(cart2Res, cart2ActualResult);

            Assert.AreEqual(3, product1.Count);
            Assert.AreEqual(7, product2.Count);
        }        
    }
}