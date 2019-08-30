using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.UI.ConsoleView.Menu
{
    public interface IMenuItem
    {

        string getName();

        void display();
    }
}
