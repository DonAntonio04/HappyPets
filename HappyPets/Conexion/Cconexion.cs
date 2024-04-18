using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPets.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://happydogsdb-default-rtdb.firebaseio.com/");
    }
}
