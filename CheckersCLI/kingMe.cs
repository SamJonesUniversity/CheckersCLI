using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class kingMe
    {
        public int[,] kinged(int[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                if (board[0, i] == 2)
                {
                    board[0, i] = 9;
                }

            }

            for (int i = 0; i < 8; i++)
            {
                if (board[7, i] == 1)
                {
                    board[7, i] = 8;
                }

            }

            return board;
        }
    }
}
