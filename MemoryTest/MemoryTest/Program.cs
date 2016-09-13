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
        private static int posX = 0;
        private static int posY = 0;
        static MemoryGame game = new MemoryGame(4, 4);
        private static char[] symbols = {'*', '!', 'w', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o'};

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Draws: " + game.Draws);
                if (game.HasMismatch)
                    Console.WriteLine("Press any key");

                var key = Console.ReadKey();

                if (game.HasMismatch)
                {
                    game.CloseMismatch();
                    continue;
                }

                if (key.Key == ConsoleKey.LeftArrow && posX > 0)
                    posX--;
                if (key.Key == ConsoleKey.RightArrow && posX < game.SizeX - 1)
                    posX++;
                if (key.Key == ConsoleKey.UpArrow && posY > 0)
                    posY--;
                if (key.Key == ConsoleKey.DownArrow && posY < game.SizeY - 1)
                    posY++;
                if(key.Key == ConsoleKey.R)
                    game.ResetBoard();
                if (key.Key == ConsoleKey.Spacebar)
                    game.ClickCoordinate(posX, posY);
            }
        }

        static void DrawBoard()
        {
            for (int y = 0; y < game.SizeY; y++)
            {
                for (int x = 0; x < game.SizeX; x++)
                {
                    if (x == posX && y == posY)
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    var info = game.GetCoordinate(x, y);
                    if (info.IsOpen)
                    {
                        Console.ForegroundColor = info.IsFound ? ConsoleColor.Green : ConsoleColor.Cyan;
                        Console.Write(symbols[info.Value] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
