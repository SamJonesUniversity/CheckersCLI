using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class Movement
    {

        public void firstPoint()
        {
            bool passed = false;
            while (!passed)
            {
                Console.WriteLine("Which piece would you like to move?");
                string[] line = Console.ReadLine().Split(',');

                try
                {
                    int[] startCoords = Array.ConvertAll(line, int.Parse);
                    passed = true;
                }
                catch
                {
                    Console.WriteLine("That is an invalid co-ordinate");               
                }

            }

            secondPoint();
        }

        public void secondPoint()
        {
            bool passed = false;
            while (!passed)
            {
                Console.WriteLine("Where will you move this piece?");
                string[] line = Console.ReadLine().Split(',');

                try
                {
                    int[] startCoords = Array.ConvertAll(line, int.Parse);
                    passed = true;
                }
                catch
                {
                    Console.WriteLine("That is an invalid co-ordinate");
                }
            }
        }
    }
}
