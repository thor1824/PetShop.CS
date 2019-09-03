using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entity
{
    public class Owner
    {
        private int? id;
        private string firstName;
        private string lastName;
        private string address;
        private string phoneNumber;
        private string email;

        public Owner(int id, string firstName, string lastName, string address, string phoneNumber, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public Owner()
        {
        }

        public override string ToString()
        {
            return "[ID: "+ id +", Name: "+ firstName + " " + lastName +", Address: "+address+", Phone: " + phoneNumber+", Email: "+ Email + "]";
        }

        public bool HasId { get { return id.HasValue; } }
        public int? Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
