using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCreditos.Clases
{
    public class Personal
    {
        public string Nombre;
        public int Clave;
        public string Apellidos;

        public Personal(string _nombre, string _apellidos, int _clave)
        {
            Nombre = _nombre;
            Apellidos = _apellidos;
            Clave = _clave;
        }

    }
}
