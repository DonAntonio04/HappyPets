using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPets.Models
{
    public class UsersModel
    {
        public Guid IdUser { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImage { get; set; }
   
    }
}
