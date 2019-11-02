namespace PetShopApp.Core.Entity
{
    public class PetOwner
    {
        public Pet Pet { get; set; }
        public long PetID { get; set; }
        public Owner Owner { get; set; }
        public long OwnerID { get; set; }
    }
}
