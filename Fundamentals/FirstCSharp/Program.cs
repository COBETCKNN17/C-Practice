using System;

namespace FirstCSharp {
    class Program {
        static void Main (string[] args) {

            int rings = 5;
            if (rings >= 5) {
                Console.WriteLine ("You are welcome to join the party");
            } else if (rings > 2) {
                Console.WriteLine ("Decent...but {0} rings aren't enough", rings);
            } else {
                Console.WriteLine ("Go win some more rings");
            }

            for (int i = 1; i <= 5; i++) {
                Console.WriteLine (i);
            }
            // loop from 1 to 5 excluding 5
            for (int i = 1; i < 5; i++) {
                Console.WriteLine (i);
            }

            // loop from 1 to 5 including 5
            for (int i = 1; i <= 5; i++) {
                Console.WriteLine (i);
            }
            // loop from 1 to 5 excluding 5
            for (int i = 1; i < 5; i++) {
                Console.WriteLine (i);
            }

        }
    }
}