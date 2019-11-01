using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopApp.Core.Entity
{
    public class User
    {
        public long id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
       // public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
    }
}
