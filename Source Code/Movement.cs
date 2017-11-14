using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersCLI
{
    class Movement
    {
        /// <summary>
        /// Recieves the users coordinates on which piece they would like to move.
        /// </summary>
        /// <param name="coord"></param>
        /// <param name="player"></param>
        /// <param name="replay"></param>
        /// <param name="undo"></param>
        /// <param name="redo"></param>
        /// <returns> The updated instance of the board after moving. </returns>
        public int[,] firstPoint(int[,] coord, int player, Queue<int[,]> replay, Stack<int[,]> undo, Stack<int[,]> redo, int ai)
        {   
            //Initiate objects.
            ProxyChecker proxy = new ProxyChecker();
            BoardDraw draw = new BoardDraw();
            Exception e = new Exception();

            //Initiate variables
            int enemy = 0;
            bool passed = false;
            bool needToJump = false;
            int robot = 0;

            //Set enemy of player
            if (player == 1)
            {
                enemy = 2;
            }
            else
            {
                enemy = 1;
            }

            //Runs until the user has input a valid set of coordinates.
            while (!passed) 
            {
                //Get users input of two numbers split by ','.
                Console.WriteLine("Which piece would you like to move?");
                string[] line = Console.ReadLine().Split(',');

                try
                {
                    //Allows the user to undo.
                    if(line[0] == "undo" || line[0] == "Undo")
                    {
                        if (undo.Count < 2)
                        {
                            Console.WriteLine("You cannot undo any further.");
                            throw e;
                        }
                        else if ( undo.Count < 3 & ai != 0)
                        {
                            Console.WriteLine("You cannot undo any further.");
                            throw e;
                        }

                        redo.Push(undo.Pop());

                        //Undoes twice in order to undo the AI's turn as well. 
                        if (ai != 0)
                        {
                            redo.Push(undo.Pop());
                            Console.Clear();
                            coord = undo.Peek().Clone() as int[,];
                            draw.UpdateBoard(coord);
                            Console.WriteLine("Player "+ player +" turn");
                            firstPoint(coord, player, replay, undo, redo, ai);
                        }

                        coord = undo.Peek().Clone() as int[,];
                        return coord;
                    }

                    //Allows the user to redo.
                    else if(line[0] == "redo" || line[0] == "Redo")
                    {
                        if (redo.Count < 1)
                        {
                            Console.WriteLine("You cannot redo any further.");
                            throw e;
                        }
                        else if (redo.Count < 2 & ai != 0)
                        {
                            Console.WriteLine("You cannot redo any further.");
                            throw e;
                        }

                        undo.Push(redo.Pop());

                        //Redo redoes twice in order to redo the AI's turn as well.
                        if(ai != 0)
                        {
                            undo.Push(redo.Pop());
                            Console.Clear();
                            coord = undo.Peek().Clone() as int[,];
                            draw.UpdateBoard(coord);
                            firstPoint(coord, player, replay, undo, redo, ai);
                        }

                        coord = undo.Peek().Clone() as int[,];
                        return coord;
                    }

                    int[] startCoords = Array.ConvertAll(line, int.Parse);

                    //Checks to see if the user can take a piece and if they have selected that piece.
                    if (proxy.EnemyChecker(coord, player, enemy, startCoords, robot) == 2)
                    {
                        Console.WriteLine("You have a piece that can take an enemy piece, please use that piece.");
                        throw e;
                    }
                    else if (proxy.EnemyChecker(coord, player, enemy, startCoords, robot) == 1)
                    {
                        needToJump = true;
                    }

                    int i = startCoords[1];
                    int j = startCoords[0];

                    //If the user puts more than 2 numbers in or selects a piece that isn't theirs.
                    if (startCoords.Length < 2 || (coord[i,j] != player & coord[i,j] != player + 7))
                    {
                        throw e;
                    }
                    
                    //Call method to move the piece.
                    secondPoint(coord, player, i, j, needToJump, enemy, replay, undo, redo, ai);
                    passed = true;
                }

                catch
                {
                    Console.WriteLine("That is an invalid co-ordinate.");
                }

            }

            undo.Push(coord.Clone() as int[,]);
            return coord;
        }

        public int[,] secondPoint(int[,] coord, int player, int x, int y, bool needToJump, int enemy, Queue<int[,]> replay, Stack<int[,]> undo, Stack<int[,]> redo, int ai)
        {
            //Initiate objects.
            BoardArray uBoard = new BoardArray();
            ProxyChecker proxy = new ProxyChecker();
            BoardDraw draw = new BoardDraw();
            Exception e = new Exception();

            //Initiate variables.
            bool tooFar = false;
            bool passed = false;
            int robot = 0;

            //Runs until the user has input a valid set of coordinates.
            while (!passed)
            {
                //Get users input of two numbers split by ','.
                Console.WriteLine("Where will you move this piece to?");
                string[] line = Console.ReadLine().Split(',');

                //Lets the user go back and change their first coordinate.
                if (line[0] == "back" || line[0] == "Back")
                {
                    firstPoint(coord, player, replay, undo, redo, ai);

                    if(undo.Count > 0)
                    {
                        undo.Pop();
                    }

                    return coord;
                }

                try
                {
                    int[] moveCoords = Array.ConvertAll(line, int.Parse);
                    int i = moveCoords[1];
                    int j = moveCoords[0];

                    //Checks to see if the distance of the move is more than one tile.
                    if (Math.Abs(x - i) > 1 || Math.Abs(y - j) > 1)
                    {
                        tooFar = true;

                    }

                    //If the user has to take a piece and they have not selected a distance greater than one tile.
                    if (needToJump == true & tooFar != true)
                    {
                        throw e;
                    }

                    //If user must take a piece.
                    if (needToJump)
                    {
                        //Validation for direction of jump and piece to take.
                        if (player == 1 || coord[x, y] == 8 || coord[x, y] == 9)
                        {
                            if (i > 1 & j < 6)
                            {
                                //Up to the right on the board.
                                if ((coord[i - 1, j + 1] == enemy || coord[i - 1, j + 1] == enemy + 7) & coord[i - 2, j + 2] == coord[x, y])
                                {
                                    coord[i, j] = coord[x, y];
                                    coord[x + 1, y - 1] = 0;
                                    coord[x, y] = 0;
                                    passed = true;

                                    //If the user can take another piece this turn.
                                    if (proxy.EnemyChecker(coord, player, enemy, moveCoords, robot) == 1)
                                    {
                                        Console.Clear();

                                        draw.UpdateBoard(coord);
                                        replay.Enqueue(coord.Clone() as int[,]);

                                        Console.WriteLine("You can jump another piece this turn.");

                                        secondPoint(coord, player, i, j, needToJump, enemy, replay, undo, redo, ai);
                                    }

                                    return coord;
                                }

                            }

                            if (i > 1 & j > 1)
                            {
                                //Up to the left on the board.
                                if ((coord[i - 1, j - 1] == enemy || coord[i - 1, j - 1] == enemy + 7) & coord[i - 2, j - 2] == coord[x, y])
                                {
                                    coord[i, j] = coord[x, y];
                                    coord[x + 1, y + 1] = 0;
                                    coord[x, y] = 0;
                                    passed = true;

                                    //If the user can take another piece this turn.
                                    if (proxy.EnemyChecker(coord, player, enemy, moveCoords, robot) == 1)
                                    {
                                        Console.Clear();

                                        draw.UpdateBoard(coord);
                                        replay.Enqueue(coord.Clone() as int[,]);

                                        Console.WriteLine("You can jump another piece this turn.");

                                        secondPoint(coord, player, i, j, needToJump, enemy, replay, undo, redo, ai);
                                    }

                                    return coord;
                                }

                            }

                        }

                        if (player == 2 || coord[x, y] == 8 || coord[x, y] == 9)
                        {
                            if (i < 6 & j > 1)
                            {
                                //Down to the left on the board.
                                if ((coord[i + 1, j - 1] == enemy || coord[i + 1, j - 1] == enemy + 7) & coord[i + 2, j - 2] == coord[x, y])
                                {
                                    coord[i, j] = coord[x, y];
                                    coord[x - 1, y + 1] = 0;
                                    coord[x, y] = 0;
                                    passed = true;

                                    //If the user can take another piece this turn.
                                    if (proxy.EnemyChecker(coord, player, enemy, moveCoords, robot) == 1)
                                    {
                                        Console.Clear();

                                        draw.UpdateBoard(coord);
                                        replay.Enqueue(coord.Clone() as int[,]);

                                        Console.WriteLine("You can jump another piece this turn.");

                                        secondPoint(coord, player, i, j, needToJump, enemy, replay, undo, redo, ai);
                                    }

                                    return coord;
                                }

                            }

                            if (i < 6 & j < 6)
                            {
                                //Down to the right on the board.
                                if ((coord[i + 1, j + 1] == enemy || coord[i + 1, j + 1] == enemy + 7) & coord[i + 2, j + 2] == coord[x, y])
                                {
                                    coord[i, j] = coord[x, y];
                                    coord[x - 1, y - 1] = 0;
                                    coord[x, y] = 0;
                                    passed = true;

                                    //If the user can take another piece this turn.
                                    if (proxy.EnemyChecker(coord, player, enemy, moveCoords, robot) == 1)
                                    {
                                        Console.Clear();

                                        draw.UpdateBoard(coord);
                                        replay.Enqueue(coord.Clone() as int[,]);

                                        Console.WriteLine("You can jump another piece this turn.");

                                        secondPoint(coord, player, i, j, needToJump, enemy, replay, undo, redo, ai);
                                    }

                                    return coord;
                                }

                            }

                        }
                    }
                    //If the user is not jumping a piece and only moving one tile.
                    else
                    {
                        //Makes sure the jump is no longer than one tile, the tile is equal to zero and the user input only two values in.
                        if (moveCoords.Length < 2 || coord[i, j] != 0 || tooFar)
                        {
                            throw e;
                        }

                        //Validation for which direction to move.
                        if (player == 1 || coord[x, y] == player + 7)
                        {
                            if (x < 7 & y > 0)
                            {
                                //Down to the left on the board.
                                if (i == x + 1 & j == y - 1)
                                {
                                    coord[i, j] = coord[x, y];
                                    coord[x, y] = 0;

                                    return coord;
                                }
                            }

                            if (x < 7 & y < 7)
                            {
                                //Down to the right on the board.
                                if (i == x + 1 & j == y + 1)
                                {
                                    coord[i, j] = coord[x, y];
                                    coord[x, y] = 0;

                                    return coord;
                                }
                            }

                        }

                        if (player == 2 || coord[i, j] == player + 7)
                        {
                            if (x > 0 & y < 7)
                            {
                                //Up to the right on the board.
                                if (i == x - 1 & j == y + 1)
                                {
                                    coord[i, j] = coord[x, y];
                                    coord[x, y] = 0;

                                    return coord;
                                }
                            }

                            if (x > 0 & y > 0)
                            {
                                //Up to the left on the board.
                                if (i == x - 1 & j == y - 1)
                                {
                                    coord[i, j] = coord[x, y];
                                    coord[x, y] = 0;

                                    return coord;
                                }
                            }
                        }
                    }
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