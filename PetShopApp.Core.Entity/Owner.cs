using System.Collections.Generic;

namespace PetShopApp.Core.Entity
{
    public class Owner
    {


        public Owner(long id, string firstName, string lastName, string address, string phoneNumber, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        public Owner()
        {
        }

        public override string ToString()
        {
            return "[ID: " + Id + ", Name: " + FirstName + " " + LastName + ", Address: " + Address + ", Phone: " + PhoneNumber + ", Email: " + Email + "]";
        }

        public bool HasId { get { return Id.HasValue; } }
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<PetOwner> PreviousOwnedPets { get; set; }
    }
}
