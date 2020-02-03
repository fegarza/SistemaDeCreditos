using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCreditos.Clases
{

    public class Grupo
    {
        public int ID;
        public string Titulo;
        public int Cupo;
        public int ResponsableID;
        public int ActividadID;
        public int Conteo;

        public Grupo(int _id, string _titulo, int _cupo, int _responsableID, int _actividadID, int _conteo)
        {
            Titulo = _titulo;
            Cupo = _cupo;
            ResponsableID = _responsableID;
            ActividadID = _actividadID;
            Conteo = _conteo;
            ID = _id;
        }

    }
}
