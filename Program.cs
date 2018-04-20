using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsiGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game LetsPlay = new Game();
            LetsPlay.RegisterPlayers(2);
            LetsPlay.StartGame();
            
            Console.ReadLine();
        }
    }
}
