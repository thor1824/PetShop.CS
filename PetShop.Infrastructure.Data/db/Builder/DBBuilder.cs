using Dapper;
using PetShop.Infrastructure.Data.MockDB;
using PetShop.Infrastructure.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace PetShop.Infrastructure.Data.db
{
    public class DBBuilder
    {
       
        

        public static void BuildTabels()
        {
            IDbConnection conn = ConnectionCreater.CreateConnection();
            conn.Open();
            conn.Execute(
                "CREATE TABLE Owner (" +
                "owner_id  INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                "owner_first_name  TEXT NOT NULL, " +
                "owner_last_name   TEXT NOT NULL," +
                "owner_address TEXT NOT NULL, " +
                "owner_email   TEXT NOT NULL," +
                "owner_phone_no    TEXT NOT NULL)"
                );

            conn.Execute("CREATE TABLE Pet (" +
                "pet_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                "pet_name  TEXT NOT NULL," +
                "pet_type  INTEGER NOT NULL," +
                "pet_birthdate TEXT NOT NULL, " +
                "pet_sold_date TEXT, " +
                "pet_previous_owner_id INTEGER, " +
                "pet_color TEXT NOT NULL, " +
                "pet_price REAL NOT NULL, " +
                "FOREIGN KEY(pet_previous_owner_id) REFERENCES Owner(owner_id))"
                );

            conn.Close();
            
        }

        public static void BuildData()
        {
            SQLiteConnection conn = ConnectionCreater.CreateConnection();
            conn.Open();
            
            conn.Execute("DELETE FROM Pet");
            foreach (var item in TestDB.GetPetsInDB())
            {
                conn.Execute("INSERT INTO Pet(pet_name, pet_type, pet_birthdate, pet_sold_date, pet_previous_owner_id, pet_color, pet_price) " +
               "VALUES (@Name, " + (int)item.PType.Value + ", @BirthDate, @SoldDate, " + (item.PriviousOwner == null ? "NULL" : ""+item.PriviousOwner.Id) + ", @Color, @Price)", item);
                Console.WriteLine(conn.LastInsertRowId);
            }

            conn.Execute("DELETE FROM Owner");
            foreach (var item in TestDB.GetOwnersInDB())
            {
                conn.Execute("INSERT INTO Owner (owner_first_name, owner_last_name, owner_address, owner_email, owner_phone_no) " +
                    "VALUES (@FirstName, @LastName, @Address, @Email, @PhoneNumber)", item);
            }
            conn.Close();
        }
    }
}
