using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame.Rules
{
    class NormalRule : Rule
    {
        public NormalRule() : base("Choice card with same type or value.")
        {

        }

        public override bool CanUseCard(Card LastCard, Card SelectedCard)
        {
            return (SelectedCard.Value.Equals(LastCard.Value) || SelectedCard.Type.Equals(LastCard.Type) || SelectedCard.Value.Equals(CardInfo.Values.Ober));
        }
    }
}
