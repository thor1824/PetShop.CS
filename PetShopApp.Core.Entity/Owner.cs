using System.Collections.Generic;

namespace PetShopApp.Core.Entity
{
    public class Owner
    {
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
