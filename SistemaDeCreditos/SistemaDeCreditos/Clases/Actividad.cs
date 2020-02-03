using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCreditos.Clases
{
    public class Actividad
    {

        public int SeccionID;
        public string SeccionNombre;
        public int Peso;
        public string Nombre;
        public int ID;

        //Constructor
        public Actividad(string _nombre, int _id, int _peso, int _seccionID, string _seccionNombre)
        {
            Peso = _peso;
            ID = _id;
            Nombre = _nombre;
            SeccionID = _seccionID;
            SeccionNombre = _seccionNombre;
        }
    }
}
