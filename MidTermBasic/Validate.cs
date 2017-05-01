using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermBasic
{
    class Validate
    {

        public static int RangeValidator(int min, int max)

        {

            int input;

            //Console.WriteLine($"Please enter an Integer between {min} and {max}");

            input = GetValidInteger();

            while (input < min || input > max)

            {

                Console.WriteLine("Wrong input! please enter number within range!");

                input = GetValidInteger();

            }

            return input;



        }

        public static int GetValidInteger()
        {
            int input;

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("This is not a integer, please enter a integer");
            }
            return input;
        }

        public static bool Continue()
        {
            Console.WriteLine("Do you want to continue? (y/n)");

            string input = Console.ReadLine();
            Console.Clear();

            if (input.ToLower() == "n")
            {
                return false;
            }
            else if (input.ToLower() == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input");
                Continue();
                return true;
            }

        }

        public static string GetValidString()
        {
            string Input = Console.ReadLine().ToLower();
            // Validate Input
            while ((string.IsNullOrEmpty(Input)) || (string.IsNullOrWhiteSpace(Input))) //you can add more ifs to this or compare with a string.

            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.Write("You Must Enter a Word  ---> 'rock' 'paper' or 'scissors'  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Input = Console.ReadLine().ToLower(); ;
            }
            return Input;
        }

    }
}
