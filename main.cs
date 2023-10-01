using System;
using System.Collections.Generic;

class EightQueensSolver
{
    public static IList<IList<string>> SolveNQueens(int n)
    {
        IList<IList<string>> solutions = new List<IList<string>>();
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++)
        {
            board[i] = new char[n];
            for (int j = 0; j < n; j++)
            {
                board[i][j] = '.';
            }
        }

        Solve(board, 0, solutions);
        return solutions;
    }

    private static void Solve(char[][] board, int col, IList<IList<string>> solutions)
    {
        if (col == board.Length)
        {
            solutions.Add(CreateSolution(board));
            return;
        }

        for (int row = 0; row < board.Length; row++)
        {
            if (IsSafe(board, row, col))
            {
                board[row][col] = 'Q';
                Solve(board, col + 1, solutions);
                board[row][col] = '.';
            }
        }
    }

    private static bool IsSafe(char[][] board, int row, int col)
    {
        // Check if a queen can be placed in the given row and column
        for (int i = 0; i < col; i++)
        {
            if (board[row][i] == 'Q')
            {
                return false;
            }
        }

        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i][j] == 'Q')
            {
                return false;
            }
        }

        for (int i = row, j = col; i < board.Length && j >= 0; i++, j--)
        {
            if (board[i][j] == 'Q')
            {
                return false;
            }
        }

        return true;
    }

    private static IList<string> CreateSolution(char[][] board)
    {
        IList<string> solution = new List<string>();
        foreach (var row in board)
        {
            solution.Add(new string(row));
        }
        return solution;
    }

    static void Main(string[] args)
    {
        int n = 8;
        IList<IList<string>> solutions = SolveNQueens(n);

        int solutionNumber = 1;
        foreach (var solution in solutions)
        {
            Console.WriteLine($"Solution {solutionNumber++}:");
            foreach (var row in solution)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine();
        }
    }
}
