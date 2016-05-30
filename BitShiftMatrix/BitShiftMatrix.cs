namespace BitShiftMatrix
{
    using System;
    using System.Linq;
    using System.Numerics;

    class BitShiftMatrix
    {
        static int[] GetArray()
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(s => int.Parse(s)).ToArray();
            return arr;
        }

        static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = int.Parse(Console.ReadLine());
            var matrix = new BigInteger[colsCount, rowsCount];
            int numberOfMoves = int.Parse(Console.ReadLine());
            var moves = GetArray();
            var coeff = Math.Max(rowsCount, colsCount);
            BigInteger sum = 0;

            var pawn = new int[] { 0, rowsCount - 1 };

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[col, row] = (BigInteger)Math.Pow(2, rowsCount - 1 - row + col);
                }
            }
            foreach (var move in moves)
            {
                var targetRow = move / coeff;
                var targetCol = move % coeff;
                while (pawn[0] != targetCol)
                {
                    sum += matrix[pawn[0], pawn[1]];
                    matrix[pawn[0], pawn[1]] = 0;
                    if (pawn[0] > targetCol)
                    {
                        pawn[0]--;
                    }
                    else
                    {
                        pawn[0]++;
                    }
                }
                while (pawn[1] != targetRow)
                {
                    sum += matrix[pawn[0], pawn[1]];
                    matrix[pawn[0], pawn[1]] = 0;
                    if (pawn[1] > targetRow)
                    {
                        pawn[1]--;
                    }
                    else
                    {
                        pawn[1]++;
                    }
                }
            }
            sum += matrix[pawn[0], pawn[1]];
            matrix[pawn[0], pawn[1]] = 0;
            Console.WriteLine(sum);
        }
    }
}
