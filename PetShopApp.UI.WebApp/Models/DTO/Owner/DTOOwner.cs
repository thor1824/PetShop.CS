namespace PetShopApp.UI.WebApp.DTO
{
    public class DTOOwner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int[] PreviousOwnedPets { get; set; }
    }
}
