using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Model
{
    public class Item<T>
    {
        private T data = default(T);
        public Item<T> Next { get; set; }

        public T Data
        { get
            {
                return data;
            }
            set
            {
                if (value != null)
                {
                    data = value;
                }
            }
        }
        public Item(T data)
        {
            this.Data = data;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
