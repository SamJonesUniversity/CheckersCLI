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
            bool passed = false;
            bool[,] near = new bool[8, 8];
            ProxyChecker proxy = new ProxyChecker();
            proxy.EnemyNear(coord, player);

            while (!passed)
            {
                Console.WriteLine("Which piece would you like to move?");
                string[] line = Console.ReadLine().Split(',');

                try
                {
                    int[] startCoords = Array.ConvertAll(line, int.Parse);
                    int i = startCoords[1];
                    int j = startCoords[0];

                    if (startCoords.Length < 2 || coord[i,j] != player)
                    {
                        Exception e = new Exception();
                        throw e;
                    }

                    secondPoint(coord, player, i, j);
                    passed = true;
                }

                catch
                {
                    Console.WriteLine("That is an invalid co-ordinate.");               
                }

            }
            return (coord);
        }

        public int[,] secondPoint(int[,] coord, int player, int x, int y)
        {
            BoardArray uBoard = new BoardArray();
            bool passed = false;

            while (!passed)
            {
                Console.WriteLine("Where will you move this piece to?");
                string[] line = Console.ReadLine().Split(',');

                bool tooFar = false;
                Exception e = new Exception();

                try
                {
                    int[] moveCoords = Array.ConvertAll(line, int.Parse);
                    int i = moveCoords[1];
                    int j = moveCoords[0];

                    if (Math.Abs(x - i) > 1 || Math.Abs(y - j) > 1)
                    {
                        tooFar = true;
                    }

                    if (moveCoords.Length < 2 || coord[i, j] != 0 || tooFar)
                    {
                        throw e;
                    }

                    coord[i, j] = player;
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