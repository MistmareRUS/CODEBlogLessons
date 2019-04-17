using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_BL.Model
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public virtual ICollection <Check> Checks { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
