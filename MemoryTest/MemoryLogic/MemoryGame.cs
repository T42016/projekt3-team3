﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryLogic;

namespace MemoryLogic
{
    public class MemoryGame
    {
        public enum Gamestate
        {
            Running,
            Won
        }

        public ISB Draw;
        public static char[] symbols { get; private set; } = { '*', '!', 'w', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };
        public Gamestate state { get; set; }
        public int posX { get; private set; }
        public int posY { get; private set; }
        private bool allFound = false;
        public int SizeX { get; }
        public int SizeY { get; }
        public int Moves { get; private set; }
        public bool HasMismatch => lastOpened.Count == 2;
         
        public MemoryGame(int sizeX, int sizeY, ISB draw)
        {
            Draw = draw;
            SizeX = sizeX;
            SizeY = sizeY;
            _board = new PositionInfo[sizeX, sizeY];
            _drawBoard = new DrawBoard(this);
            ResetBoard();
            state = Gamestate.Running;
        }

        private PositionInfo[,] _board;
        private List<PositionInfo> lastOpened = new List<PositionInfo>();
        private readonly DrawBoard _drawBoard;

        public void ResetBoard()
        {
           
            List<int> values = new List<int>();
            Moves = 0;

            for (int i = 0; i < SizeX*SizeY; i++)
                values.Add(i/2);

            for (int x = 0; x < SizeX; x++)
                for (int y = 0; y < SizeY; y++)
                {
                    int index = Draw.Next(values.Count);
                    _board[x, y] = new PositionInfo()
                    {
                        X = x,
                        Y = y,
                        Value = values[index]
                    };
                    values.RemoveAt(index);
                }

            posY = 0;
            posX = 0;

            state = Gamestate.Running;

            _drawBoard.Draw();
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

        public void ClickCoordinate()
        {
            var coord = GetCoordinate(posX, posY);
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

            allFound = true;
            for (int X = 0; X < SizeX; X++)
            {
                for (int Y = 0; Y < SizeY; Y++)
                {
                    if (!_board[X, Y].IsFound)
                    {
                        allFound = false;
                    }
                }
            }

            if (allFound)
                state = Gamestate.Won;
        }

        public void Update(ConsoleKey key)
        {
            if (HasMismatch)
                CloseMismatch();

            if (key == ConsoleKey.LeftArrow && posX > 0)
                    posX--;
            if (key == ConsoleKey.RightArrow && posX < SizeX - 1)
                    posX++;
            if (key == ConsoleKey.UpArrow && posY > 0)
                    posY--;
            if (key == ConsoleKey.DownArrow && posY < SizeY - 1)
                    posY++;
            if (key == ConsoleKey.R)
                    ResetBoard();
            if (key == ConsoleKey.Spacebar || key == ConsoleKey.Enter)
                    ClickCoordinate();

            _drawBoard.Draw();
        }

        private void GameWon()
        {
            Console.WriteLine("You won");
            Console.ReadLine();
            ResetBoard();
        }
    }
}
