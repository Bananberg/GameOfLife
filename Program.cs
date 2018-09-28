using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        /**
         * A program running Conway's Game of Life.
         * a board of booleans to represent alive or dead. 
         * räkna ut hela brädet innan det ritas ut så att säga. 
         * 
         * */

        private static bool[,] board;
        private static int size; 

        static void Main(string[] args)
        {

            //String input = Console.ReadLine();

            //size = int.Parse(input);
            size = 20;

            CreateBoard(size);
            SetUpLiveCells();
            PrintBoard();
            Console.ReadLine();

            int counter = 0; 
            while (counter < 100)
            {
                Update();
                    counter++;
            }
            Console.ReadLine();
            
        }

        public static void Update()
        {
            CalculateBoard();
            Console.Clear();

            PrintBoard();
            String input = Console.ReadLine();           
            
        }

        public static void CreateBoard(int size)
        {
            board = new bool[size, size];
        }
        public static void SetUpLiveCells()
        {
            //Glider 
            board[1, 3] = true;
            board[2, 3] = true;
            board[3, 3] = true;
            board[3, 2] = true;
            board[2, 1] = true;


           

        }

        // Any live cell with fewer than two live neighbors dies, as if by under population.
        // Any live cell with two or three live neighbors lives on to the next generation.
        // Any live cell with more than three live neighbors dies, as if by overpopulation.
        // Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

        /**
                 * XXX
                 * XOX
                 * XXX 
                 */

        public static void CalculateBoard()
        {
            bool[,] newboard = new bool[board.GetLength(0), board.GetLength(1)];
            
            for (int y = 0; y < board.GetLength(1); y++)
            {                
                
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    int liveNeighbours = 0;

                    if (IsNeighbourAlive(board, x, y, -1, -1))
                    {
                       // Console.WriteLine("My Pos: " + x + "," + y + " N Pos: " + (x-1) + "," + (y - 1));
                        liveNeighbours++;
                    }
                    if (IsNeighbourAlive(board, x, y, -1, 0))
                    {
                        //Console.WriteLine("My Pos: " + x + "," + y + " N Pos: " + (x - 1) + "," + (y));
                        liveNeighbours++;
                    }
                    if (IsNeighbourAlive(board, x, y, -1, +1))
                    {
                        //Console.WriteLine("My Pos: " + x + "," + y + " N Pos: " + (x - 1) + "," + (y + 1));
                        liveNeighbours++;
                    }

                    if (IsNeighbourAlive(board, x, y, 0, -1))
                    {
                        //Console.WriteLine("My Pos: " + x + "," + y + " N Pos: " + (x) + "," + (y - 1));
                        liveNeighbours++;
                    }
                    if (IsNeighbourAlive(board, x, y, 0, 1))
                    {
                        //Console.WriteLine("My Pos: " + x + "," + y + " N Pos: " + (x) + "," + (y + 1));
                        liveNeighbours++;
                    }

                    if (IsNeighbourAlive(board, x, y, +1, -1))
                    {
                        //Console.WriteLine("My Pos: " + x + "," + y + " N Pos: " + (x + 1) + "," + (y - 1));
                        liveNeighbours++;
                    }
                    if (IsNeighbourAlive(board, x, y, +1, 0))
                    {
                       // Console.WriteLine("My Pos: " + x + "," + y + " N Pos: " + (x + 1) + "," + (y));
                        liveNeighbours++;
                    }
                    if (IsNeighbourAlive(board, x, y, +1, +1))
                    {
                        //Console.WriteLine("My Pos: " + x + "," + y + " N Pos: " + (x + 1) + "," + (y + 1));
                        liveNeighbours++;
                    }

                    // Any live cell with fewer than two live neighbors dies, as if by under population.
                    // Any live cell with two or three live neighbors lives on to the next generation.
                    // Any live cell with more than three live neighbors dies, as if by overpopulation.
                    // Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
                    if(board[x,y] && liveNeighbours < 2)
                    {
                        newboard[x, y] = false;
                    }
                    if(board[x,y] && (liveNeighbours == 2 || liveNeighbours == 3))
                    {
                        newboard[x, y] = board[x, y];
                    }
                    if(board[x,y] && liveNeighbours > 3)
                    {
                        newboard[x, y] = false;
                    }
                    if (board[x,y] == false &&  liveNeighbours == 3)
                    {
                        newboard[x, y] = true;
                    }
                }       
            }

            board = (bool[,])newboard.Clone();

        }
        public static bool IsNeighbourAlive(bool[,] board, int x, int y, int offsetX, int offsetY)
        {
            bool alive = false;
            if(x + offsetX < 0 || x + offsetX >= board.GetLength(0) ||
                y + offsetY < 0 || y + offsetY >= board.GetLength(1))
            {
                return false;
            }
            else
            {
                alive = board[x + offsetX, y + offsetY];
            }

            return alive;
        }
        

        public static void PrintBoard()
        {
            for(int y = 0; y < board.GetLength(1); y++)
            {
                for(int x = 0; x < board.GetLength(0); x++)
                {
                    if (board[x, y])
                    {
                        Console.Write("[#]");
                    }
                    else
                    {
                        Console.Write("[ ]");
                    }
                    if (x == size-1)
                    {
                        Console.Write("\n");
                    }
                }
                
            }
        }


    }
    
}
