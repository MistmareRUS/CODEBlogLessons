﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_BL.Model
{
    class Product
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
    }
}
