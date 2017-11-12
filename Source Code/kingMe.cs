using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class kingMe
    {   
        /// <summary>
        /// Checks the board for any pieces on the opposite side of the board from which they started.
        /// If so then change that piece to that teams king piece.
        /// </summary>
        /// <param name="board"></param>
        /// <returns> the updated instance of the board </returns>
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
