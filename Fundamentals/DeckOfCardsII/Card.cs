namespace DeckOfCardsII {
    class Card {
        public string StringVal;
        public string Suit; 
        public int val; 
        
        public Card (string faceValue, string suitValue, int val) {
            StringVal = faceValue;
            Suit = suitValue;
            Value = val;
        }
    }
}