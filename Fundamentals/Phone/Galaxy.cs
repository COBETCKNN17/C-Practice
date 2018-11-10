using System; 

namespace Phone {
    public class Galaxy : Phone, IRingable {
        public Galaxy (string versionNumber, int batteryPercentage, string carrier, string ringTone) : base (versionNumber, batteryPercentage, carrier, ringTone) { }

       public string Ring () {
            return "Doo do do doo doo"; 
        }
        public string Unlock () {
            string s = string.Format("Unlocked Galaxy {0} with face recognition", version); 
            return s;
        }
        public override void DisplayInfo () {
            System.Console.WriteLine("$$$$$$$$$$$$$"); 
            System.Console.WriteLine("Galaxy {0}", version); 
            System.Console.WriteLine("Battery Percentage: {0}", batteryPercentage); 
            System.Console.WriteLine("Carrier: {0}", carrier); 
            System.Console.WriteLine("Ring Tone: {0}", ringTone); 
            System.Console.WriteLine("$$$$$$$$$$$$$"); 
        }
    }

}