using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5thOneVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> used = new List<char>() { '0' };
            Dictionary<char, HashSet<char>> digits = new Dictionary<char, HashSet<char>>();
            List<char> number = new List<char>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string current = Console.ReadLine();

                char first = current[0];
                char second = current[current.Length - 1];

                if (current[5] == 'b')
                {
                    char temp = first;
                    first = second;
                    second = temp;
                }

                if (digits.ContainsKey(first))
                {
                    digits[first].Add(second);
                    if (!digits.ContainsKey(second))
                    {
                        digits.Add(second, new HashSet<char>());
                    }
                }
                else
                {
                    digits.Add(first, new HashSet<char>() { second });
                    if (!digits.ContainsKey(second))
                    {
                        digits.Add(second, new HashSet<char>());
                    }
                }
            }
            char toAdd = FindSmallest(digits, used);
            used.Add(toAdd);
            number.Add(toAdd);
            used.Remove('0');
            for (int i = 0; i < digits.Count - 1; i++)
            {
                toAdd = FindSmallest(digits, used);
                used.Add(toAdd);
                number.Add(toAdd);

            }

            //if (number[0] == '0')
            //{
            //	number[0] = number[1];
            //	number[1] = '0';
            //}

            Console.WriteLine(new string(number.ToArray()));
        }

        static char FindSmallest(Dictionary<char, HashSet<char>> disgits, List<char> used)
        {
            char smallest = (char)100;

            foreach (var item in disgits)
            {
                if (!used.Contains(item.Key) && item.Value.Count == 0)
                {
                    smallest = smallest > item.Key ? item.Key : smallest;
                }
            }
            foreach (var item in disgits)
            {
                item.Value.Remove(smallest);
            }

            return smallest;

        }

        static bool Is(List<char> used2, List<char> list)
        {
            int size = Math.Min(used2.Count, list.Count);

            for (int i = 0; i < size; i++)
            {
                if (used2[i] != list[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}