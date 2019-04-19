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
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            //AAA Arrange/Act/Assert

            Customer customer = new Customer() { Name = "TestUser",CustomerID=1 };
            var product1 = new Product() { Name = "TestPR1", Price = 5, Count = 5,ProductID=1 };
            var product2 = new Product() { Name = "TestPR2", Price = 10, Count = 10,ProductID=2 };
            var cart=new Cart(customer);
            var expectedResult = new List<Product>() { product1, product1, product2 };

            cart.Add(product1);
            cart.Add(product1);
            cart.Add(product2);

            var cartResult = cart.GetAll();

            Assert.AreEqual(expectedResult.Count, cart.GetAll().Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], cartResult[i]);
            }
        }        
    }
}