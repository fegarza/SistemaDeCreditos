using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Clases
{
    public class Estudiante
    {
        //Atributos
        List<ActividadComplementaria> ActividadesComplementarias = new List<ActividadComplementaria>();
        private string _strNumeroDeControl;
        private string _strNombre;
        private string _strCarrera;

        //Propiedades
        public string NumeroDeControl
        {
            get { return _strNumeroDeControl; }
            set { _strNumeroDeControl = value; }
        }
        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        public string Carrera
        {
            get { return _strCarrera; }
            set { _strCarrera = value; }
        }




        //Constructor
        public Estudiante(string _nombre, string _noControl)
        {
            Nombre = _nombre;
            NumeroDeControl = _noControl;
        }



        //Metodos
        public void InsertarActividad(ActividadComplementaria _actividadComplementaria)
        {
            ActividadesComplementarias.Add(_actividadComplementaria);
        }

    }



    public class ActividadComplementaria
    {
        //Atributos
        private string _stringDepartamento;
        private string _strTitulo;
        private int _intPeso;
        private string _strResponsable;
        private char _chrEstadoDeLaActividad;
        private DateTime _dtFechaDeOficio;
        private string _strSeccion;
        private int _intPeriodo;
        private string _strJefe;
        private int _intPregunta1;
        private int _intPregunta2;
        private int _intPregunta3;
        private int _intPregunta4;
        private int _intPregunta5;
        private int _intPregunta6;
        private int _intPregunta7;
        private double _dblPromedio;

        //Constructor
        public ActividadComplementaria(string _titulo, string _seccion, string _departamento,int _peso,string _jefe ,string _responsable,char _estado,DateTime _fechaDeOficio,int _periodo,int _pregunta1, int _pregunta2, int _pregunta3, int _pregunta4, int _pregunta5, int _pregunta6, int _pregunta7, double _promedio)
        {
            Titulo = _titulo;
            Seccion = _seccion;
            Departamento = _departamento;
            Peso = _peso;
            Jefe = _jefe;
            Responsable = _responsable;
            EstadoDeLaActividad = _estado;
            FechaDeOficio = _fechaDeOficio;
            Periodo = _periodo;
            Pregunta1 = _pregunta1;
            Pregunta2 = _pregunta2;
            Pregunta3 = _pregunta3;
            Pregunta4 = _pregunta4;
            Pregunta5 = _pregunta5;
            Pregunta6 = _pregunta6;
            Pregunta7 = _pregunta7;
            Promedio = _promedio;
        }


        //Propiedades
        public string Departamento
        {
            get { return _stringDepartamento; }
            set { _stringDepartamento = value; }
        }
        public string Titulo
        {
            get { return _strTitulo; }
            set { _strTitulo = value; }
        }
        public int Peso
        {
            get { return _intPeso; }
            set { _intPeso = value; }
        }
        public string Responsable
        {
            get { return _strResponsable; }
            set { _strResponsable = value; }
        }
        public char EstadoDeLaActividad
        {
            get { return _chrEstadoDeLaActividad; }
            set { _chrEstadoDeLaActividad = value; }
        }
        public DateTime FechaDeOficio
        {
            get { return _dtFechaDeOficio; }
            set { _dtFechaDeOficio = value; }
        }
        public string Seccion
        {
            get { return _strSeccion; }
            set { _strSeccion = value; }
        }
        public int Periodo
        {
            get { return _intPeriodo; }
            set { _intPeriodo = value; }
        }
        public string Jefe
        {
            get { return _strJefe; }
            set { _strJefe = value; }
        }
        public int Pregunta1
        {
            get { return _intPregunta1; }
            set { _intPregunta1 = value; }
        }
        public int Pregunta2
        {
            get { return _intPregunta2; }
            set { _intPregunta2 = value; }
        }
        public int Pregunta3
        {
            get { return _intPregunta3; }
            set { _intPregunta3 = value; }
        }
        public int Pregunta4
        {
            get { return _intPregunta4; }
            set { _intPregunta4 = value; }
        }
        public int Pregunta5
        {
            get { return _intPregunta5; }
            set { _intPregunta5 = value; }
        }
        public int Pregunta6
        {
            get { return _intPregunta6; }
            set { _intPregunta6 = value; }
        }

        public int Pregunta7
        {
            get { return _intPregunta7; }
            set { _intPregunta7 = value; }
        }
        public double Promedio
        {
            get { return _dblPromedio; }
            set { _dblPromedio = value; }
        }


        


    }
}
