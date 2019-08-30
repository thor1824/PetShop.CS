using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.Entity
{
    

    
    public class Pet
    {
        private int id;
        private string name;
        private PetType.PType type;
        private DateTime birthDate;
        private DateTime soldDate;
        private string color;
        private string priviousOwner;
        private double price;

        public Pet()
        {

        }

        public Pet(int id, string name, PetType.PType type, DateTime birthDate, DateTime soldDate, string color, string priviousOwner, double price)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.birthDate = birthDate;
            this.soldDate = soldDate;
            this.color = color;
            this.priviousOwner = priviousOwner;
            this.price = price;
            
        }

        public string getFormatteDate(DateTime dateTime)
        {
            return dateTime.Day + "/" + dateTime.Month + "/" + dateTime.Year;
        }

        public override string ToString()
        {
            return "[ID: " + id +", Name: " + name + ", Type: " + type.ToString() 
                + ", Color: " + color + ", Price: " + price + ", Privious Owner: " + priviousOwner 
                + ", Birthday: " + getFormatteDate(birthDate) + ", Date of Sale: " + (soldDate == null ? "N/A" : getFormatteDate(soldDate)) + "]";
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public PetType.PType Type { get => type; set => type = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public DateTime SoldDate { get => soldDate; set => soldDate = value; }
        public double Price { get => price; set => price = value; }
        public string PriviousOwner { get => priviousOwner; set => priviousOwner = value; }
        public string Color { get => color; set => color = value; }

    }
}
