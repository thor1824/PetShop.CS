using Dapper;
using PetShop.Infrastructure.Data.Sqlite;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    class OwnerDbRepository : IRepository<Owner>
    {
        public Owner Create(Owner entity)
        {
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                conn.Execute("INSERT INTO Owner " +
                    "(owner_first_name, owner_last_name, owner_address, owner_email, owner_phone_no) " +
               "VALUES (@FirstName, @LastName, @Address, @Email, @PhoneNumber)", entity);

                entity.Id = conn.LastInsertRowId;
                conn.Close();
            }
            return entity;
        }

        public Owner Read(int id)
        {
            Owner owner = null;
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                IDataReader reader = conn.ExecuteReader("Select * FROM Owner WHERE owner_id = {0}", id);

                while (reader.Read())
                {
                    owner.Id = reader.GetInt64(1);
                    owner.FirstName = reader.GetString(2);
                    owner.LastName = reader.GetString(3);
                    owner.Address = reader.GetString(4);
                    owner.Email = reader.GetString(5);
                    owner.PhoneNumber = reader.GetString(6);
                }
                conn.Close();
            }
            return owner;
        }

        public IEnumerable<Owner> ReadAll()
        {
            List<Owner> owners = new List<Owner>();
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                IDataReader reader = conn.ExecuteReader("Select * FROM Owner");
                while (reader.Read())
                {
                    Owner owner = new Owner();
                    owner.Id = reader.GetInt64(1);
                    owner.FirstName = reader.GetString(2);
                    owner.LastName = reader.GetString(3);
                    owner.Address = reader.GetString(4);
                    owner.Email = reader.GetString(5);
                    owner.PhoneNumber = reader.GetString(6);
                    owners.Add(owner);
                }
                conn.Close();
            }
            return owners;
        }

        public Owner Update(Owner entity)
        {
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                conn.Execute("UPDATE Owner SET " +
                    "owner_first_name = @FirstName, " +
                    "owner_last_name = @LastName, " + 
                    "owner_address = @Address, " +
                    "owner_email = @Email, " +
                    "owner_phone_no = @PhoneNumber" + 
                    "WHERE pet_id = @Id", entity);
                conn.Close();
            }
            return entity;
        }

        public Owner Delete(Owner entity)
        {
            using (SQLiteConnection conn = ConnectionCreater.CreateConnection())
            {
                conn.Execute("DELETE FROM Owner WHERE owner_id = @Id", entity);
                conn.Close();
            }
            return entity;
        }
    }
}
