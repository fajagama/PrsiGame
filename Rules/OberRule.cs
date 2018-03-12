using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame.Rules
{
    class OberRule : Rule
    {
        private CardInfo.Types NewType;
        public OberRule(CardInfo.Types NewType) : base("Choice card with same value or value " + NewType + ".")
        {
            this.NewType = NewType;
        }

        public override bool CanUseCard(Card LastCard, Card SelectedCard)
        {
            return SelectedCard.Value.Equals(LastCard.Value) || SelectedCard.Type.Equals(NewType);
        }
    }
}
