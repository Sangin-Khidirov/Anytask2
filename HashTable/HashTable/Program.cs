using System;
using System.Collections.Generic;
using System.Linq;


namespace Hash
{
    public class Program
    {
        class Item
        {
            public object Value;
            public readonly int Key;
            public Item(int key, object value)
            {
                Value = value;
                Key = key;
            }
        }

        public class HashTable
        {
            private List<Item>[] list;

            public HashTable(int size)
            {
                list = new List<Item>[size];
            }

            public void PutPair(object key, object value)
            {
                var keyHashCode = key.GetHashCode();
                var id = Math.Abs(keyHashCode) % list.Length;
                var item = new Item(keyHashCode, value);

                if (list[id] == null)
                {
                    list[id] = new List<Item> { item };
                }

                else
                {
                    var val = list[id].FirstOrDefault(x => x.Key == keyHashCode);

                    if (val != null)
                        val.Value = value;
                    else
                        list[id].Add(item);
                }
            }

            public object GetValueByKey(object key)
            {
                try
                {
                    var keyHashCode = key.GetHashCode();
                    var id = Math.Abs(keyHashCode) % list.Length;
                    var value = list[id];
                    return value.FirstOrDefault(x => x.Key == keyHashCode).Value;
                }

                catch
                {
                    return null;
                }
            }
        }

        static void Main(string[] args)
        {
        }
    }
}