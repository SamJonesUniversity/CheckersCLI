using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class ProxyChecker
    {
        public int[,] EnemyNear(int[,] board, int player)
        {
            int[,] near = new int[8,8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == player & player == 1)
                    {
                        if (i < 6 & j < 6)
                        {
                            if (board[i + 1, j + 1] == 2 & board[i + 2, j + 2] == 0)
                            {
                                near[i, j] = 1;
                            }

                        }

                        if (i < 6 & j > 1)
                        {
                            if (board[i + 1, j - 1] == 2 & board[i + 2, j - 2] == 0)
                            {
                                near[i, j] = 2;
                            }

                        }

                    }

                }

            }

            return near;
        }

    }
}
