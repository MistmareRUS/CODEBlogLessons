using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerAndYield
{
    //класс, коллекция которых будет храниться в объекте и их возможно будет перебирать и вызывать по индексу
    class Car
    {        
        public string Name { get; set; }
        public string Number { get; set; }
        public override string ToString()
        {
            return Name + " " + Number;
        }
    }
}
