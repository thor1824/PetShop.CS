using Dapper;
using PetShop.Infrastructure.Data.MockDB;
using PetShop.Infrastructure.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
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
                "PetID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
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

        public static void buildData()
        {
            IDbConnection conn = ConnectionCreater.CreateConnection();
            conn.Open();
            //conn.Execute("INSERT INTO Pet(pet_name, pet_type, pet_birthdate, pet_sold_date, pet_previous_owner_id, pet_color, pet_price) " +
            //   "VALUES ()");
            //cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table'";
            //SQLiteDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.GetString(0));
            //}

            foreach (var item in TestDB.GetPetsInDB())
            {
                conn.Execute("INSERT INTO Pet(pet_name, pet_type, pet_birthdate, pet_sold_date, pet_previous_owner_id, pet_color, pet_price) " +
               "VALUES (@Name, " + (int)item.PType.Value + ")", item);
                //    string query = "INSERT INTO Pet (pet_name, pet_type, pet_birthdate, pet_sold_date, pet_previous_owner_id, pet_color, pet_price) " +
                //    "VALUES ('" +
                //    item.Name + "', " +
                //    (int) item.PType.Value + ", '" +
                //    item.BirthDate.ToString() + "', '" +
                //    item.SoldDate.ToString()+"', " +
                //    item.PriviousOwner.Id + ", '" +
                //    item.Color + "', " +
                //    item.Price + ")";
                //    cmd.CommandText = query;
                //    cmd.ExecuteNonQuery();
            }
            //foreach (var item in TestDB.owners)
            //{
            //    cmd.CommandText = "INSERT INTO Owner (owner_first_name, owner_last_name, owner_address, owner_email, owner_phone_no) " +
            //        "VALUES ({0}, {1}, {2}, {3}, {4})";
            //}
        }
    }
}
