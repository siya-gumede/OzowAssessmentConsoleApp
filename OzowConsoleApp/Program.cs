using System;
using ComputeLibrary;

namespace OzowConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input;

            Console.WriteLine("Enter text to sort: ");
 
            input = Console.ReadLine();
            //String assessment 
            Console.WriteLine(input.ToLower().LettersOnly().OrderLetters());


            //Number of generations of the given initial life 
            //I wont have time to implement a grid so that a user can select initial life 
             
            Console.WriteLine("Enter number of generations: ");
            int numberOfgen;
            // Converted string to int 
            numberOfgen = Convert.ToInt32(Console.ReadLine());

            //Initial board but can configure anyboard as 2D array 
            int[,] block = { { 0, 0, 0, 0,0 }, { 0, 0, 1, 0, 0}, { 0, 0, 1, 0, 0}, { 0, 0, 1, 0,0 } , { 0, 0, 0, 0, 0 } };
            GameOfLife gof = new GameOfLife(block);

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
