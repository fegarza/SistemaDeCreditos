using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCreditos.Clases
{
    public class Departamento
    {

        public int ID;
        public string Nombre;

        public Departamento(string _nombre, int _id)
        {
            Nombre = _nombre;
            ID = _id;
        }


    }
}
