using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class BoardDraw
    {

        public void UpdateBoard(int[,] board)
        {

            Console.Write("    (0) (1) (2) (3) (4) (5) (6) (7)  \n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(0)| x | {1} | x | {3} | x | {5} | x | {7} |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(1)| {0} | x | {2} | x | {4} | x | {6} | x |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(2)| x | {9} | x | {11} | x | {13} | x | {15} |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(3)| {8} | x | {10} | x | {12} | x | {14} | x |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(4)| x | {17} | x | {19} | x | {21} | x | {23} |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(5)| {16} | x | {18} | x | {20} | x | {22} | x |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(6)| x | {25} | x | {27} | x | {29} | x | {31} |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(7)| {24} | x | {26} | x | {28} | x | {30} | x |\n" +
                          "   +---+---+---+---+---+---+---+---+\n\n",
                          board[0, 0], board[0, 1], board[0, 2], board[0, 3], board[0, 4], board[0, 5], board[0, 6], board[0, 7],
                          board[1, 0], board[1, 1], board[1, 2], board[1, 3], board[1, 4], board[1, 5], board[1, 6], board[1, 7],
                          board[2, 0], board[2, 1], board[2, 2], board[2, 3], board[2, 4], board[2, 5], board[2, 6], board[2, 7],
                          board[3, 0], board[3, 1], board[3, 2], board[3, 3], board[3, 4], board[3, 5], board[3, 6], board[3, 7]);
        }
    }
}
