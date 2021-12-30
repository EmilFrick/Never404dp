using never_404._404Accounts;
using never_404._404BankServices;
using never_404._404Users;
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

        public static List<string> AddOptionBackToMainMenu(this List<string> options)
        {
            options.Add("Back to main menu");
            return options;
        }

        public static string RequiredMinAndMaxLength(this string input, string field, int minLength, int maxLength)
        {
            while (true)
            {
                if (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
                {
                    Console.WriteLine($"{field} cannot be empty. We need at least {minLength} characters.");
                    Console.Write($"{field}: ");
                    input = Console.ReadLine();
                }
                else if(input.Trim().Length < minLength)
                {
                    Console.WriteLine($"{input} cannot contain less than {minLength} characters");
                    Console.Write($"Receiver: ");
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

        public static int ReceiverAccountValidation(this string input)
        {
            int validInput = input.ConvertToValidNumBetween("Receiver", 9999, 1000000000);

            while (true)
            {
                if (validInput != ActiveUser.GetActiveUser().ActiveAssembledAccount.AccountNumber)
                {
                    return validInput;
                }

                Console.WriteLine("You are not able to make a transaction to an account that you're sending from:");
                Console.Write("Receiver: ");
                validInput = Console.ReadLine().ConvertToValidNumBetween("Receiver", 9999, 1000000000);
            }

        }

       
    }
}
