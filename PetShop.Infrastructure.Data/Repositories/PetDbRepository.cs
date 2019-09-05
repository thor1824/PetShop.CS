﻿using Dapper;
using PetShop.Infrastructure.Data.Sqlite;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    class PetDbRepository : IRepository<Pet>
    {
        public Pet Create(Pet entity)
        {
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                conn.Execute("INSERT INTO Pet " +
                    "(pet_name, pet_type, pet_birthdate, pet_sold_date, pet_previous_owner_id, pet_color, pet_price) " +
               "VALUES (@Name, " + (int)entity.PType.Value + ", @BirthDate, @SoldDate, " + (entity.PriviousOwner == null ? "NULL" : "" + entity.PriviousOwner.Id) + ", @Color, @Price)", entity);

                entity.Id = conn.LastInsertRowId;
                conn.Close();
            }
            return entity;
        }
        public Pet Read(int id)
        {
            Pet pet = null;
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                IDataReader reader = conn.ExecuteReader("Select * FROM Pet as p LEFT JOINE Owner as o ON p.pet_previous_owner_id = o.owner_id WHERE p.pet_id = {0}", id);
                
                while (reader.Read())
                {
                    pet = new Pet();
                    pet.Id = reader.GetInt64(1);
                    pet.Name = reader.GetString(2);
                    pet.PType = (PetType.PType)reader.GetInt32(3);
                    pet.BirthDate = reader.GetDateTime(4);
                    pet.SoldDate = reader.GetDateTime(5);
                    pet.Color = reader.GetString(7);
                    pet.Price = reader.GetDouble(8);
                    if (reader[9].GetType() != typeof(DBNull))
                    {
                        pet.PriviousOwner.Id = reader.GetInt64(9);
                        pet.PriviousOwner.FirstName = reader.GetString(10);
                        pet.PriviousOwner.LastName = reader.GetString(11);
                        pet.PriviousOwner.Address = reader.GetString(12);
                        pet.PriviousOwner.Email = reader.GetString(13);
                        pet.PriviousOwner.PhoneNumber = reader.GetString(14);
                    }
                }
                conn.Close();
            }
            return pet;
        }
        public IEnumerable<Pet> ReadAll()
        {
            List<Pet> pets = new List<Pet>();
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                IDataReader reader = conn.ExecuteReader("Select * FROM Pet as p LEFT JOINE Owner as o on p.pet_previous_owner_id = o.owner_id");
                while (reader.Read())
                {
                    Pet pet = new Pet();
                    pet.Id = reader.GetInt64(1);
                    pet.Name = reader.GetString(2);
                    pet.PType = (PetType.PType)reader.GetInt32(3);
                    pet.BirthDate = reader.GetDateTime(4);
                    pet.SoldDate = reader.GetDateTime(5);
                    pet.Color = reader.GetString(7);
                    pet.Price = reader.GetDouble(8);
                    if (reader[9].GetType() != typeof(DBNull))
                    {
                        pet.PriviousOwner.Id = reader.GetInt64(9);
                        pet.PriviousOwner.FirstName = reader.GetString(10);
                        pet.PriviousOwner.LastName = reader.GetString(11);
                        pet.PriviousOwner.Address = reader.GetString(12);
                        pet.PriviousOwner.Email = reader.GetString(13);
                        pet.PriviousOwner.PhoneNumber = reader.GetString(14);
                    }
                    pets.Add(pet);
                }
                conn.Close();
            }
            return pets;
        }
        public Pet Update(Pet entity)
        {
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                conn.Execute("UPDATE Pet " +
                    "SET pet_name = @Name, pet_type = "+ (int)entity.PType.Value +" , pet_birthdate = @BirthDate, pet_sold_date = @SoldDate, " +
                    "pet_previous_owner_id = " + (entity.PriviousOwner == null ? "NULL" : "" + entity.PriviousOwner.Id) + ", pet_color = @Color, " +
                    "pet_price = @Price WHERE pet_id = @Id", entity);

                conn.Close();
            }
            return entity;
        }
        public Pet Delete(Pet entity)
        {
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                conn.Execute("DELETE FROM Pet WHERE pet_id = @Id", entity);
                conn.Close();
            }
            return entity;
        }

    }
}
