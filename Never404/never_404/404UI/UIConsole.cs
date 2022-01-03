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

        public static void AddField(string fieldName)
        {
            Console.WriteLine($"{fieldName}: ");
        }

        public static void AddFields(params string [] fields)
        {
            var sb = new StringBuilder();
            foreach (var field in fields)
            {
                sb.AppendLine(field);
            }

            Console.WriteLine(sb);
            Console.ReadLine();
        }

        public static void AddTableHeader(int columnLength, params string[] titles)
        {
            var sb = new StringBuilder();
            var hr = "-----------------------------------------------------------------------------------------------------------";
            foreach (var title in titles)
            {
                sb.Append(CreateColumn(columnLength, title));
            }


            Console.WriteLine(sb);
            Console.WriteLine(hr.Substring(0, sb.Length - 1));
            
        }

        private static string CreateColumn(int columnLength, string tableItem)
        {
            var whiteSpace = "                                    ";
            if (tableItem.Length >= columnLength)
            {
                return tableItem.Substring(0, columnLength - 4) + "... ";
            }

            if (tableItem.Length < columnLength)
            {
                return tableItem + whiteSpace.Substring(0, columnLength - tableItem.Length);
            }

            return tableItem;
        }

        public static void AddTableRow(int columnLength, params string[] row)
        {
            var sb = new StringBuilder();

            foreach (var item in row)
            {
                sb.Append(CreateColumn(columnLength, item));
            }

            Console.WriteLine(sb);
        }

        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void SetDefaultColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
