using System;
using System.Collections.Generic; // To use lists

namespace CollectionsPractice
{
    class Program
    {
        public static void Collections()
        {

        // Arrays

        int[] intArray = {0,1,2,3,4,5,6,7,8,9};
        string[] strArray = {"Tim", "Martin", "Nikki", "Sara"};
        bool[] boolArray = {true, false, true, false, true, false, true, false, true, false};

        // Ice Cream List

        List<string> IceCream = new List<string>();
            IceCream.Add("Mint Chocolate Chip");
            IceCream.Add("Vanilla");
            IceCream.Add("Pistachio");
            IceCream.Add("Butter Pecan");
            IceCream.Add("Cookie Dough");

            Console.WriteLine(IceCream.Count);
            Console.WriteLine(IceCream[3]);
            IceCream.RemoveAt(3);
            Console.WriteLine(IceCream.Count);

        // User Info Dictionary

        Random random = new Random();
        Dictionary<string,string> favoriteFlavors = new Dictionary<string,string>();
            foreach (string name in strArray)
            {
                favoriteFlavors[name] = IceCream[random.Next(IceCream.Count)];
            }
            foreach (KeyValuePair<string,string> item in favoriteFlavors)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }    

        static void Main(string[] args)
        {
            Collections();
        }
    }
}