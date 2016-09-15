using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLogic
{
    public class MemoryGame
    {
        private bool Check = false;
        enum Gamestate
        {
            Running,
            Won
        }
        Gamestate state;
        private bool Check = false;
        public int SizeX { get; }
        public int SizeY { get; }
        public int Moves { get; private set; }
        public bool HasMismatch => lastOpened.Count == 2;
         
        public MemoryGame(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            _board = new PositionInfo[sizeX, sizeY];
            ResetBoard();
            state = Gamestate.Running;
        }

        private PositionInfo[,] _board;
        private List<PositionInfo> lastOpened = new List<PositionInfo>();

        public void ResetBoard()
        {
            Random rnd = new Random();
            List<int> values = new List<int>();
            Moves = 0;

            for (int i = 0; i < SizeX*SizeY; i++)
                values.Add(i/2);

            for (int x = 0; x < SizeX; x++)
                for (int y = 0; y < SizeY; y++)
                {
                    int index = rnd.Next(values.Count);
                    _board[x, y] = new PositionInfo()
                    {
                        X = x,
                        Y = y,
                        Value = values[index]
                    };
                    values.RemoveAt(index);
                }
        }

        public PositionInfo GetCoordinate(int x, int y)
        {
            if (x < 0 || x >= SizeX || y < 0 || y > SizeY)
                throw new IndexOutOfRangeException();

            return _board[x, y];
        }

        public void CloseMismatch()
        {
            if (lastOpened.Count == 0)
                return;

            lastOpened.ForEach(c => c.IsOpen = false);
            lastOpened.Clear();
        }

        public void ClickCoordinate(int x, int y)
        {
            var coord = GetCoordinate(x, y);
            if (coord.IsOpen || lastOpened.Count == 2)
                return;

            coord.IsOpen = true;
            if (lastOpened.Count == 1 && lastOpened.First().Value == coord.Value)
            {
                coord.IsFound = true;
                lastOpened.First().IsFound = true;
                lastOpened.Clear();
                Moves++;
            }
            else
            {
                lastOpened.Add(coord);
                if(lastOpened.Count == 2)
                    Moves++;
            }
            Check = false;
            for (int X = 0; X < SizeX; X++)
            {
                for (int Y = 0; Y < SizeY; Y++)
                {
                    if (!_board[X, Y].IsFound)
                    {
                        Check = true;
                    }
                }
            }
            Check = false;
            for (int X = 0; X < SizeX; X++)
            {
                for (int Y = 0; Y < SizeY; Y++)
                {
                    if (!_board[X, Y].IsFound)
                    {
                        Check = true;
                    }
            if (!Check)
                state = Gamestate.Won;
         }

        private void GameWon()
        {
            Console.WriteLine("You won");
            Console.ReadLine();
            ResetBoard();
                }
            }
            if (!Check)
                GameWon();
         }

        private void GameWon()
        {
            Console.WriteLine("You won");
            Console.ReadLine();
            ResetBoard();
        }
    }
}
