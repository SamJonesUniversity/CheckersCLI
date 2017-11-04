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
            winCondition winner = new winCondition();
            BoardArray nBoard = new BoardArray();
            BoardDraw draw = new BoardDraw();
            Movement move = new Movement();
            kingMe king = new kingMe();
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
                        king.kinged(board);

                        if (winner.wonYet(board) == 1)
                        {
                            for(int i = 0; i < 20; i++)
                            {
                                Console.WriteLine("PLAYER 1 WINS!");
                            }

                            Console.Read();
                            gameOver = true;
                        }

                        Console.Clear();
                        playerTurn = 2;
                }

                else
                {
                    draw.UpdateBoard(board);
                    Console.WriteLine("Player 2 turn");
                    move.firstPoint(board, playerTurn);
                    king.kinged(board);

                    if (winner.wonYet(board) == 2)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            Console.WriteLine("PLAYER 2 WINS!");
                        }

                        Console.Read();
                        gameOver = true;
                    }

                    Console.Clear();
                    playerTurn = 1;
                }
            }
        }
    }
}
