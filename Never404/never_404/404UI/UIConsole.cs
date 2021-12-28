using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404.Repository
{
    public class UIConsole
    {
        public static string GetFieldInput(string fieldName)
        {
            Console.Write($"{fieldName}: ");
            return Console.ReadLine();
        }

        public static void AddHeader(string title)
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine("------------------");
        }

        public static string GetSelectedOption(List<string> options)
        {
            var sb = new StringBuilder();
            var count = 1;
            foreach (var option in options)
            {
                sb.AppendLine($"{count++}. {option}");
            }

            Console.WriteLine(sb);
            Console.WriteLine("------------------");
            Console.Write("Your choice: ");

            return Console.ReadLine();
        }
    }
}
