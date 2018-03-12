using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame.Rules
{
    abstract class Rule
    {
        public int TakeCards { get { return _takeCards; } }
        public String RuleInfo { get; }
        protected int _takeCards = 1;

        public Rule(String RuleInfo)
        {
            this.RuleInfo = RuleInfo;
        }

        abstract public bool CanUseCard(Card LastCard, Card SelectedCard);
      
    }
}
