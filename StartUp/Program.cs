using PetShop.Infrastructure.Data.MockDB;
using PetShop.Infrastructure.Data.Repositories;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.ConsoleView.Actionator;
using PetShopApp.UI.ConsoleView.Actionator.OwnerActionators;
using PetShopApp.UI.ConsoleView.Actionator.PetActionators;
using PetShopApp.UI.ConsoleView.Menu;
using System;
using System.Collections.Generic;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDB.InitDB();

            SortedList<int, IMenuItem> options = new SortedList<int, IMenuItem>();


            //Init Repositories
            IRepository<Pet> petRepo = new PetRepository();
            IRepository<Owner> ownerRepo = new OwnerRepository();

            //Init Services 
            IPetService petService = new PetService(petRepo);
            IOwnerService ownerService = new OwnerService(ownerRepo);

            //init Creat MenuItems
            options.Add(1, new LeafMenuItem("Create", new PetCreateinator(petService)));

            //init Read MenuItems

            SortedList<int, IMenuItem> readOptions = new SortedList<int, IMenuItem>();

            ////pet
            SortedList<int, IMenuItem> readPetOptions = new SortedList<int, IMenuItem>();

            readPetOptions.Add(1, new LeafMenuItem("Show All Pets", new ShowAllPetsinator(petService)));
            readPetOptions.Add(2, new LeafMenuItem("Show and Sort Pets by Type", new SeachPetByTypeinator(petService)));
            readPetOptions.Add(3, new LeafMenuItem("Show and Sort Pets by Price", new SortByPriceinator(petService)));
            readPetOptions.Add(4, new LeafMenuItem("Show 5 Cheapest Pets", new FiveCheapestPetsinator(petService)));
            readOptions.Add(1, new BranchMenuItem("Pet" ,readPetOptions) );
            ////Owner
            SortedList<int, IMenuItem> readOwnerOptions = new SortedList<int, IMenuItem>();

            readOwnerOptions.Add(1, new LeafMenuItem("Read", new OwenerReadAllinator(ownerService)));
            readOwnerOptions.Add(2, new LeafMenuItem("Read All", new OwnerReadinator(ownerService)));
            readOptions.Add(2, new BranchMenuItem("Owner", readOwnerOptions));

            options.Add(2, new BranchMenuItem("Read", readOptions));
            
            //init Update MenuItems
            options.Add(3, new LeafMenuItem("Update", new PetUpdateinator(petService)));

            //init Delete MenuItems
            options.Add(4, new LeafMenuItem("Delete", new test()));

            BranchMenuItem main = new BranchMenuItem(
                "                                                                           \n" +
                "       _____               _____           ____   ____             _____   \n" +
                "   ___|\\    \\          ___|\\    \\         |    | |    |        ___|\\    \\  \n" +
                "  /    /\\    \\        |    |\\    \\        |    | |    |       |    |\\    \\ \n" +
                " |    |  |    |       |    | |    |       |    | |    |       |    | |    |\n" +
                " |    |  |____|       |    |/____/        |    | |    |       |    | |    |\n" +
                " |    |   ____        |    |\\    \\        |    | |    |       |    | |    |\n" +
                " |    |  |    |       |    | |    |       |    | |    |       |    | |    |\n" +
                " |\\ ___\\/    /|  ___  |____| |____|  ___  |\\___\\_|____|  ___  |____|/____/|\n" +
                " | |   /____/ | |   | |    | |    | |   | | |    |    | |   | |    /    | |\n" +
                " \\| ___|    | / |___| |____| |____| |___|  \\|____|____| |___| |____|____|/ \n" +
                "    \\( |____|/          \\(     )/             \\(   )/           \\(    )/   \n" +
                "     '   )/              '     '               '   '             '    '    \n" +
                "         '                                                                 \n" +
                "  -The PetShop\n",
                options);
            main.display();
        }

        private static SortedList<int, IMenuItem> getCreateOptions()
        {
            SortedList<int, IMenuItem> options = new SortedList<int, IMenuItem>();
            options.Add(1, new LeafMenuItem("Create new Pet", new test()));

            return options;
        }
        
        private static SortedList<int, IMenuItem> getUpdateOptions()
        {
            SortedList<int, IMenuItem> options = new SortedList<int, IMenuItem>();
            options.Add(1, new LeafMenuItem("Update a Pet", new test()));

            return options;
        }
        private static SortedList<int, IMenuItem> getDeleteOptions()
        {
            SortedList<int, IMenuItem> options = new SortedList<int, IMenuItem>();
            options.Add(1, new LeafMenuItem("Delete a Pet", new test()));

            return options;
        }
    }
}
