using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class AI
    {
        /// <summary>
        /// The AI used to play against the player. 
        /// This AI uses the most simple for of linear search, moving the first piece it can.
        /// </summary>
        /// <param name="coord"></param>
        /// <param name="player"></param>
        /// <param name="replay"></param>
        /// <param name="undo"></param>
        /// <param name="redo"></param>
        /// <returns> The updated instance of the board after moving. </returns>
        public int[,] takeMove(int[,] coord, int player, Queue<int[,]> replay, Stack<int[,]> undo, Stack<int[,]> redo)
        {
            //Initiate Objects.
            BoardArray uBoard = new BoardArray();
            ProxyChecker proxy = new ProxyChecker();
            BoardDraw draw = new BoardDraw();
            Exception e = new Exception();

            //Initiate Variables.
            int robot = player;
            int enemy;

            //Set enemy of the AI.
            if (player == 1)
            {
                enemy = 2;
            }
            else 
            {
                enemy = 1;
            }

            int[] startCoords = new int[2];

            //Checks to see if the AI can jump a piece. If not the enter if statement.
            if (proxy.EnemyChecker(coord, player, enemy, startCoords, robot) == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        //Validation for which direction the piece can move.
                        if(coord[i,j] == player || coord[i, j] == player + 7)
                        {
                            if (player == 1 || coord[i, j] == player + 7)
                            {
                                if (i < 7 & j > 0)
                                {
                                    if (coord[i + 1, j - 1] == 0)
                                    {
                                        coord[i + 1, j - 1] = coord[i, j];
                                        coord[i, j] = 0;

                                        undo.Push(coord.Clone() as int[,]);

                                        return coord;
                                    }

                                }

                                if (i < 7 & j < 7)
                                {
                                    if (coord[i + 1, j + 1] == 0)
                                    {
                                        coord[i + 1, j + 1] = coord[i, j];
                                        coord[i, j] = 0;

                                        undo.Push(coord.Clone() as int[,]);

                                        return coord;
                                    }

                                }

                            }

                            if (player == 2 || coord[i, j] == player + 7)
                            {
                                if (i > 0 & j < 7)
                                {
                                    if (coord[i - 1, j + 1] == 0)
                                    {
                                        coord[i - 1, j + 1] = coord[i, j];
                                        coord[i, j] = 0;

                                        undo.Push(coord.Clone() as int[,]);

                                        return coord;
                                    }

                                }

                                if (i > 0 & j > 0)
                                {
                                    if (coord[i - 1, j - 1] == 0)
                                    {
                                        coord[i - 1, j - 1] = coord[i, j];
                                        coord[i, j] = 0;

                                        undo.Push(coord.Clone() as int[,]);

                                        return coord;
                                    }

                                }

                            }
                        }
                    }
                }
            }

            //If the AI can jump an enemy piece.
            else
            {   
                //Validation for which piece can jump and in which direction.
                if (player == 1 || coord[startCoords[0], startCoords[1]] == 8 || coord[startCoords[0], startCoords[1]] == 9)
                {
                    if (startCoords[0] < 6 & startCoords[1] > 1)
                    {
                        if ((coord[startCoords[0] + 1,startCoords[1] - 1] == enemy || coord[startCoords[0] + 1,startCoords[1] - 1] == enemy + 7) & coord[startCoords[0] + 2, startCoords[1] - 2] == 0)
                        {
                            coord[startCoords[0] + 2, startCoords[1] - 2] = coord[startCoords[0], startCoords[1]];
                            coord[startCoords[0] + 1, startCoords[1] - 1] = 0;
                            coord[startCoords[0], startCoords[1]] = 0;

                            startCoords[0] += 2;
                            startCoords[1] -= 2;

                            //Checks to see if the same piece can jump again.
                            if (proxy.EnemyChecker(coord, player, enemy, startCoords, robot) == 1)
                            {
                                Console.Clear();

                                draw.UpdateBoard(coord);
                                replay.Enqueue(coord.Clone() as int[,]);
                                takeMove(coord, player, replay, undo, redo);
                            }

                            undo.Push(coord.Clone() as int[,]);
                            return coord;
                        }

                    }

                    if (startCoords[0] < 6 & startCoords[1] < 6)
                    {
                        if ((coord[startCoords[0] + 1, startCoords[1] + 1] == enemy || coord[startCoords[0] + 1, startCoords[1] + 1] == enemy + 7) & coord[startCoords[0] + 2, startCoords[1] + 2] == 0)
                        {
                            coord[startCoords[0] + 2, startCoords[1] + 2] = coord[startCoords[0], startCoords[1]];
                            coord[startCoords[0] + 1, startCoords[1] + 1] = 0;
                            coord[startCoords[0], startCoords[1]] = 0;

                            startCoords[0] += 2;
                            startCoords[1] += 2;

                            //Checks to see if the same piece can jump again.
                            if (proxy.EnemyChecker(coord, player, enemy, startCoords, robot) == 1)
                            {
                                Console.Clear();

                                draw.UpdateBoard(coord);
                                replay.Enqueue(coord.Clone() as int[,]);
                                takeMove(coord, player, replay, undo, redo);
                            }

                            undo.Push(coord.Clone() as int[,]);
                            return coord;
                        }

                    }

                }

                if (player == 2 || coord[startCoords[0], startCoords[1]] == 8 || coord[startCoords[0], startCoords[1]] == 9)
                {
                    if (startCoords[0] > 1 & startCoords[1] < 6)
                    {
                        if ((coord[startCoords[0] - 1, startCoords[1] + 1] == enemy || coord[startCoords[0] - 1, startCoords[1] + 1] == enemy + 7) & coord[startCoords[0] - 2, startCoords[1] + 2] == 0)
                        {
                            coord[startCoords[0] - 2, startCoords[1] + 2] = coord[startCoords[0], startCoords[1]];
                            coord[startCoords[0] - 1, startCoords[1] + 1] = 0;
                            coord[startCoords[0], startCoords[1]] = 0;

                            startCoords[0] -= 2;
                            startCoords[1] += 2;

                            //Checks to see if the same piece can jump again.
                            if (proxy.EnemyChecker(coord, player, enemy, startCoords, robot) == 1)
                            {
                                Console.Clear();

                                draw.UpdateBoard(coord);
                                replay.Enqueue(coord.Clone() as int[,]);
                                takeMove(coord, player, replay, undo, redo);
                            }

                            undo.Push(coord.Clone() as int[,]);
                            return coord;
                        }

                    }

                    if (startCoords[0] > 1 & startCoords[1] > 1)
                    {
                        if ((coord[startCoords[0] - 1, startCoords[1] - 1] == enemy || coord[startCoords[0] - 1, startCoords[1] - 1] == enemy + 7) & coord[startCoords[0] - 2, startCoords[1] - 2] == 0)
                        {
                            coord[startCoords[0] - 2, startCoords[1] - 2] = coord[startCoords[0], startCoords[1]];
                            coord[startCoords[0] - 1, startCoords[1] - 1] = 0;
                            coord[startCoords[0], startCoords[1]] = 0;
                            
                            startCoords[0] -= 2;
                            startCoords[1] -= 2;

                            //Checks to see if the same piece can jump again.
                            if (proxy.EnemyChecker(coord, player, enemy, startCoords, robot) == 1)
                            {
                                Console.Clear();

                                draw.UpdateBoard(coord);
                                replay.Enqueue(coord.Clone() as int[,]);
                                takeMove(coord, player, replay, undo, redo);
                            }

                            undo.Push(coord.Clone() as int[,]);
                            return coord;
                        }

                    }

                }
            }

            return coord;
        }
    }
}
