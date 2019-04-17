using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class Check
    {
        public int CheckID { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int SellerID { get; set; }
        public virtual Seller Seller { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public override string ToString()
        {
            return $"№{CheckID} от {Created.ToString("dd.MM.YY:hh.mm.ss")}";
        }
    }
}
