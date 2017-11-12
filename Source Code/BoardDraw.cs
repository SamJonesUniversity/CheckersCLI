using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class BoardDraw
    {
        /// <summary>
        /// Draws the board on screen.
        /// </summary>
        /// <param name="board"></param>
        public void UpdateBoard(int[,] board)
        {
            //Recieves the instance of the board and drawns it on screen.
            Console.Write("    (0) (1) (2) (3) (4) (5) (6) (7)  \n" +
                          "   ┌───┬───┬───┬───┬───┬───┬───┬───┐\n" +
                          "(0)│ █ │ {0} │ █ │ {1} │ █ │ {2} │ █ │ {3} │\n" +
                          "   ├───┼───┼───┼───┼───┼───┼───┼───┤\n" +
                          "(1)│ {4} │ █ │ {5} │ █ │ {6} │ █ │ {7} │ █ │\n" +
                          "   ├───┼───┼───┼───┼───┼───┼───┼───┤\n" +
                          "(2)│ █ │ {8} │ █ │ {9} │ █ │ {10} │ █ │ {11} │\n" +
                          "   ├───┼───┼───┼───┼───┼───┼───┼───┤\n" +
                          "(3)│ {12} │ █ │ {13} │ █ │ {14} │ █ │ {15} │ █ │\n" +
                          "   ├───┼───┼───┼───┼───┼───┼───┼───┤\n" +
                          "(4)│ █ │ {16} │ █ │ {17} │ █ │ {18} │ █ │ {19} │\n" +
                          "   ├───┼───┼───┼───┼───┼───┼───┼───┤\n" +
                          "(5)│ {20} │ █ │ {21} │ █ │ {22} │ █ │ {23} │ █ │\n" +
                          "   ├───┼───┼───┼───┼───┼───┼───┼───┤\n" +
                          "(6)│ █ │ {24} │ █ │ {25} │ █ │ {26} │ █ │ {27} │\n" +
                          "   ├───┼───┼───┼───┼───┼───┼───┼───┤\n" +
                          "(7)│ {28} │ █ │ {29} │ █ │ {30} │ █ │ {31} │ █ │\n" +
                          "   └───┴───┴───┴───┴───┴───┴───┴───┘\n\n",
                          board[0, 1], board[0, 3], board[0, 5], board[0, 7],
                          board[1, 0], board[1, 2], board[1, 4], board[1, 6],
                          board[2, 1], board[2, 3], board[2, 5], board[2, 7],
                          board[3, 0], board[3, 2], board[3, 4], board[3, 6],
                          board[4, 1], board[4, 3], board[4, 5], board[4, 7],
                          board[5, 0], board[5, 2], board[5, 4], board[5, 6],
                          board[6, 1], board[6, 3], board[6, 5], board[6, 7],
                          board[7, 0], board[7, 2], board[7, 4], board[7, 6]);
        }
    }
}
