using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class Movement
    {

        public int[,] firstPoint(int[,] coord, int player)
        {
            ProxyChecker proxy = new ProxyChecker();
            Exception e = new Exception();

            int enemy = 0;
            bool passed = false;
            bool needToJump = false;

            if (player == 1)
            {
                enemy = 2;
            }
            else
            {
                enemy = 1;
            }

            while (!passed) 
            {
                Console.WriteLine("Which piece would you like to move?");
                string[] line = Console.ReadLine().Split(',');

                try
                {
                    int[] startCoords = Array.ConvertAll(line, int.Parse);

                    if (proxy.EnemyChecker(coord, player, enemy, startCoords) == 2)
                    {
                        Console.WriteLine("You have a piece that can take an enemy piece, please use that piece.");
                        throw e;
                    }
                    else if(proxy.EnemyChecker(coord, player, enemy, startCoords) == 1)
                    {
                        needToJump = true;
                    }

                    int i = startCoords[1];
                    int j = startCoords[0];

                    if (startCoords.Length < 2 || (coord[i,j] != player & coord[i,j] != player + 7))
                    {
                        throw e;
                    }

                    secondPoint(coord, player, i, j, needToJump, enemy);
                    passed = true;
                }

                catch
                {
                    Console.WriteLine("That is an invalid co-ordinate.");               
                }

            }
            return (coord);
        }

        public int[,] secondPoint(int[,] coord, int player, int x, int y, bool needToJump, int enemy)
        {
            BoardArray uBoard = new BoardArray();
            ProxyChecker proxy = new ProxyChecker();
            BoardDraw draw = new BoardDraw();
            Exception e = new Exception();

            bool passed = false;

            while (!passed)
            {
                Console.WriteLine("Where will you move this piece to?");
                string[] line = Console.ReadLine().Split(',');

                bool tooFar = false;

                try
                {
                    int[] moveCoords = Array.ConvertAll(line, int.Parse);
                    int i = moveCoords[1];
                    int j = moveCoords[0];

                    if (Math.Abs(x - i) > 1 || Math.Abs(y - j) > 1)
                    {
                        tooFar = true;

                    }

                    if (needToJump == true & tooFar != true)
                    {
                        throw e;
                    }

                    if (player == 1 || coord[x,y] == 8 || coord[x,y] == 9)
                    {
                        if (i > 1 & j < 6)
                        {
                            if ((coord[i - 1, j + 1] == enemy || coord[i - 1, j + 1] == enemy + 7) & coord[i - 2, j + 2] == coord[x, y])
                            {
                                coord[i, j] = coord[x, y];
                                coord[x + 1, y - 1] = 0;
                                coord[x, y] = 0;
                                passed = true;

                                if (proxy.EnemyChecker(coord, player, enemy, moveCoords) == 1)
                                {
                                    Console.WriteLine("You can jump another piece this turn.");
                                    draw.UpdateBoard(coord);
                                    secondPoint(coord, player, i, j, needToJump, enemy);
                                }

                                return coord;
                            }

                        }

                        if (i > 1 & j > 1)
                        {
                            if ((coord[i - 1, j - 1] == enemy || coord[i - 1, j - 1] == enemy + 7) & coord[i - 2, j - 2] == coord[x, y])
                            {
                                coord[i, j] = coord[x, y];
                                coord[x + 1, y + 1] = 0;
                                coord[x, y] = 0;
                                passed = true;

                                if (proxy.EnemyChecker(coord, player, enemy, moveCoords) == 1)
                                {
                                    Console.WriteLine("You can jump another piece this turn.");
                                    firstPoint(coord, player);
                                    secondPoint(coord, player, i, j, needToJump, enemy);
                                }

                                return coord;
                            }

                        }

                    }

                    else if(player == 2 || coord[x, y] == 8 || coord[x, y] == 9)
                    {
                        if (i < 6 & j > 1)
                        {
                            if ((coord[i + 1, j - 1] == enemy || coord[i + 1, j - 1] == enemy + 7) & coord[i + 2, j - 2] == coord[x, y])
                            {
                                coord[i, j] = coord[x, y];
                                coord[x - 1, y + 1] = 0;
                                coord[x, y] = 0;
                                passed = true;

                                if (proxy.EnemyChecker(coord, player, enemy, moveCoords) == 1)
                                {
                                    Console.WriteLine("You can jump another piece this turn.");
                                    firstPoint(coord, player);
                                    secondPoint(coord, player, i, j, needToJump, enemy);
                                }

                                return coord;
                            }

                        }

                        if (i < 6 & j  < 6)
                        {
                            if ((coord[i + 1, j + 1] == enemy || coord[i + 1, j + 1] == enemy + 7) & coord[i + 2, j + 2] == coord[x, y])
                            {
                                coord[i, j] = coord[x, y];
                                coord[x - 1, y - 1] = 0;
                                coord[x, y] = 0;
                                passed = true;

                                if (proxy.EnemyChecker(coord, player, enemy, moveCoords) == 1)
                                {
                                    Console.WriteLine("You can jump another piece this turn.");
                                    firstPoint(coord, player);
                                    secondPoint(coord, player, i, j, needToJump, enemy);
                                }

                                return coord;
                            }

                        }

                    }

                    if (moveCoords.Length < 2 || coord[i, j] != 0 || tooFar)
                    {
                        throw e;
                    }

                    coord[i, j] = coord[x, y];
                    coord[x, y] = 0;
                    passed = true;
                }


                catch
                {
                    Console.WriteLine("That is an invalid co-ordinate");
                }

            }

            return coord;
        }
    }
}