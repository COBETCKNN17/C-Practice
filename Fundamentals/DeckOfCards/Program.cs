using System;
using System.Collections.Generic;

namespace DeckOfCards {
    class Card {
        public string StringVal { get; set; }

        public string Suit { get; set; }
        public int Value { get; set; }

        public Card (string faceValue, string suitValue, int val) {
            StringVal = faceValue;
            Suit = suitValue;
            Value = val;
        }
    }
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

        public List<Card> Cards = new List<Card> ();

        public Deck () {
            foreach (string suit in suits) {
                int numVal = 1;
                foreach (var stringVal in stringVals) {
                    Card newCard = new Card (stringVal, suit, numVal);
                    Cards.Add (newCard);
                    numVal++;
                }
            }
        }
        public void ReadDeck () {
            foreach (Card card in Cards) {
                System.Console.WriteLine ($"{card.StringVal} of {card.Suit}");
            }
        }

        public void Shuffle () {
            Random rand = new Random ();
            for (int i = 0; i < Cards.Count; i++) {
                int newIdx = rand.Next (Cards.Count);
                Card temp = Cards[i];
                Cards[i] = Cards[newIdx];
                Cards[newIdx] = temp;
            }
        }

        public Card Deal () {
            Card dealtCard = Cards[0];
            Cards.Remove (dealtCard);
            return dealtCard;
        }
    }

    class Player {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card> ();

        public Card Draw (Deck theDeck) {
            var drawnCard = theDeck.Deal ();
            Hand.Add (drawnCard);
            return drawnCard;
        }

        public Card Discard (int index) {
            if (Hand[index] != null) {
                Card card = Hand[index];
                Hand.Remove (card);
                return card;
            }
            else
            {
                return null; 
            }
        }
    }

    class Program {
        static void Main (string[] args) {
            Deck deck = new Deck ();
            deck.ReadDeck ();
            deck.Shuffle ();
            deck.ReadDeck ();
            Player felix = new Player (); 
            felix.Draw(deck); 
            System.Console.WriteLine("Felix's Hand: " + felix.Hand[0].Suit);  
        }
    }

}