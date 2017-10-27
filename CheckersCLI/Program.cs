using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initiate Objects
            BoardArray nBoard = new BoardArray();
            BoardDraw draw = new BoardDraw();
            Movement move = new Movement();
            Random RNG = new Random();

            //Initiate Variables
            int playerTurn = RNG.Next(1, 2); //Change 2 to 3
            int[,] board = new int[8, 8];
            bool gameOver = false;
            int humanPlayer = 0;

            //Create a new board
            nBoard.BoardCreate(board);

            //
            while (humanPlayer < 1 || humanPlayer > 2)
            {
                Console.WriteLine("Will you be player 1 or player 2? Type 1 or 2 below to answer.");

                int.TryParse(Console.ReadLine(), out humanPlayer);

                Console.Clear();

            }

            while (!gameOver)
            {
                if (playerTurn == 1)
                {
                        draw.UpdateBoard(board);
                        Console.WriteLine("Player 1 turn");
                        move.firstPoint(board, playerTurn);

                        Console.Clear();
                        playerTurn = 2;
                }

                else
                {
                    draw.UpdateBoard(board);
                    Console.WriteLine("Player 2 turn");
                    move.firstPoint(board, playerTurn);

                    Console.Clear();
                    playerTurn = 1;
                }

                Console.ReadLine();
            }
        }
    }
}
