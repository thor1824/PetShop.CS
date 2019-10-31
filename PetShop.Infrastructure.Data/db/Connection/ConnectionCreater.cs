using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace PetShop.Infrastructure.Data.db.Connection
{
    public class ConnectionCreater
    {
        public static SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = D:/Dokumenter/repos/CS/PetShop.CS/PetShop.Infrastructure.Data/db/ParaBellumDB.db; Version = 3;");
        }

    }
}
