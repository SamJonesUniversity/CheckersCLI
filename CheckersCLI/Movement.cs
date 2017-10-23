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
            while (!passed)
            {
                Console.WriteLine("Which piece would you like to move?");
                string[] line = Console.ReadLine().Split(',');

                int[] startCoords = Array.ConvertAll(line, int.Parse);

                int i = startCoords[0];
                int j = startCoords[1];

                try
                {
                    if (startCoords.Length < 2 || coord[i,j] != player)
                    {
                        Exception e = new Exception();
                        throw e;
                    }

                    coord[i, j] = 0;
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
            /*int enemy;

            if (player == 1)
            {
                enemy = 2;
            }

            else 
            {
                enemy = 1;
            }*/

            while (!passed)
            {
                Console.WriteLine("Where will you move this piece to?");
                string[] line = Console.ReadLine().Split(',');

                int[] moveCoords = Array.ConvertAll(line, int.Parse);
                bool tooFar = false;
                Exception e = new Exception();

                int i = moveCoords[0];
                int j = moveCoords[1];

                if(Math.Abs(x - i) > 1 || Math.Abs(y - j) > 1)
                {
                    tooFar = true;
                }

                try
                {
                    if (moveCoords.Length < 2 || coord[i, j] != 0 || tooFar)
                    {
                        throw e;
                    }
                    /*
                    else if (player == 1)
                    {
                        if(coord[i, j] == enemy & (coord[i + 1, j + 1] != 0 || coord[i + 1, j - 1] != 0))
                        {
                            throw e;
                        }
                    }

                    else if(player == 2)
                    {
                        if (coord[i, j] == enemy & (coord[i - 1, j - 1] != 0 || coord[i - 1, j + 1] != 0))
                        {
                            throw e;
                        }

                    }
                    */
                    coord[i, j] = player;
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