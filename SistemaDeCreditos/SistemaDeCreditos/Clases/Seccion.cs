using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCreditos.Clases
{
    public class Seccion
    {

        public string Nombre;
        public int ID;
        public int Peso;

        //Constructor
        public Seccion(string _nombre, int _id, int _Peso)
        {
            ID = _id;
            Nombre = _nombre;
            Peso = _Peso;
        }
    }
}
