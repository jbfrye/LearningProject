using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_8
{
    // 8.1
    class BlackJack
    {
        CardDeck deck;
        int totalPlayers;
        Player[] players;

        public BlackJack(int p)
        {
            deck = new CardDeck();
            totalPlayers = p;
            players = new Player[totalPlayers];
            for (int i = 0; i < totalPlayers; i++)
                players[i] = new Player();
        }

        public void Deal()
        {
            for (int i = 0; i < totalPlayers; i++)
            {
                players[i].hand = new Hand(deck);
            }
        }
    }

    class Player
    {
        public Hand hand;

        public Player()
        { }
    }

    class Hand
    {
        ArrayList cards;
        public Hand(CardDeck deck)
        {
            cards = new ArrayList();
            cards.Add(deck.DrawCard());
            cards.Add(deck.DrawCard());
        }
    }

    class CardDeck
    {
        ArrayList deck = new ArrayList();

        public CardDeck()
        {
            // Initialize the deck
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck.Add(new Card((Card.Suit)i, (Card.Number)j));
                    count++;
                }
            }
        }

        public void RandomizeDeck()
        {
            Random r = new Random();
            ArrayList randomList = new ArrayList();
            randomList = (ArrayList)deck.Clone();
            deck.Clear();
            int randomIndex = 0;

            while (randomList.Count > 0)
            {
                randomIndex = r.Next(0, randomList.Count);
                deck.Add(randomList[randomIndex]);
                randomList.RemoveAt(randomIndex);
            }
        }

        public Card DrawCard()
        {
            Card card = (Card)deck[0];
            deck.RemoveAt(0);
            return card;
        }

        public static void RunCardDeck()
        {
            CardDeck deck = new CardDeck();
            deck.RandomizeDeck();
            Console.WriteLine(deck.DrawCard().PrintCard());
        }
    }

    class Card
    {
        public enum Suit { Club, Jack, Spade, Heard };
        public enum Number { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

        Suit suit;
        Number number;

        public Card()
        {
            suit = 0;
            number = 0;
        }

        public Card(Suit s, Number n)
        {
            suit = s;
            number = n;
        }

        public string PrintCard()
        {
            return number + ", " + suit;
        }
    }
}
