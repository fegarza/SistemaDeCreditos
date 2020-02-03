using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCreditos.Clases
{
    public class Usuario
    {
        //Atributos

        public int DepartamentoID;



        public string DepartamentoNombre;



        //Propiedades
        public string Genero;
        public string Rol;
        public string Apellidos;
        public string Nombre;
        public string Clave;
        public int ID;
        public int PersonalClave;

        //Constructor
        public Usuario(string _nombre, string _clave, int _usuarioID, string _rol, int _personalClave, string _apellido, string _genero, int _departamentoID)
        {
            Genero = _genero;
            Nombre = _nombre;
            Clave = _clave;
            ID = _usuarioID;
            Rol = _rol;
            PersonalClave = _personalClave;
            Apellidos = _apellido;
            DepartamentoID = _departamentoID;
        }

    }
}
