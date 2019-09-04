using PetShop.Infrastructure.Data.Sqlite;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    class PetDbRepository : IRepository<Pet>
    {
        public Pet Create(Pet entity)
        {
            SQLiteConnection conn = ConnectionCreater.CreateConnection();
            conn.Open();
            SQLiteCommand comm =conn.CreateCommand();
            comm.CommandText = "";
            comm.ExecuteNonQuery();
            conn.Close();
            return null;
        }

        public Pet Delete(Pet entity)
        {
            SQLiteConnection conn = ConnectionCreater.CreateConnection();
            conn.Open();
            SQLiteCommand comm = conn.CreateCommand();
            comm.CommandText = "";
            comm.ExecuteNonQuery();
            conn.Close();
            return null;
        }

        public Pet Read(int id)
        {
            SQLiteConnection conn = ConnectionCreater.CreateConnection();
            conn.Open();
            SQLiteCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT * FROM Pets";

            SQLiteDataReader reader = comm.ExecuteReader();
            Pet pet;
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(1));
                
            }
            conn.Close();
            return null;
        }

        public IEnumerable<Pet> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Pet Update(Pet entity)
        {
            throw new NotImplementedException();
        }
    }
}
