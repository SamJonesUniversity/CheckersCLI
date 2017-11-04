using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class ProxyChecker
    {
        public int EnemyChecker(int[,] board, int player, int enemy,int[] startCoords)
        {
            bool[,] enemyClose = new bool[8,8];
            bool containsTrue = false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (player == 1)
                    {
                        if (board[i, j] == player || board[i, j] == 8 || board[i, j] == 9)
                        {
                            if (i < 6 & j < 6)
                            {
                                if (board[i + 1, j + 1] == 2 & board[i + 2, j + 2] == 0)
                                {
                                    enemyClose[i, j] = true;
                                    containsTrue = true;
                                }

                            }

                            if (i < 6 & j > 1)
                            {
                                if (board[i + 1, j - 1] == 2 & board[i + 2, j - 2] == 0)
                                {
                                    enemyClose[i, j] = true;
                                    containsTrue = true;
                                }

                            }

                        }

                    }
                    else 
                    {
                        if (board[i, j] == player || board[i, j] == 8 || board[i, j] == 9)
                        {
                            if (i > 1 & j > 1)
                            {
                                if (board[i - 1, j - 1] == 1 & board[i - 2, j - 2] == 0)
                                {
                                    enemyClose[i, j] = true;
                                    containsTrue = true;
                                }

                            }

                            if (i > 1 & j < 6)
                            {
                                if (board[i - 1, j + 1] == 1 & board[i - 2, j + 2] == 0)
                                {
                                    enemyClose[i, j] = true;
                                    containsTrue = true;
                                }

                            }

                        }

                    }

                }

            }

            int x = startCoords[1];
            int y = startCoords[0];

            if (containsTrue == true & enemyClose[x,y] == false)
            {
                return 2;
            }
            else if(containsTrue == true)
            {
                return 1;
            }

            return 0;
        }

    }
}
