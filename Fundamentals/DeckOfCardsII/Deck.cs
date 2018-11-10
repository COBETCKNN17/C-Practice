namespace DeckOfCardsII
{
    class Deck {
        string[] stringVals = new string[] {
            "Ace",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Jack",
            "Queen",
            "King"
        };
        string[] suits = new string[] {
            "Clubs",
            "Spades",
            "Hearts",
            "Diamonds"
        };

        public List<Card> Cards = new List<Card>();

        public Deck () {
            foreach (string suit in suits) {
                int numVal = 1;
                foreach (var stringVal in stringVals) {
                    Card newCard = new Card (stringVal, suit, numVal);
                    Cards.Add(newCard);
                    numVal++;
                }
            }
        }
        public void ReadDeck () {
            foreach (Card card in Cards) {
                System.Console.WriteLine ($"{card.StringVal} of {card.Suit}");
            }
        }

        public void Shuffle ()
        {
            Random rand = new Random();
            for (int i =0; i < Cards.Count; i++)
            {
                int newIdx = rand.Next(Cards.Count);
                Card temp = Cards[i]; 
                Cards[i] = Cards[newIdx]; 
                Cards[newIdx] = temp;
            }
        }

        public Card Deal ()
        {
            Card dealtCard = Cards[0];
            Cards.Remove(dealtCard); 
            return dealtCard; 
        }
    }
}