using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPets.Models
{
    public class PetsModel
    {
        public Guid IdPet { get; set; }
        public string PetAge { get; set; }
        public string PetImage { get; set; }
        public string PetName { get; set; }
        public string PetRaze { get; set; }
        public string PetSize { get; set; }
        public DispenserModel Dispenser { get; set; }
    }
}
