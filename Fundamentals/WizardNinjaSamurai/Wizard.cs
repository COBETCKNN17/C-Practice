using System;

namespace WizardNinjaSamurai {
    public class Wizard : Human {
        public Wizard (string n) : base (n) {
            Health = 50;
            Intelligence = 25;
        }

        public void heal() 
        {
            Health += 10 * Intelligence; 
        }

        public void fireball(object recipient)
        {
            Human target = recipient as Human; 
            if (target != null)
            {
                Random rand = new Random(); 
                target.Health -= rand.Next(20, 51); 
            } 
        }
    }
}