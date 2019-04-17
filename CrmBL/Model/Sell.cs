using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class Sell
    {
        public int SellID { get; set; }
        public int CheckOD { get; set; }
        public int ProductID { get; set; }
        public virtual Check Check { get; set; }
        public virtual Product Product { get; set; }
    }
}
