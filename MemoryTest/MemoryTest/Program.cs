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
            while (true)
            {
                var key = Console.ReadKey();
                game.Update(key.Key);
            }

        }     

        

    }
}
