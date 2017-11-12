using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class winCondition
    {
        /// <summary>
        /// Checks the board to see if only one sides pieces remain on the board.
        /// If so then return the winners player number.
        /// </summary>
        /// <param name="board"></param>
        /// <returns> 2 || 1 || 0 </returns>
        public int wonYet(int[,] board)
        {
            int counterP1 = 0;
            int counterP2 = 0;

            //Looks for kings
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(board[i,j] == 1 || board[i,j] == 8)
                    {
                        counterP1++;
                    }

                    if (board[i,j] == 2 || board[i,j] == 9)
                    {
                        counterP2++;
                    }
                }
            }

            //Return the winner if someone won, else return 0.
            if (counterP1 == 0)
            {
                return 2;
            }
            else if ( counterP2 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}
