using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzInterview
{
    public class Puzzle
    {
        int topValue;
        int lineSum = 0;
        int sumLinesSolved = 0;
        int lineEmptySpaces = 0;
        int emptySpace = -1;

        public int[,] puzzle { get; set; }
        public Puzzle() { }
        public Puzzle(int[,] puzzle, int topValue)
        {
            this.puzzle = puzzle;
            this.topValue = topValue;
        }
        public bool Solve()
        {
            bool puzzleSolved = false;
            while (!puzzleSolved)
            {
                lineSum = 0;
                lineEmptySpaces = 0;
                emptySpace = -1;

                if (SolveHorizontal() == 4) break;
                if (SolveVertical() == 4) break;
                SolveDiagonalTop();
                SolveDiagonalBottom();
            }
            return ValidateSolution();
        }
        public int SolveHorizontal()
        {
            sumLinesSolved = 0;
            // 
            for (int i = 0; i < 4; i++)
            {
                lineSum = lineEmptySpaces = emptySpace = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (puzzle[i, j] == -1)
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
                else if (lineEmptySpaces == 0) sumLinesSolved++;
            }
            return sumLinesSolved;
        }
        public int SolveVertical()
        {
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
            return sumLinesSolved;
        }
        public void SolveDiagonalTop()
        {
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
        }
        public void SolveDiagonalBottom()
        {
            lineSum = lineEmptySpaces = emptySpace = 0;
            // DIAGONAL BOTTOM-LEFT->RIGHT-TOP VALIDATION
            for (int i = 0; i < 4; i++)
            {
                if (puzzle[3 - i, i] == -1)
                {
                    lineEmptySpaces++;
                    emptySpace = i;
                }
                else lineSum = lineSum + puzzle[3 - i, i];
            }
            if (lineEmptySpaces == 1) puzzle[3 - emptySpace, emptySpace] = topValue - lineSum;
        }
        public bool ValidateSolution()
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
        public void PrintPuzzle()
        {
            Console.WriteLine("                    ["+topValue+"]");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (puzzle[i, j] == -1) Console.Write("[  ] ");
                    else Console.Write(puzzle[i, j] < 10 ? "[0" + puzzle[i, j] + "] " : "[" + puzzle[i, j] + "] ");
                }
                Console.WriteLine();
            }
        }
    }
}