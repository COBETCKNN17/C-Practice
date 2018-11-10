using System;

namespace WizardNinjaSamurai {

    public class Ninja : Human 
    {
        public Ninja (string n) : base(n)
        {
            Health = 175; 
        }

        public void Steal(object victim)
        {
            Human enemy = victim as Human; 
            if(enemy != null){
                Health += 10; 
            } 
        }

        public void get_away()
        {
            Health -= 15; 
        }
    }
}