using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame
{
    class Game
    {
        private List<Player> _Players { get; }
        private PrsiGame _PrsiGame;

        public Game()
        {
            _Players = new List<Player>();
        }

        public void StartGame()
        {
            if(_Players.Count == 0)
                throw new InvalidOperationException("You cannot start game without players!");
                        
            Run();
        }

        public void RegisterPlayers(int PlayersNumber)
        {
            Console.WriteLine("Players registration.");
            for (int i = 0; i < PlayersNumber; i++)
            {
                Console.WriteLine("Write name of player number " + (i + 1));
                _Players.Add(new Player(Console.ReadLine()));
            }
            Console.WriteLine("Registration done!");

            _PrsiGame = new PrsiGame(_Players);
        }

        public void RestartGame()
        {
            _PrsiGame = new PrsiGame(_Players);
        }

        private void Run()
        {
            while (!_PrsiGame.GameOver)
                _PrsiGame.Turn();

            Console.Clear();
            Console.WriteLine("And winner is");
            Console.WriteLine(_PrsiGame.CurrendPlayer.ToString());
        }
    }
}
