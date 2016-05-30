using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATastrophe
{
    class CATastrophe
    {
        static void Main()
        {
            var rowsCount = int.Parse(Console.ReadLine());
            var code = new StringBuilder();
            for (int i = 0; i < rowsCount; i++)
            {
                code.Append(Console.ReadLine());
                code.Append("\n\r");
            }
            Console.WriteLine(code);
        }
    }
}
