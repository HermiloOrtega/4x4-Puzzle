using System;

namespace QuartzInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            // EXAMPLE 1
            int[,] example1 = new int[5, 5] {
                    {  5, -1,  8, -1, 23},
                    { -1, -1,  7,  0,  8},
                    {  4, -1,  7,  8, 23},
                    { -1, -1, -1,  7, 20},
                    { 16, 18, 22, 18, 19}
                };

            // EXAMPLE 2
            int[,] example2 = new int[5, 5] {
                    {  2, -1,  5, -1, 22},
                    {  6,  4, -1, -1, 16},
                    { -1, -1, -1, -1, 19},
                    { -1,  2, -1,  1,  7},
                    {  9, 23, 15, 17, 14}
                };

            // EXAMPLE WITH ERRORS
            int[,] exampleError = new int[5, 5] {
                    {  5, -1,  8, -1, 23},
                    { -1,  4,  7,  0,  8},
                    {  4, -1,  7,  8, 23},
                    { -1, -1, -1,  7, 20},
                    { 16, 18, 22, 18, 19}
            };

            Console.WriteLine();

            Console.WriteLine("Puzzle Example 1 ============================");
            Puzzle puzzle1 = new Puzzle(example1, 20);
            puzzle1.PrintPuzzle();
            Console.WriteLine();
            Console.WriteLine(puzzle1.Solve() ? "Puzzle SOLVED!" : "Puzzle -NOT- SOLVED!");
            puzzle1.PrintPuzzle();

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("Puzzle Example 2 ============================");
            //Puzzle puzzle2 = new Puzzle(example2, 17);
            //puzzle2.PrintPuzzle();
            //Console.WriteLine();
            //Console.WriteLine(puzzle2.Solve() ? "Puzzle SOLVED!" : "Puzzle -NOT- SOLVED!");
            //puzzle2.PrintPuzzle();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Puzzle Example 3 ============================");
            Puzzle puzzle3 = new Puzzle(exampleError, 20);
            puzzle3.PrintPuzzle();
            Console.WriteLine();
            Console.WriteLine(puzzle3.Solve() ? "Puzzle SOLVED!" : "Puzzle -NOT- SOLVED!");
            puzzle3.PrintPuzzle();
        }
    }
}
