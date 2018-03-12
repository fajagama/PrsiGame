using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrsiGame.Rules;

namespace PrsiGame
{
    class Game
    {
        private CardPack _MainCardPack { get; }
        private CardPack _UsedCards { get; }
        private List<Player> _Players { get; }
        private Card _LastCard;
        private Rule _ActiveRule;
        private int _CurrentPlayer = 0;
        private bool _GameRun = true;

        public Player CurrendPlayer { get { return _Players[_CurrentPlayer]; } }

        public Game(int PlayersNumber)
        {
            _MainCardPack = new CardPack();
            _MainCardPack.CreateNewPack();
            _UsedCards = new CardPack();
            _Players = new List<Player>();

            _LastCard = _MainCardPack.RemoveCard();
            _ActiveRule = new NormalRule();

            RegisterPlayers(PlayersNumber);
            CardDistribution();
        }

        public void Turn()
        {
            Console.Clear();
            Console.WriteLine("Player " + CurrendPlayer.Name + " playing.");
            Console.WriteLine("Current card on table " + _LastCard.ToString());
            Console.WriteLine("Info: " + _ActiveRule.RuleInfo);
            Console.WriteLine("Choice index of card or write 0 for skip turn.");

            for (int i = 0; i < CurrendPlayer.Cards.Count; i++)
                Console.WriteLine((i + 1) + " - for " + CurrendPlayer.Cards[i]);

            int PlayerInput;

            while (true)
            {
                try
                {
                    PlayerInput = Int32.Parse(Console.ReadLine());
                    if (PlayerInput == 0)
                        PlayerTakeCard();
                    else
                        if (!PlayerChoiceCard(PlayerInput - 1))
                            continue;                        

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("No, you can not do ths! Try it again.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("No, you can not do ths! Try it again.");
                }
            }
            NextPlayer();
        }

        public Boolean GameOver()
        {
            return !_GameRun;
        }

        private void RegisterPlayers(int PlayersNumber)
        {
            Console.WriteLine("Players registration.");
            for (int i = 0; i < PlayersNumber; i++)
            {
                Console.WriteLine("Write name of player number " + (i + 1));
                _Players.Add(new Player(Console.ReadLine()));
            }
            Console.WriteLine("Registration done!");
        }

        private void CardDistribution()
        {
            foreach(Player player in _Players)
            {
                for (int i = 0; i < 4; i++)
                    player.AddCard(_MainCardPack.RemoveCard());
            }
        }

        private void PlayerTakeCard()
        {
            for (int i = 0; i < _ActiveRule.TakeCards; i++)
            {
                try
                {
                    CurrendPlayer.AddCard(_MainCardPack.RemoveCard());
                }
                catch (IndexOutOfRangeException)
                {
                    _UsedCards.Shuffle();
                    _MainCardPack.MergePack(_UsedCards.Cards);
                    _UsedCards.Cards.Clear();
                    i--;
                }
            }
            if (!(_ActiveRule is NormalRule || _ActiveRule is OberRule))
                _ActiveRule = new NormalRule();
        }

        private Boolean PlayerChoiceCard(int index)
        {
            if (_ActiveRule.CanUseCard(_LastCard, CurrendPlayer.Cards[index]))
            {
                _UsedCards.AddCard(_LastCard);
                _LastCard = CurrendPlayer.RemoveCard(index);
                SetNewRule();
                return true;
            }

            Console.WriteLine("No, you can not use this card!");
            Console.WriteLine("Try it again.");
            return false;
        }

        private void SetNewRule()
        {
            switch(_LastCard.Value)
            {
                case CardInfo.Values.VII:
                    _ActiveRule = new SevenRule(_ActiveRule);
                    break;
                case CardInfo.Values.Ace:
                    _ActiveRule = new AceRule();
                    break;
                case CardInfo.Values.Ober:
                    _ActiveRule = new OberRule(ChoiseType());
                    break;
                default:
                    _ActiveRule = new NormalRule();
                    break;
            }
        }

        private CardInfo.Types ChoiseType()
        {
            foreach (CardInfo.Types Type in Enum.GetValues(typeof(CardInfo.Types)))
            {
                Console.WriteLine(Type);
            }
            Console.WriteLine("Write 0 - 3 for your choice");

            while (true)
            {
                try
                {
                    return (CardInfo.Types)Enum.GetValues(typeof(CardInfo.Types)).GetValue(Int32.Parse(Console.ReadLine()));
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("No, you can not do ths! Try it again.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("No, you can not do ths! Try it again.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("No, you can not do ths! Try it again.");
                }
            }
        }

        private void NextPlayer()
        {
            if (CurrendPlayer.Cards.Count == 0) {
                _GameRun = false;
                return;
            }
            
            _CurrentPlayer++;
            if (_CurrentPlayer >= _Players.Count)
                _CurrentPlayer = 0;
        }
    }
}
