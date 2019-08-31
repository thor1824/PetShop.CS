using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Menu
{
    public class BranchMenuItem : IMenuItem
    {
        private readonly int exitInput = 0;
        //private readonly int startingPage = 1;
        private readonly string seperator = "---------------------------------------------------------------------------";
        private SortedList<int, IMenuItem> options;
        //private readonly SortedList<int, SortedList<int, IMenuItem>> pages;
        private readonly string name;

        public BranchMenuItem(string inName, SortedList<int, IMenuItem> inOptions)
        {
            name = inName;
            options = inOptions;
        }

        public void display()
        {
            Console.Clear();
            Console.WriteLine(name);
            Console.WriteLine(seperator);
            if (options.Count <= 7)
            {
                runSinglePageUI();
            }
            else
            {


            }



        }

        private void runSinglePageUI()
        {
            foreach (var item in options)
            {
                Console.WriteLine("[" + item.Key + "] - " + item.Value.getName());
            }

            Console.WriteLine("\n[" + exitInput + "] - Exit");
            Console.WriteLine(seperator);

            ConsoleKeyInfo option = Console.ReadKey();

            int input = 0;

            bool validInput = false;
            while (!validInput)
            {
                if (int.TryParse(option.KeyChar.ToString(), out input))
                {
                    if (options.ContainsKey(input) || input == exitInput)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine(" is not a Valid Input! Try again!");
                        option = Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine(" is not a Valid Input! Try again!");
                    option = Console.ReadKey();
                }

            }
            if (input != exitInput)
            {
                options[input].display();
                display();
            }
            else
            {
            }
        }

        private void runMulitpliPageUI()
        {
            //int maxPrPage = 7;
            //int i = 0;
            //int pageNumber = 0;
            //foreach (var item in options)
            //{
            //    if (i % maxPrPage == 0)
            //    {
            //        i = 0;
            //        pages.Add(pageNumber, )
            //        }
            //    i++;
            //}
        }

        public string getName()
        {
            return name;
        }
    }
}
