using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace never_404.Repository
{
    static class UIExtensionMethods
    {
        public static int ConvertToValidNumBetween(this string input, string field, int min,  int max = 90000)
        {
            int num;
            while (true)
            {
                if (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
                {
                    Console.WriteLine($"{field} cannot be empty");
                    Console.Write($"{field}: ");
                    input = Console.ReadLine();
                }
                else if (!int.TryParse(input, out num))
                {
                    Console.WriteLine($"{field} must be a number");
                    Console.Write($"{field}: ");
                    input = Console.ReadLine();
                }
                    
                else if (num > max || num < min)
                {
                    Console.WriteLine($"The number must be between {min} and {max}");
                    Console.Write($"{field}: ");
                    input = Console.ReadLine();
                }

                else break;
            }

            return num;
        }

        public static string RegexSSN(this string input, string field)
        {
            while (true)
            {
                if (input != null && Regex.IsMatch(input, @"\d{6}-\d{4}"))
                    break;

                Console.WriteLine($"{field} is not in correct format (yymmdd-xxxx)");
                Console.Write($"{field}: ");
                input = Console.ReadLine();
            }

            return input;
        }

        public static string RequiredMaxLength(this string input, string field, int maxLength)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
                {
                    Console.WriteLine($"{field} cannot be empty");
                    Console.Write($"{field}: ");
                    input = Console.ReadLine();
                }
                else if (input.Trim().Length > maxLength)
                {
                    Console.WriteLine($"{field} cannot contain more than {maxLength} characters");
                    Console.Write($"{field}: ");
                    input = Console.ReadLine();
                }
                else
                    break;
            }

            return input;
        }
    }
}
