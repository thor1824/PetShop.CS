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
            return new SQLiteConnection("Data Source = C:/Users/thor1/source/repos/PetShop/PetShop.Infrastructure.Data/db/ParaBellumDB.db; Version = 3;");
        }

    }
}
