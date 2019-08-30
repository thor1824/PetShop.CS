using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.ConsoleView.Menu
{
    public interface IMenuItem
    {

        string getName();

        void display();
    }
}
