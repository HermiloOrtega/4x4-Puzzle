using System;

namespace QuartzInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumLineSolved = 0;
            int lineSum = 0;
            int lineEmptySpaces = 0;
            int emptySpace = 0;
            // Create the Puzzle
            int[,] puzzle = new int[5, 5] {
                {  5, -1,  8, -1, 23},
                { -1, -1,  7,  0,  8},
                {  4, -1,  7,  8, 23},
                { -1, -1, -1,  7, 20},
                { 16, 18, 22, 18, 19}
            };
            // Save the Value from the Top Right Value
            int topValue = 20;

            
            Console.WriteLine("Puzzle ============================");
            printPuzzle(puzzle);
            bool puzzleSolved = false;
            while (!puzzleSolved)
            {
                sumLineSolved = 0;
                lineSum = 0;
                lineEmptySpaces = 0;
                emptySpace = 0;

                // Horizontal Loop
                for (int i = 0; i < 4; i++)
                {
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
                        sumLineSolved++;
                    }
                    else if(lineEmptySpaces == 0)
                    {
                        sumLineSolved++;
                    }
                }
                if (sumLineSolved == 4)
                {
                    puzzleSolved = true;
                    break;
                }

                sumLineSolved = 0;
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
                        sumLineSolved++;
                    }
                    else if (lineEmptySpaces == 0)
                    {
                        sumLineSolved++;
                    }
                }
                if (sumLineSolved == 4)
                {
                    puzzleSolved = true;
                    break;
                }

                sumLineSolved = 0;
                lineSum = lineEmptySpaces = emptySpace = 0;
                // DIAGONAL LEFT RIGHT Loop
                for (int i = 0; i < 4; i++)
                {
                    if (puzzle[i, i] == -1)
                    {
                        lineEmptySpaces++;
                        emptySpace = i;
                    }
                    else lineSum = lineSum + puzzle[i, i];
                }
                if (lineEmptySpaces == 1)
                {
                    puzzle[emptySpace, emptySpace] = puzzle[4, 4] - lineSum;
                }

                lineSum = lineEmptySpaces = emptySpace = 0;
                // DIAGONAL RIGHT LEFT Loop
                for (int i = 0; i < 4; i++)
                {
                    if (puzzle[3 - i, i] == -1)
                    {
                        lineEmptySpaces++;
                        emptySpace = i;
                    }
                    else lineSum = lineSum + puzzle[3-i, i];
                }
                if (lineEmptySpaces == 1)
                {
                    puzzle[3-emptySpace, emptySpace] = topValue - lineSum;
                }
            }

            bool finalReview = true;
            for (int i = 0; i < 4; i++)
            {
                lineSum = 0;
                for (int j = 0; j < 4; j++)
                {
                    lineSum = lineSum + puzzle[i, j];
                }
                if (lineSum != puzzle[i, 4])
                {
                    finalReview = false;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                lineSum = 0;
                for (int j = 0; j < 4; j++)
                {
                    lineSum = lineSum + puzzle[j, i];
                }
                if (lineSum != puzzle[4, i])
                {
                    finalReview = false;
                }
            }

            lineSum = 0;
            for (int i = 0; i < 4; i++)
            {
                lineSum = lineSum + puzzle[i, i];
            }
            if (lineSum != puzzle[4, 4])
            {
                finalReview = false;
            }

            lineSum = 0;
            for (int i = 0; i < 4; i++)
            {
                lineSum = lineSum + puzzle[3 - i, i];
            }
            if (lineSum != topValue)
            {
                finalReview = false;
            }

            Console.WriteLine();
            Console.WriteLine();
            if (finalReview == false)
            {
                Console.WriteLine("The puzzle was not fully solved, there are some issues in the operations ============================");
            }
            else
            {
                Console.WriteLine("Puzzle SOLVED ============================");
                printPuzzle(puzzle);
            }
        }
        public static void printPuzzle(int [,] puzzle)
        {
            Console.WriteLine("                    [19]");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (puzzle[i,j]==-1)
                    {
                        Console.Write("[  ] ");
                    }
                    else
                    {
                        if (puzzle[i, j]<10)
                        {
                            Console.Write("[0" + puzzle[i, j] + "] ");
                        }
                        else
                        {
                            Console.Write("[" + puzzle[i, j] + "] ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
