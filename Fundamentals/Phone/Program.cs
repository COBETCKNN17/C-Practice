using System;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Galaxy s8 = new Galaxy("s8", 100, "T-Mobile", "Dooooo Doooo"); 
            Nokia elevenHundred = new Nokia("1100", 60, "Metro PCS", "Ringggggg"); 

            s8.DisplayInfo(); 
            Console.WriteLine(s8.Ring()); 
            Console.WriteLine(s8.Unlock()); 
            Console.WriteLine(""); 
            
            elevenHundred.DisplayInfo(); 
            Console.WriteLine(elevenHundred.Ring()); 
            Console.WriteLine(elevenHundred.Unlock()); 
            Console.WriteLine(""); 
        }
    }
}
