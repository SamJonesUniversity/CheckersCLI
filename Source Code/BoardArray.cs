using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class BoardArray
    {
        /// <summary>
        /// Creates the first defualt instance of the board. Only used once
        /// </summary>
        /// <param name="board"></param>
        /// <returns> Base board for a new game. </returns>
        public int[,] BoardCreate(int[,] board)
        {
            int c = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    c++;

                    //Sets the half of the board which is not to be used to 3.
                    if((i % 2 == 0 & j % 2 == 0) || (i % 2 != 0 & j % 2 != 0))
                    {
                        board[i, j] = 3;
                    }

                    //Empty tiles
                    else if (c >= 25 & c <= 40)
                    {
                        board[i, j] = 0;
                    }

                    //Player ones pieces.
                    else if (i <= 2)
                    {
                        board[i, j] = 1;
                    }

                    //Player twos pieces.
                    else
                    {
                        board[i, j] = 2;
                    }

                }
            }

            return board;

            //**THIS CODE IS FOR TESTING PUPROSES ONLY**//
            /*
            int c = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = 0;
                    c++;
                    if ((i % 2 == 0 & j % 2 == 0) || (i % 2 != 0 & j % 2 != 0))
                    {
                        board[i, j] = 3;
                    }

                }
            }

            board[6, 1] = 2;
            board[3, 4] = 1;
            //board[5, 4] = 2;
            //board[4, 5] = 1;
            board[4, 3] = 2;

            return board;
            */
            //**THIS CODE IS FOR TESTING PUPROSES ONLY**//
        }
    }
}
