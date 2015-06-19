using Board;
using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Sudoku board = new Sudoku();
            board[0, 3] = 7;
            board[0, 4] = 9;
            board[0, 8] = 8;

            board[1, 0] = 7;
            board[1, 5] = 4;
            board[1, 7] = 3;

            board[2, 0] = 6;
            board[2, 8] = 7;

            board[3, 4] = 3;
            board[3, 6] = 9;

            board[4, 2] = 5;
            board[4, 7] = 4;

            board[5, 0] = 2;
            board[5, 5] = 6;
            board[5, 8] = 1;

            board[6, 2] = 8;
            board[6, 3] = 1;
            board[6, 4] = 5;
            board[6, 7] = 2;

            board[7, 1] = 1;
            board[7, 3] = 2;
            board[7, 5] = 9;
            board[7, 7] = 8;

            board[8, 1] = 7;
            board[8, 4] = 4;
            board[8, 6] = 5;

            //board[0, 0] = 6;
            //board[0, 2] = 3;
            //board[0, 3] = 2;
            //board[0, 6] = 9;
            //board[1, 1] = 4;
            //board[1, 2] = 9;
            //board[1, 3] = 3;
            //board[1, 5] = 6;
            //board[2, 2] = 2;
            //board[2, 5] = 4;
            //board[2, 6] = 3;
            //board[2, 7] = 6;
            //board[2, 8] = 1;
            //board[3, 0] = 2;
            //board[3, 1] = 7;
            //board[3, 3] = 9;
            //board[3, 4] = 4;
            //board[4, 0] = 4;
            //board[4, 1] = 9;
            //board[4, 6] = 2;
            //board[4, 8] = 8;
            //board[5, 1] = 6;
            //board[5, 4] = 7;
            //board[5, 5] = 2;
            //board[5, 7] = 9;
            //board[6, 0] = 8;
            //board[6, 1] = 2;
            //board[6, 4] = 5;
            //board[6, 8] = 3;
            //board[7, 2] = 4;
            //board[7, 3] = 1;
            //board[7, 5] = 3;
            //board[7, 6] = 7;
            //board[7, 7] = 8;
            //board[8, 0] = 1;
            //board[8, 4] = 2;
            //board[8, 7] = 4;
            //board[8, 8] = 9;

            Console.Write(board);

            board.Resolve();
            Console.Write(board);

            Console.ReadKey();
        }
    }
}