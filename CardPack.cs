using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame
{
    class CardPack
    {
        public List<Card> Cards { get; set; }
        public int CardCount { get { return Cards.Count; } }

        public CardPack()
        {
            Cards = new List<Card>();
        }

        public void CreateNewPack()
        {
            foreach (CardInfo.Values Value in Enum.GetValues(typeof(CardInfo.Values)))
            {
                foreach (CardInfo.Types Type in Enum.GetValues(typeof(CardInfo.Types)))
                {
                    Cards.Add(new Card(Value, Type));
                }
            }
            Shuffle();
        }
        
        public void MergePack(List<Card> Cards)
        {
            Cards.AddRange(Cards);
        }

        public void AddCard(Card Card)
        {
            Cards.Add(Card);
        }

        public Card RemoveCard()
        {
            Card Card = Cards.First<Card>();
            Cards.Remove(Card);
            return Card;
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(item => new Random(Guid.NewGuid().GetHashCode()).Next()).ToList();
        }
    }
}
