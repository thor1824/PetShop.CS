using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entity
{
    

    
    public class Pet
    {
        

        public Pet()
        {

        }

        public Pet(int id, string name, PetType.PType type, DateTime birthDate, DateTime soldDate, string color, Owner priviousOwner, double price)
        {
            this.Id = id;
            this.Name = name;
            this.PType = type;
            this.BirthDate = birthDate;
            this.SoldDate = soldDate;
            this.Color = color;
            this.PriviousOwner = priviousOwner;
            this.Price = price;
            
        }

        public string getFormatteDate(DateTime dateTime)
        {
            return dateTime.Day + "/" + dateTime.Month + "/" + dateTime.Year;
        }

        public override string ToString()
        {
            return "[ID: " + Id +
                ", Name: " + Name + 
                ", Type: " + (PType == null ? "N/A": PType.ToString()) + 
                ", Color: " + Color + 
                ", Price: " + (Price == null ? "N/A" : Price.ToString()) + 
                ", Privious Owner: " + (PriviousOwner == null ? "N/A" : PriviousOwner.FirstName + " " + PriviousOwner.LastName) + 
                ", Birthday: " + (BirthDate.Value == null ? "N/A" : getFormatteDate(BirthDate.Value)) + 
                ", Date of Sale: " + (SoldDate == null ? "N/A" : getFormatteDate(SoldDate.Value)) + "]";
        }

        public bool HasId { get { return Id.HasValue; } }
        public int? Id { get; set;}
        public string Name { get; set; }
        public PetType.PType? PType { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? SoldDate { get; set; }
        public double? Price { get; set; }
        public Owner PriviousOwner { get; set; }
        public string Color { get; set; }

    }
}
