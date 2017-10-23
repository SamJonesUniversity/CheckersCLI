using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class BoardArray
    {
        public int[,] BoardCreate(int[,] board)
        {
            int c = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    c++;
                    if((i % 2 == 0 & j % 2 == 0) || (i % 2 != 0 & j % 2 != 0))
                    {
                        board[i, j] = 3;
                    }

                    else if (c >= 25 & c <= 40)
                    {
                        board[i, j] = 0;
                    }

                    else if (i <= 2)
                    {
                        board[i, j] = 1;
                    }

                    else
                    {
                        board[i, j] = 2;
                    }

                }
            }

            return board;
        }
    }
}
