using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.ConsoleView.essentials
{
    public class InputAsker
    {
        public int askForNumericInput(string message)
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

        public string askForTextInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void anyKeyInput(string message)
        {
            Console.WriteLine(message);
            ConsoleKeyInfo option = Console.ReadKey();

        }
    }
}
