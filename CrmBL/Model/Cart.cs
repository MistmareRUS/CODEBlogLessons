using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class Cart:IEnumerable
    {
        public Customer Customer { get; set; }
        public Dictionary<Product,int> Products { get; set; }
        public Cart(Customer c)
        {
            Customer = c;
            Products = new Dictionary<Product, int>();
        }
        public void Add(Product p)
        {
            if(Products.TryGetValue(p,out int count))
            {
                Products[p] = ++count;
            }
            else
            {
                Products.Add(p, 1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var product in Products.Keys)
            {
                for(int i = 0; i < Products[product]; i++)
                {
                    yield return product; 
                }
            }
        }   
        public List<Product> GetAll()
        {
            var result = new List<Product>();
            foreach (Product i in this)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
