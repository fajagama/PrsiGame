using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame
{
    class Card
    {
        public CardInfo.Values Value { get; }
        public CardInfo.Types Type { get; }

        public Card(CardInfo.Values Value, CardInfo.Types Type)
        {
            this.Value = Value;
            this.Type = Type;
        }

        public override string ToString()
        {
            return "Value: " + Value.ToString() + ", Type: " + Type.ToString();
        }
    }
}
