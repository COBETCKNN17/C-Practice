using System;
using System.Collections.Generic;

namespace Boxing {
    class Program {
        public static void Boxing () {
            var box = new List<object>(); 
            box.Add(7);
            box.Add(28);
            box.Add(-1);
            box.Add(true);
            box.Add("chair");

            // printing each item in the list 
            foreach (var o in box) {
                Console.WriteLine (o);
            }
            
            // if the item is an integer, add it up to a sum 
            int sum = 0; 
            foreach(var o in box)
            {
                if (o is int)
                {
                    sum += (int)o; 
                }
            }
            Console.WriteLine(sum);
        }
        static void Main (string[] args) {
            Boxing(); 
        }
    }
}