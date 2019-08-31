using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.essentials
{
    public class InputAsker
    {
        public static int AskForNumericInput(string message)
        {
            int num;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Not a Numeric Value. \n" +
                    "Please try again. ");
            }

            return num;
        }

        public static string AskForTextInput(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }

        public static void anyKeyInput(string message)
        {
            Console.WriteLine(message);
            ConsoleKeyInfo option = Console.ReadKey();
        }

        public static DateTime AskForDate(string message)
        {
            Console.WriteLine(message);
            bool validtion = false;
            DateTime? dt = null;
            while (!validtion)
            {
                try
                {
                    int year = AskForNumericInput("Enter Year:");
                    int month = AskForNumericInput("Enter Month:");
                    int date = AskForNumericInput("Enter Date:");
                    dt = new DateTime(year, month, date);
                    validtion = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return dt.Value;
        }
    }
}
