using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class Program
    {
        /// <summary>
        /// This is the main body of the program always running. It is the core for the game. The game will be played out until someone wins.
        /// The user will have the option to chose from playing vs AI or a friend. both the player and the enemy will be assigned player numbers.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Initiate Objects.
            Queue<int[,]> replay = new Queue<int[,]>();
            Stack<int[,]> undo = new Stack<int[,]>();
            Stack<int[,]> redo = new Stack<int[,]>();
            winCondition winner = new winCondition();
            BoardArray nBoard = new BoardArray();
            BoardDraw draw = new BoardDraw();
            Movement move = new Movement();
            kingMe king = new kingMe();
            Random RNG = new Random();
            AI ai = new AI();

            //Initiate Variables.
            int playerTurn = RNG.Next(1, 3); //Generates a number 1 or 2 randomly for which player starts the game. 
            int[,] board = new int[8, 8];
            bool gameOver = false;
            int humanPlayer = 0;
            int gameMode = 0;

            //Create a new board.
            nBoard.BoardCreate(board);

            Console.WriteLine("Hello welcome to CheckersCLI.\n\nIn this game you can either play against a friend localy, play against our AI\nor watch our AI battle it out!\n\n" +
            "To undo mistakes type 'Undo', this can only be done at the start of your turn.\nSimilarly you can also 'Redo' at the start of your turn.\n" +
            "\nIf you choose the wrong piece to move type 'Back' to change your selection.\n\nAt the of of every game the game will replay for you to watch.\n\nPress any button to continue...");
            Console.ReadKey();
            Console.Clear();

            //Ask the human to choose gamemode.
            while (gameMode < 1 || gameMode > 3)
            {
                Console.WriteLine("Will you play against a friend 1, AI 2 or will you watch two AI battle 3? Type 1, 2 or 3 below to answer.");

                int.TryParse(Console.ReadLine(), out gameMode);

                Console.Clear();
            }

            //If playing against AI ask the human which player they wish to be.
            if (gameMode == 2)
            {
                while (humanPlayer < 1 || humanPlayer > 2)
                {
                    Console.WriteLine("Will you be player 1 or player 2? Type 1 or 2 below to answer.");

                    int.TryParse(Console.ReadLine(), out humanPlayer);

                    Console.Clear();
                }
            }

            //Game loop, runs until the win condition is met.
            //Game switches between players at the end of of their turns.
            while (!gameOver)
            {
                if (playerTurn == 1)
                {
                    //Draws the board and adds the instance to the undo stack and replay queue.
                    draw.UpdateBoard(board);
                    replay.Enqueue(board.Clone() as int[,]);

                    if (undo.Count == 0)
                    {
                        undo.Push(board.Clone() as int[,]);
                    }

                    Console.WriteLine("Player 1 turn");

                    //If the human player chose vs AI gamemode and player 2 then the ai is player 1.
                    //Calls object to take the moves and update the board.
                    if (humanPlayer == 2 || gameMode == 3)
                    {
                        board = ai.takeMove(board, playerTurn, replay, undo, redo);
                    }
                    else
                    {
                        board = move.firstPoint(board, playerTurn, replay, undo, redo, humanPlayer);
                    }
                    
                    //Check for posible kings on the board.
                    king.kinged(board);
                    Console.Clear();

                    if (redo.Count > 0)
                    {
                        redo.Clear();
                    }

                    //Win condition.
                    if (winner.wonYet(board) == 1)
                    {

                        draw.UpdateBoard(board);
                        replay.Enqueue(board.Clone() as int[,]);

                        Console.WriteLine("PLAYER 1 WINS! This game took " + replay.Count + " moves!");

                        Console.Read();
                        Console.Clear();

                        Console.WriteLine("Now displaying replay.");

                        //Show replay of game.
                        foreach (int[,] q in replay)
                        {
                            draw.UpdateBoard(q);
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                        }

                        Console.ReadLine();

                        gameOver = true;
                    }

                    Console.Clear();
                    playerTurn = 2;
                }

                else
                {
                    //Draws the board and adds the instance to the undo stack and replay queue.
                    draw.UpdateBoard(board);
                    replay.Enqueue(board.Clone() as int[,]);

                    if (undo.Count == 0)
                    {
                        undo.Push(board.Clone() as int[,]);
                    }

                    Console.WriteLine("Player 2 turn");

                    //If the human player chose vs AI gamemode and player 1 then the ai is player 2.
                    //Calls object to take the moves and update the board.
                    if (humanPlayer == 1 || gameMode == 3)
                    {
                        board = ai.takeMove(board, playerTurn, replay, undo, redo);
                    }
                    else
                    {
                        board = move.firstPoint(board, playerTurn, replay, undo, redo, humanPlayer);
                    }

                    //Check for posible kings on the board.
                    king.kinged(board);
                    Console.Clear();

                    if (redo.Count > 0)
                    {
                        redo.Clear();
                    }

                    //Win condition.
                    if (winner.wonYet(board) == 2)
                    {
                        draw.UpdateBoard(board);
                        replay.Enqueue(board.Clone() as int[,]);

                        Console.WriteLine("PLAYER 2 WINS! This game took " + replay.Count + " moves!");

                        Console.Read();
                        Console.Clear();

                        Console.WriteLine("Now displaying replay.\n");

                        //Show replay of game.
                        foreach (int[,] q in replay)
                        {
                            draw.UpdateBoard(q);
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                        }

                        Console.ReadLine();

                        gameOver = true;
                    }

                    Console.Clear();
                    playerTurn = 1;
                }
            }   
        }
    }
}
