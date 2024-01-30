using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniproyectoSec_CARS.Conexion
{
    public class Cconexion
    {
        //tengo que poner otra base de datos

        public static FirebaseClient firebase = new FirebaseClient("https://miniproyectoejercicios-default-rtdb.firebaseio.com/");
    }
}
