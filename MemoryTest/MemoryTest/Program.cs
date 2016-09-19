using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryLogic;

namespace MemoryTest
{
    class Program
    {
        static MemoryGame game = new MemoryGame(4, 4);

        static void Main(string[] args)
        {
            while (game.state == MemoryGame.Gamestate.Running || game.state == MemoryGame.Gamestate.Won)
            {
                var key = Console.ReadKey();
                game.Update(key.Key);

                if (game.state == MemoryGame.Gamestate.Won)
                {
                    Console.WriteLine("Press any key to restart!");
                    Console.ReadKey();
                    game.Update(ConsoleKey.R);
                }
            }
        }    
    }
}
