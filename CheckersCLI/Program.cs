using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardDraw draw = new BoardDraw();
            int[,] board = new int[4,8];

            BoardArray nBoard = new BoardArray();

            nBoard.BoardCreate(board);
            draw.UpdateBoard(board);
            Console.ReadLine();
        }
    }
}
