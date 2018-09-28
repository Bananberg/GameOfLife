using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {        
        private static bool[,] board;
        private static int size; 

        static void Main(string[] args)
        {
            size = 30;
            board = new bool[size, size];          

            SetUpLiveCells();

            PrintBoard();

            Console.ReadLine();

            while (Update());                     
        }

        public static bool Update()
        {
            CalculateBoard();
            Console.Clear();
            PrintBoard();

            String input = Console.ReadLine();           
            if(input == "0" || input == "exit")
            {
                return false;
            }

            return true; 
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
        
        public static void CalculateBoard()
        {
            bool[,] newboard = new bool[board.GetLength(0), board.GetLength(1)];
            
            for (int y = 0; y < board.GetLength(1); y++)
            {       
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    int liveNeighbours = 0;

                    CheckColumn(board, x, y, ref liveNeighbours, -1);
                    CheckColumn(board, x, y, ref liveNeighbours, 0);
                    CheckColumn(board, x, y, ref liveNeighbours, +1);

                    ParseNeighbours(board, x, y, liveNeighbours, newboard);
                  
                }       
            }

            board = (bool[,])newboard.Clone();

        }
        public static void CheckColumn(bool[,] board, int x, int y, ref int neighbours, int column)
        {
            
            if (IsNeighbourAlive(board, x, y, column, -1))
            {
                neighbours++;
            }
            if(column != 0)
            {
                if (IsNeighbourAlive(board, x, y, column, 0))
                {
                    neighbours++;
                }
            }            
            if (IsNeighbourAlive(board, x, y, column, +1))
            {
                neighbours++;
            }
        }
        public static void ParseNeighbours(bool[,] board, int x, int y, int neighbours, bool[,] newboard) {

            if (board[x, y] && neighbours < 2)
            {
                newboard[x, y] = false;
            }
            if (board[x, y] && (neighbours == 2 || neighbours == 3))
            {
                newboard[x, y] = board[x, y];
            }
            if (board[x, y] && neighbours > 3)
            {
                newboard[x, y] = false;
            }
            if (board[x, y] == false && neighbours == 3)
            {
                newboard[x, y] = true;
            }
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
