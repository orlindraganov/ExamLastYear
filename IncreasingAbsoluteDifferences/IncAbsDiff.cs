namespace IncreasingAbsoluteDifferences
{
    using System;
    using System.Linq;

    class IncAbsDiff
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
            int count = int.Parse(Console.ReadLine());
            var isIncAbsDiff = new bool[count];
            for (int i = 0; i < count; i++)
            {
                var numbers = GetArray();
                var differences = new int[numbers.Length - 1];
                bool isValidDifference = true;
                for (int j = 0; j < differences.Length; j++)
                {
                    differences[j] = Math.Abs(numbers[j + 1] - numbers[j]);
                    if (j == 0)
                    {
                        continue;
                    }
                    else if (!(j > 0
                        && isValidDifference
                        && (differences[j] - differences[j - 1] == 1
                        || differences[j] - differences[j - 1] == 0)))
                    {
                        isValidDifference = false;
                        break;
                    }
                }
                isIncAbsDiff[i] = isValidDifference;
            }
            foreach (var difference in isIncAbsDiff)
            {
                Console.WriteLine(difference);
            }
        }
    }
}
