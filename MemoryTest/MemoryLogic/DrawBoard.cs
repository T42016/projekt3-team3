using System;


namespace MemoryLogic
{
    public class DrawBoard
    {
        
        private MemoryGame _memoryGame;

        public DrawBoard(MemoryGame memoryGame)
        {
            _memoryGame = memoryGame;
        }

        public void Draw()
        {
            _memoryGame.Draw.Clear();
            
            for (int y = 0; y < _memoryGame.SizeY; y++)
            {
                for (int x = 0; x < _memoryGame.SizeX; x++)
                {
                    if (x == _memoryGame.posX && y == _memoryGame.posY)
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;

                    var info = _memoryGame.GetCoordinate(x, y);
                    if (info.IsOpen)
                    {
                        Console.ForegroundColor = info.IsFound ? ConsoleColor.Green : ConsoleColor.Cyan;
                        _memoryGame.Draw.Write(MemoryGame.symbols[info.Value] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        _memoryGame.Draw.Write(". ");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            _memoryGame.Draw.WriteLine("Moves: " + _memoryGame.Moves);
            if (_memoryGame.HasMismatch)
                _memoryGame.Draw.WriteLine("Press any key");
        }
    }
}