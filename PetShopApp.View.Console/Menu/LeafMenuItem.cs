using System;
using PetShopApp.UI.ConsoleView.Actionator;
using PetShopApp.UI.ConsoleView.essentials;

namespace PetShopApp.UI.ConsoleView.Menu
{
    public class LeafMenuItem : IMenuItem
    {
        private string seperator = "--------------------------------------------------------";
        private IActionator actionator;
        private string name;
        public LeafMenuItem(string inName, IActionator actionator)
        {
            name = inName;
            this.actionator = actionator;
        }
        public void display()
        {
            Console.Clear();
            Console.WriteLine(name);
            Console.WriteLine(seperator);
            actionator.go();
            Console.WriteLine(seperator);
            InputAsker.anyKeyInput("Press any key to return");

        }

        public string getName()
        {
            return name;
        }
    }
}
