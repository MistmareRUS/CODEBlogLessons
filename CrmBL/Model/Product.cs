using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            if(obj is Product p)
            {
                return ProductID.Equals(p.ProductID);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ProductID;
        }
    }
}
