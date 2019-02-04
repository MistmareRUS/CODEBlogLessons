using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    sealed class Road
    {
        string Number { get; set; }
        int Lentht { get; set; }
        public override string ToString()
        {
            return $"Дорога {Number} общей протяженностью {Lentht}.\n";
        }
        public Road(string num,int len)
        {
            Number = num;
            Lentht = len;
        }
    }
}
