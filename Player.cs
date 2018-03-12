using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame
{
    class Player
    {
        public String Name { get; }
        public List<Card> Cards { get; }

        public int CardsCount { get { return Cards.Count; } }

        public Player(String Name)
        {
            this.Name = Name;
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public Card RemoveCard(int index)
        {
            return RemoveCard(Cards[index]);
        }

        public Card RemoveCard(Card card)
        {
            Cards.Remove(card);
            return card;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
