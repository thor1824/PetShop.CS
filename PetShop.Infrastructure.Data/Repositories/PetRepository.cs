using Dapper;
using PetShop.Infrastructure.Data.db.Connection;
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
    public class PetRepository : IRepository<Pet>
    {
        public Pet Create(Pet entity)
        {
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                conn.Open();
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
                conn.Open();
                IDataReader reader = conn.ExecuteReader("Select * FROM Pet as p LEFT JOIN Owner as o ON p.pet_previous_owner_id = o.owner_id WHERE p.pet_id = " + id);
                
                while (reader.Read())
                {
                    pet = new Pet();
                    pet.Id = reader.GetInt64(0);
                    pet.Name = reader.GetString(1);
                    pet.PType = (PetType.PType)Enum.ToObject(typeof(PetType.PType), reader.GetInt32(2));
                    pet.BirthDate = reader.GetDateTime(3);
                    if (reader[4].GetType() != typeof(DBNull))
                    {
                        pet.SoldDate = reader.GetDateTime(4);
                    }
                    pet.Color = reader.GetString(6);
                    pet.Price = reader.GetDouble(7);
                    if (reader[5].GetType() != typeof(DBNull))
                    {
                        pet.PriviousOwner = new Owner()
                        {
                            Id = reader.GetInt64(8),
                            FirstName = reader.GetString(9),
                            LastName = reader.GetString(10),
                            Address = reader.GetString(11),
                            Email = reader.GetString(12),
                            PhoneNumber = reader.GetString(13),

                        };
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
                conn.Open();
                IDataReader reader = conn.ExecuteReader("Select * FROM Pet as p LEFT JOIN Owner as o ON p.pet_previous_owner_id = o.owner_id");
                while (reader.Read())
                {

                    Pet pet = new Pet();
                    pet.Id = reader.GetInt64(0);
                    pet.Name = reader.GetString(1);
                    pet.PType = (PetType.PType) Enum.ToObject(typeof(PetType.PType), reader.GetInt32(2));
                    pet.BirthDate = reader.GetDateTime(3);
                    if (reader[4].GetType() != typeof(DBNull))
                    {
                        pet.SoldDate = reader.GetDateTime(4);
                    }
                    pet.Color = reader.GetString(6);
                    pet.Price = reader.GetDouble(7);
                    if (reader[5].GetType() != typeof(DBNull))
                    {
                        pet.PriviousOwner = new Owner()
                        {
                            Id = reader.GetInt64(8),
                            FirstName = reader.GetString(9),
                            LastName = reader.GetString(10),
                            Address = reader.GetString(11),
                            Email = reader.GetString(12),
                            PhoneNumber = reader.GetString(13),

                        };

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
                conn.Open();
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
                conn.Open();
                conn.Execute("DELETE FROM Pet WHERE pet_id = @Id", entity);
                conn.Close();
            }
            return entity;
        }

    }
}
