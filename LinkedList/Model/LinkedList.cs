using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Model
{
    class LinkedList<T>
    {
        public Item<T> Head { get; private  set; }
        public Item<T> Tail { get; private set; }
        public int Count { get; private set; }
        public LinkedList()
        {
            Head = null;
            Head.Next = null;//
            Tail = null;
            Tail.Next = null;//
            Count = 0;
        }
        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Head.Next = null;///
            Tail.Next = null;///

        }
        public void Add(T data)
        {
            var item = new Item<T>(data);
            if (Tail != null)
            {
                Tail.Next = item;
                Tail = item;
            }
            else
            {
                Head = item;
                Tail = item;
            }
            Count++;
        }
    }
}
