using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace PetShop.Infrastructure.Data.Sqlite
{
    public class ConnectionCreater
    {
        public static SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = D:/Dokumenter/repos/CS/PetShop.CS/PetShop.Infrastructure.Data/Sqlite/PetShopDB.db; Version = 3;");
        }

    }
}
