using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static char[,] matrix =     // change the position of 'e' to see how it works
    {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', '*', ' ', '*', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', '*'},
        {' ', '*', ' ', '*', ' ', ' ', '*'},
    };

    static bool[,] included = new bool[matrix.GetLength(0), matrix.GetLength(0)];
    static List<int> emptyCellsCount = new List<int>();

    static void FindAdjacentEmptyCells(int row, int col, int count)
    {
        int matrixSize = matrix.GetLength(0);
        included[row, col] = true;
        count++;
        bool inCycle = false;

        if (row + 1 < matrixSize)
        {
            if (matrix[row + 1, col] == ' ' && included[row + 1, col] == false)
            {
                FindAdjacentEmptyCells(row + 1, col, count);
                inCycle = true;
            }
        }

        if (row - 1 >= 0)
        {
            if (matrix[row - 1, col] == ' ' && included[row - 1, col] == false)
            {
                FindAdjacentEmptyCells(row - 1, col, count);
                inCycle = true;
            }
        }

        if (col + 1 < matrixSize)
        {
            if (matrix[row, col + 1] == ' ' && included[row, col + 1] == false)
            {
                FindAdjacentEmptyCells(row, col + 1, count);
                inCycle = true;
            }
        }

        if (col - 1 >= 0)
        {
            if (matrix[row, col - 1] == ' ' && included[row, col - 1] == false)
            {
                FindAdjacentEmptyCells(row, col - 1, count);
                inCycle = true;
            }
        }

        if(!inCycle) emptyCellsCount.Add(count);

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                if (included[i, j] == false && matrix[i, j] == ' ')
                {
                    FindAdjacentEmptyCells(i, j, 0);
                }
            }            
        }
        return;
    }

    static void PrintMatrix()
    {
        Console.WriteLine(" - - - - - - -");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write("|");
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (j == matrix.GetLength(0) - 1)
                {
                    Console.Write(matrix[i, j]);
                }
                else
                {
                    Console.Write(matrix[i, j] + " ");
                }
            }
            Console.Write("|");
            Console.WriteLine();
        }
        Console.WriteLine(" - - - - - - -");
        Console.WriteLine();
    }

    static void Main()
    {
        PrintMatrix();
        FindAdjacentEmptyCells(0, 0, 0);

        foreach (var item in emptyCellsCount)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Maximum area: ");
        Console.WriteLine(emptyCellsCount.Max());
    }
}
