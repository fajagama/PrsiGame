using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame.Rules
{
    class AceRule : Rule
    {
        public AceRule() : base("Choice card with Ace value.")
        {
            _takeCards = 0;
        }

        public override bool CanUseCard(Card LastCard, Card SelectedCard)
        {
            return SelectedCard.Value.Equals(LastCard.Value);
        }
    }
}
