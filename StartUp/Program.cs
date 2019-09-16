using PetShop.Infrastructure.Data.db;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Infrastructure.SQLite.Repositories;
using PetShopApp.UI.ConsoleView.Actionator;
using PetShopApp.UI.ConsoleView.Actionator.OwnerActionators;
using PetShopApp.UI.ConsoleView.Actionator.PetActionators;
using PetShopApp.UI.ConsoleView.essentials;
using PetShopApp.UI.ConsoleView.Menu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {

            ////Init Repositories
            IRepository<Pet> petRepo = new PetRepository();
            IRepository<Owner> ownerRepo = new OwnerRepository();

            ////Init Services 
            IPetService petService = new PetService(petRepo);
            IOwnerService ownerService = new OwnerService(ownerRepo);

            //init UI - Leaf And Branch Menuitems
            SortedList<int, IMenuItem> options = new SortedList<int, IMenuItem>();
            options.Add(1, new BranchMenuItem("Create", GetCreateOptions(petService, ownerService)));
            options.Add(2, new BranchMenuItem("Read", GetReadOptions(petService, ownerService)));
            options.Add(3, new BranchMenuItem("Update", GetUpdateOptions(petService, ownerService)));
            options.Add(4, new BranchMenuItem("Delete", GetDeleteOptions(petService, ownerService)));

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
            Console.Clear();
            




        }

        private static SortedList<int, IMenuItem> GetReadOptions(IPetService petService, IOwnerService ownerService)
        {
            SortedList<int, IMenuItem> readOptions = new SortedList<int, IMenuItem>();

            ////pet
            SortedList<int, IMenuItem> readPetOptions = new SortedList<int, IMenuItem>();
            readPetOptions.Add(1, new LeafMenuItem("Show Pet", new PetReadinator(petService)));
            readPetOptions.Add(2, new LeafMenuItem("Show All Pets", new ShowAllPetsinator(petService)));
            readPetOptions.Add(3, new LeafMenuItem("Show and Sort Pets by Type", new SeachPetByTypeinator(petService)));
            readPetOptions.Add(4, new LeafMenuItem("Show and Sort Pets by Price", new SortByPriceinator(petService)));
            readPetOptions.Add(5, new LeafMenuItem("Show Five Cheapest Pets", new FiveCheapestPetsinator(petService)));

            readOptions.Add(1, new BranchMenuItem("Read Pet", readPetOptions));
            
            ////Owner
            SortedList<int, IMenuItem> readOwnerOptions = new SortedList<int, IMenuItem>();
            readOwnerOptions.Add(1, new LeafMenuItem("Show Owner", new OwnerReadinator(ownerService)));
            readOwnerOptions.Add(2, new LeafMenuItem("Show All Owners", new OwnerReadAllinator(ownerService)));

            readOptions.Add(2, new BranchMenuItem("Read Owner", readOwnerOptions));

            return readOptions;
        }

        private static SortedList<int, IMenuItem> GetCreateOptions(IPetService petService, IOwnerService ownerService)
        {
            SortedList<int, IMenuItem> createOptions = new SortedList<int, IMenuItem>();
            createOptions.Add(1, new LeafMenuItem("Create new Pet", new PetCreateinator(petService, ownerService)));
            createOptions.Add(2, new LeafMenuItem("Create new Owner", new OwnerCreateinator(ownerService)));
            
            return createOptions; 
        }
        
        private static SortedList<int, IMenuItem> GetUpdateOptions(IPetService petService, IOwnerService ownerService)
        {
            SortedList<int, IMenuItem> options = new SortedList<int, IMenuItem>();
            options.Add(1, new LeafMenuItem("Update Pet", new PetUpdateinator(petService, ownerService)));
            options.Add(2, new LeafMenuItem("Update Owner", new OwnerUpdateinator(ownerService)));

            return options;
        }
        private static SortedList<int, IMenuItem> GetDeleteOptions(IPetService petService, IOwnerService ownerService)
        {
            SortedList<int, IMenuItem> options = new SortedList<int, IMenuItem>();
            options.Add(1, new LeafMenuItem("Delete Pet", new PetDeleteinator(petService)));
            options.Add(2, new LeafMenuItem("Delete Owner", new OwnerDeleteinator(ownerService)));

            return options;
        }
    }
}
