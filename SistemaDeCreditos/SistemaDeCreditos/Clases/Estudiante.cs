using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SistemaDeCreditos.Clases
{
    public class Estudiante
    {
        //Atributos
        List<ActividadComplementaria> ActividadesComplementarias = new List<ActividadComplementaria>();
        private string _strNumeroDeControl;
        private string _strNombre;
        private string _strCarrera;
        private string _strApellidoPaterno;
        private string _strApellidoMaterno;
        private int _intCarreraID;
        private int _intCreditosPendientes;
        private int _intCreditosTerminados;


        //Propiedades
        public int CreditosTerminados
        {
            get { return _intCreditosTerminados; }
            set { _intCreditosTerminados = value; }
        }
        public int CreditosPendientes
        {
            get { return _intCreditosPendientes; }
            set { _intCreditosPendientes = value; }
        }
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
        public string ApellidoPaterno
        {
            get { return _strApellidoPaterno; }
            set { _strApellidoPaterno = value; }
        }
        public string ApellidoMaterno
        {
            get { return _strApellidoMaterno; }
            set { _strApellidoMaterno = value; }
        }
        public int CarreraID
        {
            get { return _intCarreraID; }
            set { _intCarreraID = value; }
        }


        //Constructor
        public Estudiante(string _noControl, string _nombre, string _apellidoM, string _apellidoP)
        {
            NumeroDeControl = _noControl;
            ApellidoMaterno = _apellidoM;
            ApellidoPaterno = _apellidoP;
            Nombre = _nombre;
        }
        public Estudiante(string _noControl, int _carreraID, int _creditosT, int _creditosP)
        {
            CreditosTerminados = _creditosT;
            CreditosPendientes = _creditosP;
            NumeroDeControl = _noControl;
            CarreraID = _carreraID;
        }

        //Constructor que se usa en los grupos 
        public Estudiante(string _nombre,string _apellidoPaterno, string _apellidoMaterno, string _noControl, int _carreraID, int _creditosT, int _creditosP)
        {
            CreditosTerminados = _creditosT;
            CreditosPendientes = _creditosP;
            NumeroDeControl = _noControl;
            CarreraID = _carreraID;
            Nombre = _nombre;
            ApellidoMaterno = _apellidoMaterno;
            ApellidoPaterno = _apellidoPaterno;
        }
    }
    public class ActividadComplementaria
    {
        //Atributos
        private string _stringDepartamento;
        private string _strActividadTitulo;
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
        private int _intActividadID;
        private int _intJefeID;
        private int _intResponsableID;
        private int _intDepartamentoID;
        private int _intCreditoID;
        private char _charEstadoDeLaFirma;

        //Propiedades
        public char EstadoDeLaFirma
        {
            get { return _charEstadoDeLaFirma; }
            set { _charEstadoDeLaFirma = value; }
        }
        public string Departamento
        {
            get { return _stringDepartamento; }
            set { _stringDepartamento = value; }
        }
        public string ActividadTitulo
        {
            get { return _strActividadTitulo; }
            set { _strActividadTitulo = value; }
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
        public int ActividadID
        {
            get { return _intActividadID; }
            set { _intActividadID = value; }
        }
        public int JefeID
        {
            get { return _intJefeID; }
            set { _intJefeID = value; }
        }
        public int ResponsableID
        {
            get { return _intResponsableID; }
            set { _intResponsableID = value; }
        }
        public int DepertamentoID
        {
            get { return _intDepartamentoID; }
            set { _intDepartamentoID = value; }
        }
        public int CreditoID
        {
            get { return _intCreditoID; }
            set { _intCreditoID = value; }
        }

        //Constructor
        public ActividadComplementaria
            (
           int _peso,
            int _creditoID,
            string _nombreActividad,
            int _actividadID,
            int _jefeID,
            string _jefe,
            int _responsableID,
            string _responsable,
            char _estado,
            DateTime _fechaDeOficio,
            int _periodo,
            int _pregunta1,
            int _pregunta2,
            int _pregunta3,
            int _pregunta4,
            int _pregunta5,
            int _pregunta6,
            int _pregunta7,
            double _promedio,
            char _charEstadoDeLaFirma,
            string _seccion)
        {
            Peso = _peso;
            Jefe = _jefe;
            Responsable = _responsable;
            CreditoID = _creditoID;
            ActividadTitulo = _nombreActividad;
            ActividadID = _actividadID;
            JefeID = _jefeID;
            ResponsableID = _responsableID;
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
            EstadoDeLaFirma = _charEstadoDeLaFirma;
            Seccion = _seccion;
        }



    }
    public class Usuario
    {
        //Atributos
        private string _strGenero;
        private string _strRol;
        private string _strNombre;
        private string _strClave;
        private int _intUsuarioID;
        private string _strApellidos;
        private int _intPersonalClave;
        private string _strDepartamentoNombre;
        private int _intDepartamentoID;

        public int DepartamentoID
        {
            get { return _intDepartamentoID; }
            set { _intDepartamentoID = value; }
        }



        public string DepartamentoNombre
        {
            get { return _strDepartamentoNombre; }
            set { _strDepartamentoNombre = value; }
        }




        //Propiedades
        public string Genero
        {
            get { return _strGenero; }
            set { _strGenero = value; }
        }
        public string Rol
        {
            get { return _strRol; }
            set { _strRol = value; }
        }
        public string Apellidos
        {
            get { return _strApellidos; }
            set { _strApellidos = value; }
        }
        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        public string Clave
        {
            get { return _strClave; }
            set { _strClave = value; }
        }
        public int UsuarioID
        {
            get { return _intUsuarioID; }
            set { _intUsuarioID = value; }
        }
        public int PersonalClave
        {
            get { return _intPersonalClave; }
            set { _intPersonalClave = value; }
        }
        
        //Constructor
        public Usuario(string _nombre, string _clave, int _usuarioID, string _rol, int _personalClave, string _apellido, string _genero, int _departamentoID)
        {
            Genero = _genero;
            Nombre = _nombre;
            Clave = _clave;
            UsuarioID = _usuarioID;
            Rol = _rol;
            PersonalClave = _personalClave;
            Apellidos = _apellido;
            DepartamentoID = _departamentoID;
        }

    }
    public class Personal
    {
        //Atributos
        private string _strNombre;
        private int _intClave;
        private string _strApellidos;
        private int _intNivel;



        //Propiedades
        private string _strPersig;

        public string Persig
        {
            get { return _strPersig; }
            set { _strPersig = value; }
        }

        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        public int Clave
        {
            get { return _intClave; }
            set { _intClave = value; }
        }
        public string Apellidos
        {
            get { return _strApellidos; }
            set { _strApellidos = value; }
        }
        public int Nivel
        {
            get { return _intNivel; }
            set { _intNivel = value; }
        }
        
        //Constructor
        public Personal(string _nombre, string _apellidos, int _clave)
        {
            Nombre = _nombre;
            Apellidos = _apellidos;
            Clave = _clave;
        }

    }
    public class Seccion
    {
        //Atributos
        private string _strNombre;
        private int _intID;
        private int _intPeso;
     
        //Propiedades
        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        public int ID
        {
            get { return _intID; }
            set { _intID = value; }
        }
        public int Peso
        {
            get { return _intPeso; }
            set { _intPeso = value; }
        }

        //Constructor
        public Seccion(string _nombre, int _id, int _Peso)
        {
            ID = _id;
            Nombre = _nombre;
            Peso = _Peso;
        }
    }
    public class Actividad
    {
        //Atributos
        private int _intPeso;
        private string _strNombre;
        private int _intID;
        private string _strSeccionNombre;
        private int _intSeccionID;

        public int SeccionID
        {
            get { return _intSeccionID; }
            set { _intSeccionID = value; }
        }



        public string SeccionNombre
        {
            get { return _strSeccionNombre; }
            set { _strSeccionNombre = value; }
        }


        //Propiedades
        public int Peso
        {
            get { return _intPeso; }
            set { _intPeso = value; }
        }
        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        public int ID
        {
            get { return _intID; }
            set { _intID = value; }
        }

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
    public class Departamento
    {
        private int _intID;

        public int ID
        {
            get { return _intID; }
            set { _intID = value; }
        }

        private string _strNombre;

        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        public Departamento(string _nombre, int _id)
        {
            Nombre = _nombre;
            ID = _id;
        }


    }
    public class Registro
    {
        public Registro(int _id, int _userID,string _contenido, string _fecha)
        {
            UserID = _userID;
            ID = _id;
            Contenido = _contenido;
            Fecha = _fecha;
        }
        private int _intUserID;

        public int UserID
        {
            get { return _intUserID; }
            set { _intUserID = value; }
        }


        private int _intID;

        public int ID
        {
            get { return _intID; }
            set { _intID = value; }
        }

        private string _strContenido;

        public string Contenido
        {
            get { return _strContenido; }
            set { _strContenido = value; }
        }

        private string _strFecha;

        public string Fecha
        {
            get { return _strFecha; }
            set { _strFecha = value; }
        }



    }
    public class Grupo
    {

        public Grupo(int _id, string _titulo, int _cupo, int _responsableID, int _actividadID, int _conteo, string _periodo)
        {
            Titulo = _titulo;
            Cupo = _cupo;
            ResponsableID = _responsableID;
            ActividadID = _actividadID;
            Conteo = _conteo;
            ID = _id;
            Periodo = _periodo;
        }
        private string _stringPeriodo;

        public string Periodo
        {
            get { return _stringPeriodo; }
            set { _stringPeriodo = value; }
        }

        public int _intID;

        public int ID
        {
            get { return _intID; }
            set { _intID = value; }
        }

        private string _strTitulo;

        public string Titulo
        {
            get { return _strTitulo; }
            set { _strTitulo = value; }
        }

        private int _intCupo;

        public int Cupo
        {
            get { return _intCupo; }
            set { _intCupo = value; }
        }

        private int _intResponsableID;
                
        public int ResponsableID
        {
            get { return _intResponsableID; }
            set { _intResponsableID = value; }
        }
        private int _intActividadID;

        public int ActividadID
        {
            get { return _intActividadID; }
            set { _intActividadID = value; }
        }

        private int _intConteo;

        public int Conteo
        {
            get { return _intConteo; }
            set { _intConteo = value; }
        }

    }
    public class Reporte
    {
        public string Titulo;
        public DateTime Fecha;
        public string Carrera;
        public int ID;
        public List<Estudiante> Estudiantes = new List<Estudiante>();
        public Reporte(string _titulo, DateTime _fecha, string _carrera, int _id)
        {
            Titulo = _titulo;
            Fecha = _fecha;
            Carrera = _carrera;
            ID = _id;
        }
        
        public override string ToString()
        {
            return $" ({Fecha.ToString("dd/MM/yyyy")}) {Carrera.TrimEnd()} | {Titulo} ";
        }
    }
}
