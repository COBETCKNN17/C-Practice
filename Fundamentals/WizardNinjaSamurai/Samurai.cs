using System;

namespace WizardNinjaSamurai {

    public class Samurai : Human {
        public static int count = 0;
        public Samurai (string n) : base (n) {
            count++;
            Health = 200;
        }

        public void death_blow (object victim) {
            Human enemy = victim as Human;
            if (enemy.Health < 50) {
                Health = 0;
            }
        }

        public void meditate () {
            Health = 200;
        }
        public static void how_many () {
            Console.WriteLine (count);
        }
    }
}