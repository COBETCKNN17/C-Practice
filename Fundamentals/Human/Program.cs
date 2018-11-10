using System;

namespace Human {
    class Human {
        public string Name { get; set; }
        public int Strength { get; set; } = 3;
        public int Intelligence { get; set; } = 3;
        public int Dexterity { get; set; } = 3;
        public int Health { get; set; } = 100;
        public Human(string name)
        {
            Name = name;
            
        }
        public Human(string name, int strength, int intelligence, int dexterity, int health) :this(name)
        {
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }

        public void attack(Object otherHuman)
        {
            var subHuman = (Human)otherHuman;
            subHuman.Health -= 5 * Strength; 
        }
    }
    class Program {
        static void Main (string[] args) {
            var player1 = new Human("Hume");
            var player2 = new Human("Smith"); 
            player1.attack(player2);
            System.Console.WriteLine(player2.Health);
        }
    }
}