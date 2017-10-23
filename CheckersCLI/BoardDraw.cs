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
                          "(0)| x | {0} | x | {1} | x | {2} | x | {3} |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(1)| {4} | x | {5} | x | {6} | x | {7} | x |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(2)| x | {8} | x | {9} | x | {10} | x | {11} |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(3)| {12} | x | {13} | x | {14} | x | {15} | x |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(4)| x | {16} | x | {17} | x | {18} | x | {19} |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(5)| {20} | x | {21} | x | {22} | x | {23} | x |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(6)| x | {24} | x | {25} | x | {26} | x | {27} |\n" +
                          "   +---+---+---+---+---+---+---+---+\n" +
                          "(7)| {28} | x | {29} | x | {30} | x | {31} | x |\n" +
                          "   +---+---+---+---+---+---+---+---+\n\n",
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
