using System;

namespace WizardNinjaSamurai {
    class Program {
        static void Main (string[] args) {
            Wizard Gandalf = new Wizard("Gandalf");
            System.Console.WriteLine(Gandalf.Health);  
            Ninja Jee = new Ninja("Jee"); 
            Jee.get_away(); 
            System.Console.WriteLine(Jee.Health); 
            Samurai Sam = new Samurai("Sam");  
        }
    }
}