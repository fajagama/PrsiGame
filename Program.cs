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
            Game LetsPlay = new Game(2);

            while (!LetsPlay.GameOver())
            {
                LetsPlay.Turn();
            }
            Console.Clear();
            Console.WriteLine("And winner is");
            Console.WriteLine(LetsPlay.CurrendPlayer.ToString());
            Console.WriteLine();
        }
    }
}
