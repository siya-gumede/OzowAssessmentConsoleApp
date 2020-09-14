using System;
using ComputeLibrary;

namespace OzowConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //String assessment 
            string input = "Contrary to popular belief, the pink unicorn flies east.";
           
            Console.WriteLine(input.ToLower().LettersOnly().OrderLetters());

            //Inial board but can configure anyboard as 2D array 
            int[,] block = { { 0, 0, 0, 0,0 }, { 0, 0, 1, 0, 0}, { 0, 0, 1, 0, 0}, { 0, 0, 1, 0,0 } , { 0, 0, 0, 0, 0 } };
            GameOfLife gof = new GameOfLife(block);

            //Number of generations can be added as arguments or read from file. 

            int numberOfgen = 10;
            //number of generations
            for( int gen =1; gen < numberOfgen; gen++)
            {     
                   printGameOFLife(gof.getBoard());
                   gof.nextGen();
            }

        }
        public static void printGameOFLife(int [,] board)
        {
            for (int i = 0; i < board.Length/ board.GetLength(0); i++) { 
                for (int j = 0; j < board.GetLength(0); j++)
                   Console.Write(board[i,j]);
                   
                Console.WriteLine("");}
        }
    }
}
