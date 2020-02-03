using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using Nucleo.Clases;

//   CONEXION LOCAL CON VISUAL FOX PRO DB = "";


namespace Nucleo.Conexiones
{
    public class Conexion
    {
        //variable que se utilizara 
        public List<Estudiante> estudiantesResultado = new List<Estudiante>();
        
        
        #region SQL SERVER

        //atributos
        private string _strServer;
        private string _strBD;
        private string _strUsuario;
        private string _strClave;
        //propiedades
        public string Server
        {
            get { return _strServer; }
            set { _strServer = value; }
        }
        public string BD
        {
            get { return _strBD; }
            set { _strBD = value; }
        }
        public string Usuario
        {
            get { return _strUsuario; }
            set { _strUsuario = value; }
        }
        public string Clave
        {
            get { return _strClave; }
            set { _strClave = value; }
        }
        //Variables a utilizar dentro de las consultar de sql server
        SqlConnection conexion;
        SqlCommand comando = new SqlCommand();
        SqlDataReader reader;

        #endregion
        #region VISUAL FOX PRO DB

        //atributos
        private static string _strRutaFx;
        //propiedades
        public static string RutaFx
        {
            get { return _strRutaFx; }
            set { _strRutaFx = value; }
        }
        //variables de conexion a visual fox pro db
        OleDbConnection fxConexionAlumnos;
        OleDbConnection fxConexionAlumnosExtendido;
        OleDbConnection fxConexionAlumnosPuesto;
        OleDbCommand fxComando = new OleDbCommand();
       // OleDbDataReader fxReader;


        #endregion


        

        //Constructor con valores x default
        public Conexion() {
            Server = "PIPE";
            BD = "SistemaDeCreditos";
            Usuario = "admin";
            Clave = "7271";
            RutaFx = "Provider = VFPOLEDB.1; Data Source = C:\\Users\\fegar\\Downloads\\db\\";
        }
        //Constuctor de la conexion
        public Conexion(string _sv, string _bd, string _usuario, string _clave, string _rutaFX)
        {
            //Se le asigna valor a aquellas variables que se utilizaran para la conexion
            Server = _sv;
            BD = _bd;
            Usuario = _usuario;
            Clave = _clave;
            RutaFx = _rutaFX;
        }
        
        
        //Iniciar la conexion
        public string TestearConexiones()
        {
            //Variable que me concatenara cada uno de los errores que se presente durante la prueba de conexion
            string estatusConexion = "";


            #region PRUEBA EN SQLSERVER
            try
            {
                conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
                conexion.Open();
                conexion.Close();
            }
            catch (Exception)
            {
                estatusConexion = "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db";
            }
            #endregion
            #region PRUEBA EN FOX PRO
            try
            {
                fxConexionAlumnos = new OleDbConnection(RutaFx+ "dalumn.dbf;");
                fxConexionAlumnos.Open();
                fxConexionAlumnos.Close();
            }
            catch (Exception)
            {
                estatusConexion = estatusConexion + "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db en la tabla dalumn";
            }
            try
            {
                fxConexionAlumnosExtendido = new OleDbConnection(RutaFx + "dcalumn.dbf;");
                fxConexionAlumnosExtendido.Open();
                fxConexionAlumnosExtendido.Close();
            }
            catch (Exception)
            {
                estatusConexion = estatusConexion + "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db en la tabla dcalumn";
            }
            try
            {
                fxConexionAlumnosPuesto = new OleDbConnection(RutaFx + "dpuest.dbf;");
                fxConexionAlumnosPuesto.Open();
                fxConexionAlumnosPuesto.Close();
            }
            catch (Exception)
            {
                estatusConexion = estatusConexion + "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db en la tabla dpuest";
            }
            #endregion

            //Se retorna los posibles errores
            return estatusConexion;
        }
        
        //Terminar la conexion
        public void CerrarConexion()
        {
            conexion.Close();
        }


        
        //CONSULTAS
        public  List<Estudiante> BuscarEstudiante(string _tipo, string _datos)
        {
            estudiantesResultado.Clear();
            switch (_tipo)
            {
                case "numeroDeControl":
                    try
                    {
                                
                    }
                    catch
                    {
                        //MessageBox.Show("Error al quere consultar el usuario por medio del numero de control");
                    }
                    break;

            }
            return estudiantesResultado;
        }






    }
}
