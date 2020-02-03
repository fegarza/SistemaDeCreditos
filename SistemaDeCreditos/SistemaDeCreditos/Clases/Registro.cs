using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCreditos.Clases
{
    public class Registro
    {
        public int UserID;
        public int ID;
        public string Contenido;
        public string Fecha;

        public Registro(int _id, int _userID, string _contenido, string _fecha)
        {
            UserID = _userID;
            ID = _id;
            Contenido = _contenido;
            Fecha = _fecha;
        }
    }
}
