﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MemoryLogic;

namespace MemoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose what to do!");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Exit");

                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "play":
                        int x;
                        int y;
                        Console.WriteLine("Choose board size: x,y");
                        string boardInput = Console.ReadLine();

                        try
                        {
                            x = int.Parse(boardInput[0].ToString());
                            y = int.Parse(boardInput[2].ToString());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bad input!");
                            Console.ReadKey();
                            break;
                        }

                        if (x < 2 || x > 6 || y < 2 || y > 6 || x*y % 2 != 0)
                        {
                            Console.WriteLine("Bad input!");
                            Console.ReadKey();
                            break;
                        }

                        MemoryGame game = new MemoryGame(x, y, new SB());

                        while (game.state == MemoryGame.Gamestate.Running)
                        {
                            var key = Console.ReadKey();
                            game.Update(key.Key);
                        }

                        if (game.state == MemoryGame.Gamestate.Won)
                        {
                            Console.WriteLine("You won!");
                            Console.WriteLine("Press any key to return to the menu");
                            Console.ReadKey();
                            game.Update(ConsoleKey.R);
                        }
                        break;
                    case "2":
                    case "exit":
                    case "quit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Bad input!");
                        Console.ReadKey();
                        break;
                }
            }
        }    
    }
}
