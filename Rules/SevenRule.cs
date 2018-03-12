using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame.Rules
{
    class SevenRule : Rule
    {
        public SevenRule(Rule PreviousRule) : base("Choice card with VII value.")
        {
            _takeCards = 2;

            if (PreviousRule is SevenRule)
                _takeCards += PreviousRule.TakeCards;
        }

        public override bool CanUseCard(Card LastCard, Card SelectedCard)
        {
            return SelectedCard.Value.Equals(LastCard.Value);
        }
    }
}
