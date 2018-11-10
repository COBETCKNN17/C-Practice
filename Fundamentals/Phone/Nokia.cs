namespace Phone {
    public class Nokia : Phone, IRingable {
        public Nokia (string versionNumber, int batteryPercentage, string carrier, string ringTone) : base (versionNumber, batteryPercentage, carrier, ringTone) { }
        public string Ring () {
            return "Ringgg ring ringgg";
        }
        public string Unlock () {
            string s = string.Format("Unlocked Nokia {0} with passcode", version); 
            return s;
        }
        public override void DisplayInfo () {
            System.Console.WriteLine("############"); 
            System.Console.WriteLine ("Nokia {0}", version);
            System.Console.WriteLine ("Battery Percentage: {0}", batteryPercentage);
            System.Console.WriteLine ("Carrier: {0}", carrier);
            System.Console.WriteLine ("Ring Tone: {0}", ringTone);
            System.Console.WriteLine("############"); 
        }
    }
}