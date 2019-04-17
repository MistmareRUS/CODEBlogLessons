using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_BL.Model
{
    class Sell
    {
        public int SellID { get; set; }
        public int CheckOD { get; set; }
        public int ProductID { get; set; }
        public virtual Check Check { get; set; }
        public virtual Product Product { get; set; }
    }
}
