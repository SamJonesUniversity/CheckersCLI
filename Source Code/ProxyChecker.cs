using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class ProxyChecker
    {
        /// <summary>
        /// Checks the squares around all pieces of the passed team for enemy pieces.
        /// Used to see if the current player is able to jump any enemy pieces.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <param name="startCoords"></param>
        /// <param name="ai"></param>
        /// <returns> 2 || 1 || 0 </returns>
        public int EnemyChecker(int[,] board, int player, int enemy, int[] startCoords, int ai)
        {
            //Initiate variables
            bool[,] enemyClose = new bool[8,8];
            bool containsTrue = false;
            int x;
            int y;

            //Run through all pieces on the board.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //Validation to ensure the correct piece is checked.
                    if (player == 1 || (player == 2 & board[i, j] == 9))
                    {
                        if (board[i, j] == player || board[i, j] == player + 7)
                        {
                            if (i < 6 & j < 6)
                            {
                                //Down to the right on the board.
                                if ((board[i + 1, j + 1] == enemy || board[i + 1, j + 1] == enemy + 7) & board[i + 2, j + 2] == 0)
                                {
                                    enemyClose[i, j] = true;
                                    containsTrue = true;

                                    if (ai == player)
                                    {
                                        startCoords[0] = i;
                                        startCoords[1] = j;
                                    }
                                }

                            }

                            if (i < 6 & j > 1)
                            {
                                //Down to the left on the board.
                                if ((board[i + 1, j - 1] == enemy || board[i + 1, j - 1] == enemy + 7) & board[i + 2, j - 2] == 0)
                                {
                                    enemyClose[i, j] = true;
                                    containsTrue = true;

                                    if (ai == player)
                                    {
                                        startCoords[0] = i;
                                        startCoords[1] = j;
                                    }
                                }

                            }

                        }

                    }

                    if (player == 2 || (player == 1 & board[i, j] == 8)) 
                    {
                        if (board[i, j] == player || board[i, j] == player + 7)
                        {
                            if (i > 1 & j > 1)
                            {
                                //Up to the left on the board.
                                if ((board[i - 1, j - 1] == enemy || board[i - 1, j - 1] == enemy + 7) & board[i - 2, j - 2] == 0)
                                {
                                    enemyClose[i, j] = true;
                                    containsTrue = true;

                                    if (ai == player)
                                    {
                                        startCoords[0] = i;
                                        startCoords[1] = j;
                                    }
                                }

                            }

                            if (i > 1 & j < 6)
                            {
                                //Up to the right on the board.
                                if ((board[i - 1, j + 1] == enemy || board[i - 1, j + 1] == enemy + 7) & board[i - 2, j + 2] == 0)
                                {
                                    enemyClose[i, j] = true;
                                    containsTrue = true;

                                    if (ai == player)
                                    {
                                        startCoords[0] = i;
                                        startCoords[1] = j;
                                    }
                                }

                            }

                        }

                    }

                }

            }

            //Get coordinates of piece to be moved.
            if (ai == player)
            {
                x = startCoords[0];
                y = startCoords[1];
            }
            else
            {
                x = startCoords[1];
                y = startCoords[0];
            }

            //Return 2 if the player has input coordinates that are unable to to take a piece when there is an available take.
            //Return 1 if the player has input coordinates that match a piece that can take.
            //Return 0 if there are no pieces to take.
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
