namespace DeCatCoding
{
    using System;
    using System.Numerics;
    using System.Collections.Generic;
    using System.Text;


    class DeCatCoding
    {
        //Dictionary requires System.Collections.Generic
        //BigInteger requires System.Numerics
        //StringBuilder requires System.Text

        static string ConvertDecToHum(BigInteger dec)
        {
            StringBuilder hum = new StringBuilder();
            do
            {
                hum.Insert(0, dechumval[(int)(dec % 26)]);
                dec = dec / 26;
            }
            while (dec != 0);
            return hum.ToString();
        }

        static Dictionary<int, char> dechumval = new Dictionary<int, char>{
        {0, 'a'},
        {1, 'b'},
        {2, 'c'},
        {3, 'd'},
        {4, 'e'},
        {5, 'f'},
        {6, 'g'},
        {7, 'h'},
        {8, 'i'},
        {9, 'j'},
        {10, 'k'},
        {11, 'l'},
        {12, 'm'},
        {13, 'n'},
        {14, 'o'},
        {15, 'p'},
        {16, 'q'},
        {17, 'r'},
        {18, 's'},
        {19, 't'},
        {20, 'u'},
        {21, 'v'},
        {22, 'w'},
        {23, 'x'},
        {24, 'y'},
        {25, 'z'},
    };


        //Dictionary requires System.Collections.Generic
        //BigInteger requires System.Numerics
        static BigInteger ConvertCatToDec(string cat)
        {
            BigInteger dec = 0;
            foreach (char digit in cat)
            {
                dec = catdecval[digit] + dec * 21;
            }
            return dec;
        }

        static Dictionary<char, int> catdecval = new Dictionary<char, int>
     {
        {'a', 0},
        {'b', 1},
        {'c', 2},
        {'d', 3},
        {'e', 4},
        {'f', 5},
        {'g', 6},
        {'h', 7},
        {'i', 8},
        {'j', 9},
        {'k', 10},
        {'l', 11},
        {'m', 12},
        {'n', 13},
        {'o', 14},
        {'p', 15},
        {'q', 16},
        {'r', 17},
        {'s', 18},
        {'t', 19},
        {'u', 20},
    };

        static void Main()
        {
            var catWords = Console.ReadLine().Split(' ');
            var catNumbers = new BigInteger[catWords.Length];
            for (int i = 0; i < catNumbers.Length; i++)
            {
                catNumbers[i] = ConvertCatToDec(catWords[i]);
            }
            var humanWords = new string[catWords.Length];
            for (int i = 0; i < humanWords.Length; i++)
            {
                humanWords[i] = ConvertDecToHum(catNumbers[i]);
            }
            Console.WriteLine(string.Join(" ", humanWords));
        }
    }
}
