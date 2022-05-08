using System;

namespace QuartzInterview
{
    class Program
    {
        // Create WITH OUT issues
        private static int[,] puzzle = new int[5, 5] {
                {  5, -1,  8, -1, 23},
                { -1, -1,  7,  0,  8},
                {  4, -1,  7,  8, 23},
                { -1, -1, -1,  7, 20},
                { 16, 18, 22, 18, 19}
            };

        // Create WITH issues
        //private static int[,] puzzle = new int[5, 5] {
        //        {  5, -1,  8, -1, 23},
        //        { -1,  4,  7,  0,  8},
        //        {  4, -1,  7,  8, 23},
        //        { -1, -1, -1,  7, 20},
        //        { 16, 18, 22, 18, 19}
        //    };

        // Save the Value from the Top Right Value
        private static int topValue = 20;
        private static int lineSum = 0;
        private static int sumLinesSolved = 0;
        private static int lineEmptySpaces = 0;
        private static int emptySpace = -1;

        static void Main(string[] args)
        {
            Console.WriteLine("Puzzle ============================");
            printPuzzle(puzzle);
            bool puzzleSolved = false;
            while (!puzzleSolved)
            {
                sumLinesSolved = 0;
                lineSum = 0;
                lineEmptySpaces = 0;
                emptySpace = -1;

                // Horizontal Loop
                for (int i = 0; i < 4; i++) {
                    lineSum = lineEmptySpaces = emptySpace = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (puzzle[i,j]==-1)
                        {
                            lineEmptySpaces++;
                            emptySpace = j;
                        }
                        else lineSum = lineSum + puzzle[i, j];
                    }
                    if (lineEmptySpaces == 1)
                    {
                        puzzle[i, emptySpace] = puzzle[i, 4] - lineSum;
                        sumLinesSolved++;
                    }
                    else if(lineEmptySpaces == 0) sumLinesSolved++;
                }
                if (sumLinesSolved == 4) break;

                sumLinesSolved = 0;
                // VERTICAL Loop
                for (int i = 0; i < 4; i++)
                {
                    lineSum = lineEmptySpaces = emptySpace = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        int value = puzzle[j, i];
                        if (value == -1)
                        {
                            lineEmptySpaces++;
                            emptySpace = j;
                        }
                        else lineSum = lineSum + puzzle[j, i];
                    }
                    if (lineEmptySpaces == 1)
                    {
                        puzzle[emptySpace, i] = puzzle[4, i] - lineSum;
                        sumLinesSolved++;
                    }
                    else if (lineEmptySpaces == 0)
                    {
                        sumLinesSolved++;
                    }
                }
                if (sumLinesSolved == 4) break;

                sumLinesSolved = 0;
                lineSum = lineEmptySpaces = emptySpace = 0;
                // DIAGONAL TOP-LEFT->RIGHT-BOTTOM VALIDATION
                for (int i = 0; i < 4; i++)
                {
                    if (puzzle[i, i] == -1)
                    {
                        lineEmptySpaces++;
                        emptySpace = i;
                    }
                    else lineSum = lineSum + puzzle[i, i];
                }
                if (lineEmptySpaces == 1) puzzle[emptySpace, emptySpace] = puzzle[4, 4] - lineSum; 

                lineSum = lineEmptySpaces = emptySpace = 0;
                // DIAGONAL BOTTOM-LEFT->RIGHT-TOP VALIDATION
                for (int i = 0; i < 4; i++)
                {
                    if (puzzle[3 - i, i] == -1)
                    {
                        lineEmptySpaces++;
                        emptySpace = i;
                    }
                    else lineSum = lineSum + puzzle[3-i, i];
                }
                if (lineEmptySpaces == 1) puzzle[3-emptySpace, emptySpace] = topValue - lineSum; 
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(ValidateSolution() ?
                    "Puzzle SOLVED! ============================" :
                    "Puzzle -NOT- SOLVED! ============================");
            printPuzzle(puzzle);
        }
        public static bool ValidateSolution()
        {
            // HORIZONTAL VALIDATION
                for (int i = 0; i < 4; i++)
                {
                    lineSum = 0;
                    for (int j = 0; j < 4; j++) lineSum = lineSum + puzzle[i, j];
                    if ((lineSum != puzzle[i, 4])) return false;
                }
            // VERTICAL VALIDATION
                for (int i = 0; i < 4; i++)
                {
                    lineSum = 0;
                    for (int j = 0; j < 4; j++) lineSum = lineSum + puzzle[j, i];
                    if ((lineSum != puzzle[4, i])) return false;
                }

            // DIAGONAL TOP-LEFT->RIGHT-BOTTOM VALIDATION
            lineSum = 0;
                for (int i = 0; i < 4; i++) lineSum = lineSum + puzzle[i, i];
                if (lineSum != puzzle[4, 4]) return false;

            // DIAGONAL BOTTOM-LEFT->RIGHT-TOP VALIDATION
                lineSum = 0;
                for (int i = 0; i < 4; i++) lineSum = lineSum + puzzle[3 - i, i];
                if (lineSum != topValue) return false;

            return true;
        }
        public static void printPuzzle(int [,] puzzle)
        {
            Console.WriteLine("                    [19]");
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    if (puzzle[i,j]==-1) Console.Write("[  ] ");
                    else                 Console.Write(puzzle[i, j] < 10 ? "[0" + puzzle[i, j] + "] " : "[" + puzzle[i, j] + "] ");
                }
                Console.WriteLine();
            }
        }
    }
}
