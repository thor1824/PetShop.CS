using System;
using PetShopApp.UI.ConsoleView.Actionator;

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
        }

        public string getName()
        {
            return name;
        }
    }
}
