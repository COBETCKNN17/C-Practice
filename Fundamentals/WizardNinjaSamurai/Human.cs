namespace WizardNinjaSamurai {
    public class Human {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Health { get; set; } = 100;
        public Human (string person) {
            Name = person;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }
        public Human (string name, int strength, int intelligence, int dexterity, int health) : this (name) {
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }

        public void attack (object otherHuman) {
            var subHuman = (Human) otherHuman;
            subHuman.Health -= 5 * Strength;
        }
    }
}