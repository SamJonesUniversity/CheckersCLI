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

            int c = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    c++;
                    if (c == 9 || c == 11 || c == 13 || c == 15 || c == 18 || c == 20 || c == 22 || c == 24)
                    {
                        board[i, j] = 0;
                    }
                    else if (i <= 1)
                    {
                        board[i, j] = 1;
                    }
                    else
                    {
                        board[i, j] = 2;
                    }
                }
            }

            draw.DrawDefualtBoard();
            Console.ReadLine();
            draw.UpdateBoard(board);
            Console.ReadLine();
        }
    }
}
