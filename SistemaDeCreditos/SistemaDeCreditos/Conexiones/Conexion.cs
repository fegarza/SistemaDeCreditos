using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using SistemaDeCreditos.Clases;
using System.Windows.Forms;



namespace SistemaDeCreditos.Conexiones
{


    public class Conexion
    {
        #region ATRIBUTOS Y PROPIEDADES

        #region SQL SERVER
        private string _strServer;
        private string _strBD;
        private string _strUsuario;
        private string _strClave;

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
        #endregion

        #region VISUAL FOX PRO DB

        private string _strSemiRuta;
        private string _strRutaFx;

        public string SemiRuta
        {
            get { return _strSemiRuta; }
            set { _strSemiRuta = value; }
        }

        public string RutaFx
        {
            get { return _strRutaFx; }
            set { _strRutaFx = value; }
        }

        #endregion

        #endregion

        public Conexion(string _sv, string _bd, string _usuario, string _clave, string _rutaFX)
        {
            Server = _sv;
            BD = _bd;
            Usuario = _usuario;
            Clave = _clave;
            RutaFx = @"Provider = VFPOLEDB.1; Data Source = " + _rutaFX;
            SemiRuta = _rutaFX;
        }
        /// <summary>
        ///  Calcula el semestre de un alumno por medio del numero de control
        /// </summary>
        /// <param name="_numeroDeControl">Numero de control del estudiante</param>
        /// <returns>Regresa el semestre (numero del 1 al 9)</returns>
        public int CalcularSemestre(string _numeroDeControl)
        {
            _numeroDeControl = _numeroDeControl.TrimEnd();
            int semestre = 0;
            if (_numeroDeControl.Length == 8)
            {
                //Obtenemos el año actual
                string añoStr = DateTime.Now.Year.ToString();
                //Obtenemos los ultimos dos digitos
                añoStr = añoStr[2].ToString() + añoStr[3].ToString();
                //Se convierte a entero
                int año = int.Parse(añoStr);
                //Se obtiene el mes en forma de entero
                int mes = DateTime.Now.Month;

                //Obtener los 2 primeros digitos del numero de control
                string fechaEntrada = _numeroDeControl[0].ToString() + _numeroDeControl[1].ToString();
                //ENTRA EN EL CASO DE QUE SEA DE PRIMERO
                if (int.Parse(fechaEntrada) == año)
                {
                    if (mes < 7)
                    {
                        semestre = 0;
                    }
                    //SEGUNDO
                    else
                    {
                        semestre = 1;
                    }
                }
                //ENTRA EN CASO DE QUE SEA DE SEGUNDO O TERCERO
                else if (int.Parse(fechaEntrada) == año - 1)
                {
                    //TERCERO
                    if (mes < 7)
                    {
                        semestre = 2;
                    }
                    //CUARTO
                    else
                    {
                        semestre = 3;
                    }
                }
                //ENTRA EN CASO DE QUE SEA DE CUARTO O QUINTO
                else if (int.Parse(fechaEntrada) == año - 2)
                {
                    //QUINTO
                    if (mes < 7)
                    {
                        semestre = 4;
                    }
                    //SEXTO
                    else
                    {
                        semestre = 5;
                    }
                }
                //ENTRA EN CASO DE QUE SEA DE SEXTO O SEPTIMO
                else if (int.Parse(fechaEntrada) == año - 3)
                {
                    //SEPTIMO
                    if (mes < 7)
                    {
                        semestre = 6;
                    }
                    //OCRAVO
                    else
                    {
                        semestre = 7;
                    }
                }
                //ENTRA EN CASO DE QUE SEA DE OCTAVO Y NOVENO
                else if (int.Parse(fechaEntrada) == año - 4)
                {
                    //NOVENO
                    if (mes < 7)
                    {
                        semestre = 8;
                    }
                    //DECIMO
                    else
                    {
                        semestre = 9;
                    }
                }
                else
                {
                    semestre = 9;
                }

            }
            return semestre;
        }

        #region TESTS DE CONEXION
        public string TestearConexiones()
        {
            //Variable que me concatenara cada uno de los errores que se presente durante la prueba de conexion
            string estatusConexion = "";

            #region PRUEBA EN SQLSERVER
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
                conexion.Open();
                conexion.Close();
            }
            catch (Exception)
            {
                estatusConexion = "\n -> No se logro hacer una conexion a la base de datos en SQL SERVER";
            }
            #endregion

            #region PRUEBA EN FOX PRO

            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            try
            {
                fxConexion = new OleDbConnection(RutaFx + "dalumn.dbf;");
                fxConexion.Open();
                fxConexion.Close();
            }
            catch (Exception)
            {
                estatusConexion = estatusConexion + "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db en la tabla dalumn";
            }
            try
            {
                fxConexion = new OleDbConnection(RutaFx + "dcalum.dbf;");
                fxConexion.Open();
                fxConexion.Close();
            }
            catch (Exception)
            {
                estatusConexion = estatusConexion + "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db en la tabla dcalumn";
            }
            try
            {
                fxConexion = new OleDbConnection(RutaFx + "dpuest.dbf;");
                fxConexion.Open();
                fxConexion.Close();
            }
            catch (Exception)
            {
                estatusConexion = estatusConexion + "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db en la tabla dpuest";
            }
            try
            {
                fxConexion = new OleDbConnection(RutaFx + "ddepto.dbf;");
                fxConexion.Open();
                fxConexion.Close();
            }
            catch (Exception)
            {
                estatusConexion = estatusConexion + "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db en la tabla ddepto";
            }
            try
            {
                fxConexion = new OleDbConnection(RutaFx + "dperso.dbf;");
                fxConexion.Open();
                fxConexion.Close();
            }
            catch (Exception)
            {
                estatusConexion = estatusConexion + "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db en la tabla dperso";
            }
            try
            {
                fxConexion = new OleDbConnection(RutaFx + "dcarre.dbf;");
                fxConexion.Open();
                fxConexion.Close();
            }
            catch (Exception)
            {
                estatusConexion = estatusConexion + "\n -> No se logro hacer una conexion a la base de datos en visual fox pro db en la tabla dcarre";
            }
            #endregion
            if (string.IsNullOrEmpty(estatusConexion))
            {
                estatusConexion = "No se encuentra ningun error";
            }
            //Se retorna los posibles errores
            return estatusConexion;
        }
        #endregion



        #region ---> CONSULTAS <---

        #region CONSULTAS EN DBF

        #region DQL
        public List<Estudiante> BuscarEstudiante(string _tipo, string _dato, int _semestre, Boolean _creditosTerminados, Boolean _creditosPendientes, Boolean _sinCreditos)
        {
            List<Estudiante> estudiantesResultado = new List<Estudiante>();
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            switch (_tipo)
            {
                case "numeroDeControl":
                    #region BUSCAR SI ESTA DISPONIBLE O SI EXISTE TAL ESTUDIANTE BUSCADO
                    //1 Abrir conexion
                    fxConexion = new OleDbConnection(RutaFx + "dcalum.dbf;");
                    fxConexion.Open();
                    //2 Asignar el query
                    fxComando = new OleDbCommand("SELECT * FROM dcalum WHERE dcalum.ALUCTR LIKE '" + _dato + "%'" + " AND dcalum.CALSIT = '1'", fxConexion);
                    //3 Ejecutar el query
                    fxReader = fxComando.ExecuteReader();

                    if (fxReader.HasRows)
                    {
                        while (fxReader.Read())
                        {
                            estudiantesResultado.Add(new Estudiante(fxReader["ALUCTR"].ToString(), int.Parse(fxReader["CARCVE"].ToString()), ConsultarCreditosTerminados(fxReader["ALUCTR"].ToString()), ConsultarCreditosPendientes(fxReader["ALUCTR"].ToString())));
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontrarón resultados para el siguiente número de control: " + _dato);
                    }
                    fxConexion.Close();
                    #endregion
                    #region TRAER TODOS LOS DATOS DEL ALUMNO DE MANERA COMPLETA
                    foreach (Estudiante n in estudiantesResultado)
                    {
                        //1 Abrir conexion
                        fxConexion = new OleDbConnection(RutaFx + "dalumn.dbf;");
                        fxConexion.Open();
                        //2 Asignar valor a comando
                        fxComando = new OleDbCommand("SELECT * FROM dalumn WHERE dalumn.ALUCTR = '" + n.NumeroDeControl + "'", fxConexion);
                        //3 ejecutar reader
                        fxReader = fxComando.ExecuteReader();
                        if (fxReader.HasRows)
                        {
                            while (fxReader.Read())
                            {
                                n.Nombre = fxReader["ALUNOM"].ToString();
                                n.ApellidoMaterno = fxReader["ALUAPM"].ToString();
                                n.ApellidoPaterno = fxReader["ALUAPP"].ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR NO HAY RELACION ENTRE LA TABLA ALUMN Y DCALUMN CON TAL NUMERO DE CONTROL");
                        }
                        //Terminar conexion
                        fxConexion.Close();
                    }
                    #endregion
                    #region TRAER EL NOMBRE DE LA CARRERA
                    foreach (Estudiante n in estudiantesResultado)
                    {
                        //1 Abrir conexion
                        fxConexion = new OleDbConnection(RutaFx + "dcarre.dbf;");
                        fxConexion.Open();
                        //2 Asignar valor a comando
                        fxComando = new OleDbCommand("SELECT CARNOM FROM dcarre WHERE dcarre.CARCVE = " + n.CarreraID.ToString(), fxConexion);
                        //3 ejecutar reader
                        fxReader = fxComando.ExecuteReader();
                        if (fxReader.HasRows)
                        {
                            while (fxReader.Read())
                            {
                                n.Carrera = fxReader["CARNOM"].ToString().TrimEnd();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"No existe la carrera: {n.CarreraID.ToString()}");
                        }
                        //Terminar conexion
                        fxConexion.Close();
                    }
                    #endregion
                    fxConexion.Close();
                    break;
                case "carrera":
                    _dato = BuscarIDDeCarrera(_dato);
                    #region BUSCAR SI ESTA DISPONIBLE O SI EXISTE TAL ESTUDIANTE BUSCADO
                    //1 Abrir conexion
                    fxConexion = new OleDbConnection(RutaFx + "dcalum.dbf;");
                    fxConexion.Open();
                    //2 Asignar el query
                    fxComando = new OleDbCommand("SELECT * FROM dcalum WHERE dcalum.CARCVE = " + _dato + " AND dcalum.CALSIT = '1'", fxConexion);
                    //3 Ejecutar el query
                    fxReader = fxComando.ExecuteReader();

                    if (fxReader.HasRows)
                    {
                        while (fxReader.Read())
                        {
                            estudiantesResultado.Add(new Estudiante(fxReader["ALUCTR"].ToString(), int.Parse(fxReader["CARCVE"].ToString()), ConsultarCreditosTerminados(fxReader["ALUCTR"].ToString()), ConsultarCreditosPendientes(fxReader["ALUCTR"].ToString())));
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontro nada dentro de la carrera: " + _dato);
                    }
                    fxConexion.Close();
                    #endregion
                    #region TRAER TODOS LOS DATOS DEL ALUMNO DE MANERA COMPLETA
                    foreach (Estudiante n in estudiantesResultado)
                    {
                        //1 Abrir conexion
                        fxConexion = new OleDbConnection(RutaFx + "dalumn.dbf;");
                        fxConexion.Open();
                        //2 Asignar valor a comando
                        fxComando = new OleDbCommand("SELECT * FROM dalumn WHERE dalumn.ALUCTR = '" + n.NumeroDeControl + "'", fxConexion);
                        //3 ejecutar reader
                        fxReader = fxComando.ExecuteReader();
                        if (fxReader.HasRows)
                        {
                            while (fxReader.Read())
                            {
                                n.Nombre = fxReader["ALUNOM"].ToString();
                                n.ApellidoMaterno = fxReader["ALUAPM"].ToString();
                                n.ApellidoPaterno = fxReader["ALUAPP"].ToString();

                            }
                        }
                        else
                        {
                            MessageBox.Show(n.NumeroDeControl + " no existe en la tabla dalum");
                        }
                        //Terminar conexion
                        fxConexion.Close();
                    }
                    #endregion
                    #region TRAER EL NOMBRE DE LA CARRERA
                    foreach (Estudiante n in estudiantesResultado)
                    {
                        //1 Abrir conexion
                        fxConexion = new OleDbConnection(RutaFx + "dcarre.dbf;");
                        fxConexion.Open();
                        //2 Asignar valor a comando
                        fxComando = new OleDbCommand("SELECT CARNOM FROM dcarre WHERE dcarre.CARCVE = " + n.CarreraID.ToString(), fxConexion);
                        //3 ejecutar reader
                        fxReader = fxComando.ExecuteReader();
                        if (fxReader.HasRows)
                        {
                            while (fxReader.Read())
                            {
                                n.Carrera = fxReader["CARNOM"].ToString().TrimEnd();
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO EXISTE TAL CARRERA");
                        }
                        //Terminar conexion
                        fxConexion.Close();
                    }
                    #endregion
                    fxConexion.Close();
                    break;
            }
            if (!(_creditosTerminados && _creditosPendientes && _sinCreditos && _semestre == 0))
            {
                List<Estudiante> estudiantesResultado2 = new List<Estudiante>();
                foreach (Estudiante n in estudiantesResultado)
                {
                    estudiantesResultado2.Add(n);
                }

                foreach (Estudiante x in estudiantesResultado2)
                {
                    if (!(_creditosTerminados && _creditosPendientes && _sinCreditos))
                    {
                        // -> (1) En caso de que solo quiera los que tengan creditos terminados
                        if (_creditosTerminados && !_creditosPendientes && !_sinCreditos)
                        {
                            if (!(x.CreditosTerminados == 5))
                            {
                                estudiantesResultado.Remove(x);
                            }

                        }
                        //En caso de que quiera creditos pendientes y creditos terminados
                        if (_creditosTerminados && _creditosPendientes && !_sinCreditos)
                        {
                            if (x.CreditosTerminados < 5 && x.CreditosPendientes == 0)
                            {
                                estudiantesResultado.Remove(x);
                            }
                        }
                        //En caso de que quiera creditos terminados y sin creditos
                        if (_creditosTerminados && !_creditosPendientes && _sinCreditos)
                        {
                            if (x.CreditosPendientes > 0)
                            {
                                estudiantesResultado.Remove(x);
                            }
                            else
                            {
                                if (x.CreditosTerminados != 5 && x.CreditosTerminados != 0)
                                {
                                    estudiantesResultado.Remove(x);
                                }
                            }
                        }
                        // -> (1) En caso de que quiera solo creditos pendientes 
                        if (!_creditosTerminados && _creditosPendientes && !_sinCreditos)
                        {
                            if (x.CreditosPendientes < 1)
                            {
                                estudiantesResultado.Remove(x);
                            }
                        }
                        // En caso de que quiera creditos pendientes  y sin creditos
                        if (!_creditosTerminados && _creditosPendientes && _sinCreditos)
                        {
                            if (x.CreditosTerminados > 0 && x.CreditosPendientes == 0)
                            {
                                estudiantesResultado.Remove(x);
                            }
                        }
                        //En caso de que quiera solo sin creditos
                        if (!_creditosTerminados && !_creditosPendientes && _sinCreditos)
                        {
                            if (x.CreditosTerminados > 0 || x.CreditosPendientes > 0)
                            {
                                estudiantesResultado.Remove(x);
                            }
                        }

                        //En caso de que no se apliquen filtros
                        if (!_creditosTerminados && !_creditosPendientes && !_sinCreditos)
                        {
                            estudiantesResultado.Clear();
                        }
                    }
                    else
                    {

                    }

                    if (_semestre != 0)
                    {
                        //Se elimina en caso de que no sea de dicho semestre
                        if (!(CalcularSemestre(x.NumeroDeControl) == _semestre))
                        {
                            estudiantesResultado.Remove(x);

                        }
                    }
                }
            }



            return estudiantesResultado;
        }

        public string BuscarNombreDeCarrera(int _id)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string carrera = "";

            //1 Abrir conexion
            fxConexion = new OleDbConnection(RutaFx + "dcarre.dbf;");
            fxConexion.Open();
            //2 Asignar valor a comando
            fxComando = new OleDbCommand("SELECT CARNOM FROM dcarre WHERE dcarre.CARCVE = " + _id.ToString(), fxConexion);
            //3 ejecutar reader
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    carrera = fxReader["CARNOM"].ToString();
                }
            }
            else
            {
                MessageBox.Show("NO EXISTE TAL CARRERA");
            }
            //Terminar conexion
            fxConexion.Close();


            return carrera;
        }

        public string BuscarNombreDepartamento(string _id)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string departamento = "";

            //1 Abrir conexion
            fxConexion = new OleDbConnection(RutaFx + "ddepto.dbf;");
            fxConexion.Open();
            //2 Asignar valor a comando
            fxComando = new OleDbCommand("SELECT DEPNOM FROM ddepto WHERE ddepto.DEPCVE = '" + _id.ToString() + "'", fxConexion);
            //3 ejecutar reader
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    departamento = fxReader["DEPNOM"].ToString();
                }
            }
            else
            {
                departamento = "No se encuentra registrado el departamento de dicho personal";
            }
            //Terminar conexion
            fxConexion.Close();


            return departamento;
        }

        public string BuscarNombreDepartamentoPorPersonal(string _personalID)
        {
            string name = "No se encuentra registrado el departamento de dicho personal";
            int departamento = ConsultarDepartamentoDePersonal(_personalID);
            if (departamento != 0)
            {
                name = BuscarNombreDepartamento(departamento.ToString());
            }
            return name;
        }

        public string ConsultarTituloDePersonal(string _personalID)
        {

            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string titulo = "";
            fxConexion = new OleDbConnection(RutaFx + "dperso.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT PERSIG FROM dperso WHERE dperso.PERCVE = " + _personalID.ToString(), fxConexion);
            fxReader = fxComando.ExecuteReader();
            try
            {
                if (fxReader.HasRows)
                {
                    while (fxReader.Read())
                    {
                        titulo = fxReader["PERSIG"].ToString().TrimEnd();
                    }
                }
                fxConexion.Close();
            }
            catch
            {
            }
            return titulo;
        }

        public List<Departamento> MostrarDepartamentos()
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            List<Departamento> departamentoLista = new List<Departamento>();
            fxConexion = new OleDbConnection(RutaFx + "ddepto.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT DEPNOM,DEPCVE FROM DDEPTO ORDER BY DEPNOM", fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    if (String.IsNullOrEmpty(fxReader["DEPNOM"].ToString().Trim()) || String.IsNullOrEmpty(fxReader["DEPCVE"].ToString().Trim()))
                    {

                    }
                    else
                    {

                        departamentoLista.Add(new Departamento(fxReader["DEPNOM"].ToString(), int.Parse(fxReader["DEPCVE"].ToString())));
                    }
                }
            }
            else
            {
                MessageBox.Show("NO EXISTEN DEPARTAMENTOS ");
            }
            fxConexion.Close();
            return departamentoLista;

        }

        public int ConsultarCarreraDelEstudiante(string _noControl)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            int carreraID = 0;

            //1 Abrir conexion
            fxConexion = new OleDbConnection(RutaFx + "dcalum.dbf;");
            fxConexion.Open();
            //2 Asignar valor a comando
            fxComando = new OleDbCommand("SELECT CARCVE FROM dcalum WHERE dcalum.ALUCTR = '" + _noControl + "'", fxConexion);
            //3 ejecutar reader
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    carreraID = int.Parse(fxReader["CARCVE"].ToString());
                }
            }
            else
            {
                MessageBox.Show("NO EXISTE TAL ALUMNO");
            }
            //Terminar conexion
            fxConexion.Close();


            return carreraID;
        }

        public bool ConsultarExistenciaDeAlumno(string _noControl)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            bool existe = false;

            //1 Abrir conexion
            fxConexion = new OleDbConnection(RutaFx + "dcalum.dbf;");
            fxConexion.Open();
            //2 Asignar valor a comando
            fxComando = new OleDbCommand("SELECT * FROM dcalum WHERE dcalum.ALUCTR = '" + _noControl + "'", fxConexion);
            //3 ejecutar reader
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                existe = true;
            }
            else
            {
                existe = false;
            }
            //Terminar conexion
            fxConexion.Close();


            return existe;
        }

        public string ConsultarNombreCompletoDePersonal(string _id)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string nombre = "";
            fxConexion = new OleDbConnection(RutaFx + "dperso.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT PERNOM,PERAPE FROM dperso WHERE dperso.PERCVE = " + _id.ToString(), fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    nombre = fxReader["PERNOM"].ToString().TrimEnd() + " " + fxReader["PERAPE"].ToString().TrimEnd();
                }
            }
            fxConexion.Close();
            return nombre;
        }

        public string ConsultarNombreDePersonal(string _id)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string nombre = "";
            fxConexion = new OleDbConnection(RutaFx + "dcarre.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT PERNOM FROM dperso WHERE dperso.PERCVE = " + _id.ToString(), fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    nombre = fxReader["PERNOM"].ToString().TrimEnd();
                }
            }
            fxConexion.Close();
            return nombre;
        }

        public string ConsultarNombreDeAlumno(string _numeroControl)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string nombre = "";
            fxConexion = new OleDbConnection(RutaFx + "dalumn.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT ALUNOM FROM dalumn WHERE dalumn.ALUCTR = '" + _numeroControl + "'", fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    nombre = fxReader["ALUNOM"].ToString().TrimEnd();
                }
            }
            fxConexion.Close();
            return nombre;
        }

        public string ConsultarApellidoMaternoDeAlumno(string _numeroControl)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string nombre = "";
            fxConexion = new OleDbConnection(RutaFx + "dalumn.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT ALUAPM FROM dalumn WHERE dalumn.ALUCTR = '" + _numeroControl + "'", fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    nombre = fxReader["ALUAPM"].ToString().TrimEnd();
                }
            }
            fxConexion.Close();
            return nombre;
        }

        public string ConsultarApellidoPaternoDeAlumno(string _numeroControl)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string nombre = "";
            fxConexion = new OleDbConnection(RutaFx + "dalumn.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT ALUAPP FROM dalumn WHERE dalumn.ALUCTR = '" + _numeroControl + "'", fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    nombre = fxReader["ALUAPP"].ToString().TrimEnd();
                }
            }
            fxConexion.Close();
            return nombre;
        }

        public string ConsultarApellidoDePersonal(string _id)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string apellido = "";
            fxConexion = new OleDbConnection(RutaFx + "dcarre.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT PERAPE FROM dperso WHERE dperso.PERCVE = " + _id.ToString(), fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    apellido = fxReader["PERAPE"].ToString().TrimEnd();
                }
            }
            fxConexion.Close();
            return apellido;
        }

        public int ConsultarDepartamentoDePersonal(string _id)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            int departamentoID = 0;
            fxConexion = new OleDbConnection(RutaFx + "dpuest.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT DEPCVE FROM dpuest WHERE dpuest.PERCVE = " + _id, fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    departamentoID = int.Parse(fxReader["DEPCVE"].ToString());
                }
            }
            fxConexion.Close();
            return departamentoID;
        }

        public int ContarAlumnosConCreditosPendientesUrgentes()
        {

            int conteo = 0;

            conteo = ContarAlumnosConCreditosPendientesPorSemeste(8) + ContarAlumnosConCreditosPendientesPorSemeste(9) + ContarAlumnosConCreditosPendientesPorSemeste(10);

            return conteo;
        }

        public int ContarAlumnosConCreditosPendientesPorSemeste(int _semestre)
        {

            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            int conteo = 0;
            fxConexion = new OleDbConnection(RutaFx + "dcalum.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT ALUCTR FROM dcalum WHERE dcalum.CALSIT = '1'", fxConexion);
            fxReader = fxComando.ExecuteReader();
            while (fxReader.Read())
            {
                int creditosRealizados = ConsultarCreditosTerminados(fxReader["ALUCTR"].ToString());
                if (creditosRealizados < 5)
                {
                    if (CalcularSemestre(fxReader["ALUCTR"].ToString()) == _semestre)
                    {
                        conteo++;
                    }
                }
            }
            fxConexion.Close();
            return conteo;

        }

        public List<Personal> ConsultarPosiblesJefes(string _id)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;



            List<Personal> Jefes = new List<Personal>();
            fxConexion = new OleDbConnection(RutaFx + "dpuest.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT PERCVE FROM dpuest WHERE dpuest.DEPCVE = '" + ConsultarDepartamentoDePersonal(_id) + "' ORDER BY PUENIV", fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    if (fxReader["PERCVE"].ToString() != _id && fxReader["PERCVE"].ToString() != "0")
                    {
                        Jefes.Add(new Personal(ConsultarNombreDePersonal(fxReader["PERCVE"].ToString()), ConsultarApellidoDePersonal(fxReader["PERCVE"].ToString()), int.Parse(fxReader["PERCVE"].ToString())));
                    }
                }
            }

            //Colocar solo los de mas alto grado



            fxConexion.Close();
            return Jefes;
        }

        public List<Personal> MostrarPersonal()
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            List<Personal> PersonalLista = new List<Personal>();
            fxConexion = new OleDbConnection(RutaFx + "dperso.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT PERNOM, PERCVE, PERAPE FROM dperso ORDER BY PERNOM", fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    PersonalLista.Add(new Personal(fxReader["PERNOM"].ToString().TrimEnd(), fxReader["PERAPE"].ToString().TrimEnd(), int.Parse(fxReader["PERCVE"].ToString())));
                }
            }
            else
            {
                MessageBox.Show("NO EXISTE PERSONAL ");
            }
            fxConexion.Close();
            return PersonalLista;

        }

        public Personal TraerPersonalEnEspecifico(string _clave)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            Personal Especifico = null;
            fxConexion = new OleDbConnection(RutaFx + "dperso.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT PERNOM, PERAPE, PERCVE FROM dperso WHERE PERCVE = " + _clave, fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    Especifico = new Personal(fxReader["PERNOM"].ToString().TrimEnd(), fxReader["PERAPE"].ToString().TrimEnd(), int.Parse(fxReader["PERCVE"].ToString()));
                }
            }
            else
            {
                MessageBox.Show("NO EXISTE PERSONAL ");
            }
            fxConexion.Close();

            return Especifico;

        }

        public List<Personal> MostrarPersonalDisponible()
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            List<Personal> PersonalLista = new List<Personal>();
            fxConexion = new OleDbConnection(RutaFx + "dperso.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT PERNOM, PERAPE, PERCVE  FROM dperso ORDER BY PERNOM ", fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    if (!VerificarSiExisteUsuario(fxReader["PERCVE"].ToString()))
                    {
                        PersonalLista.Add(new Personal(fxReader["PERNOM"].ToString().TrimEnd(), fxReader["PERAPE"].ToString().TrimEnd(), int.Parse(fxReader["PERCVE"].ToString())));
                    }
                }
            }
            else
            {
                MessageBox.Show("NO EXISTE PERSONAL ");
            }
            fxConexion.Close();
            return PersonalLista;
        }

        public List<string> MostrarCarreras()
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            List<string> carrerasNombres = new List<string>();
            fxConexion = new OleDbConnection(RutaFx + "dcarre.dbf;");
            fxConexion.Open();
            fxComando = new OleDbCommand("SELECT CARNOM FROM dcarre WHERE NOT dcarre.CARSIT = 3 ORDER BY CARCVE  ", fxConexion);
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    carrerasNombres.Add(fxReader["CARNOM"].ToString().TrimEnd());
                }
            }
            else
            {
                MessageBox.Show("NO EXISTE TAL CARRERA");
            }
            fxConexion.Close();
            return carrerasNombres;

        }

        public string BuscarIDDeCarrera(string _nombre)
        {
            OleDbConnection fxConexion;
            OleDbCommand fxComando = new OleDbCommand();
            OleDbDataReader fxReader;
            string carrera = "";

            //1 Abrir conexion
            fxConexion = new OleDbConnection(RutaFx + "dcarre.dbf;");
            fxConexion.Open();
            //2 Asignar valor a comando
            fxComando = new OleDbCommand("SELECT CARCVE FROM dcarre WHERE dcarre.CARNOM = '" + _nombre + "'", fxConexion);
            //3 ejecutar reader
            fxReader = fxComando.ExecuteReader();
            if (fxReader.HasRows)
            {
                while (fxReader.Read())
                {
                    carrera = fxReader["CARCVE"].ToString();
                }
            }
            else
            {
                MessageBox.Show("NO EXISTE TAL CARRERA");
            }
            //Terminar conexion
            fxConexion.Close();


            return carrera;
        }
        #endregion

        #endregion

        #region CONSULTAS ES SQL SERVER

        #region ACTIVIDADES Y SECCIONES
        #region DML
        public void EliminarActividad(string _creditoID, string _numeroControl)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("DELETE  FROM Creditos WHERE NumeroDeControl = '" + _numeroControl + "' AND CreditoID = " + _creditoID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void AsignarJefesAActividadesSinJefe()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            List<ActividadComplementaria> actividadesEcnontradas = new List<ActividadComplementaria>();

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();

            comando = new SqlCommand("SELECT CreditoID, ResponsableID FROM Creditos WHERE JefeID = 0", conexion);
            reader = comando.ExecuteReader();

            int Count = 0;
            while (reader.Read())
            {
                SqlConnection conexion2;
                SqlCommand comando2 = new SqlCommand();
                SqlDataReader reader2;
                conexion2 = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
                conexion2.Open();

                List<Personal> PosiblesJefes = ConsultarPosiblesJefes(reader["ResponsableID"].ToString());
                string jefe;
                try
                {
                    jefe = PosiblesJefes[(PosiblesJefes.Count - 1)].Clave.ToString();
                }
                catch
                {
                    jefe = "0";
                }
                comando2 = new SqlCommand("UPDATE Creditos SET JefeID = " + jefe + " WHERE CreditoID = " + reader["CreditoID"].ToString(), conexion2);
                reader2 = comando2.ExecuteReader();
                conexion2.Close();
            }
            conexion.Close();
            MessageBox.Show(Count.ToString());
        }

        public void EliminarActividad(string _idActividad)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("DELETE  FROM Actividades WHERE ActividadID = " + _idActividad, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void EliminarSeccion(string _seccionID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("DELETE  FROM Secciones WHERE SeccionID = " + _seccionID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void InsertarActividad(string _numeroControl, string _fechaOficio, int _actividadID, int _periodo, int _responsableID, int _jefeID, int _carreraID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("INSERT INTO Creditos (NumeroDeControl, FechaDeOficio, ActividadID, Periodo, ResponsableID, JefeID, CarreraID, Pregunta1, Pregunta2, Pregunta3, Pregunta4, Pregunta5, Pregunta6, Pregunta7, Promedio,EstadoDeLaActividad, EstadoDeLaFirma) VALUES ('" + _numeroControl + "', '" + _fechaOficio + "', " + _actividadID + ", " + _periodo + ", " + _responsableID + ", " + _jefeID + ", " + _carreraID + ", 0, 0, 0, 0, 0, 0, 0, 0, 'A', 'P')", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void InsertarActividad(string _numeroControl, string _fechaOficio, int _actividadID, int _periodo, int _responsableID, int _jefeID, int _carreraID, int _grupoID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("INSERT INTO Creditos (NumeroDeControl, FechaDeOficio, ActividadID, Periodo, ResponsableID, JefeID, CarreraID, Pregunta1, Pregunta2, Pregunta3, Pregunta4, Pregunta5, Pregunta6, Pregunta7, Promedio,EstadoDeLaActividad, EstadoDeLaFirma, GrupoID) VALUES ('" + _numeroControl + "', '" + _fechaOficio + "', " + _actividadID + ", " + _periodo + ", " + _responsableID + ", " + _jefeID + ", " + _carreraID + ", 0, 0, 0, 0, 0, 0, 0, 0, 'A', 'P', " + _grupoID + ")", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void ActualizarActividad(string _creditoID, string _fechaOficio, int _actividadID, int _periodo, int _responsableID, int _jefeID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("UPDATE Creditos SET FechaDeOficio = '" + _fechaOficio + "', ActividadID = " + _actividadID + ", Periodo = " + _periodo + ", ResponsableID = " + _responsableID + ", JefeID = " + _jefeID + " WHERE CreditoID = " + _creditoID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void MarcarFirma(string _marca, string _creditoID)
        {

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("UPDATE Creditos SET EstadoDeLaFirma = '" + _marca + "' WHERE CreditoID = " + _creditoID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();

        }

        public void ActualizarSeccion(string _titulo, int _pesoMaximo, int _seccionID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("UPDATE Secciones SET Titulo = '" + _titulo + "', PesoMaximo = " + _pesoMaximo + " WHERE SeccionID = " + _seccionID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void InsertarNuevaSeccion(string _titulo, int _pesoMaximo)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("INSERT INTO Secciones (Titulo, PesoMaximo) VALUES ('" + _titulo + "', " + _pesoMaximo + ")", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void EliminarSeccion(int _seccionID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("DELETE  FROM Secciones WHERE SeccionID = " + _seccionID + "", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void InsertarNuevaActividad(string _titulo, int _peso, int _seccionID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("INSERT INTO Actividades (Titulo, Peso, SeccionID) VALUES ('" + _titulo + "', " + _peso + ", " + _seccionID + ")", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void ActualizarActividad(string _titulo, int _peso, int _seccionID, int _ActividadID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("UPDATE Actividades SET Titulo = '" + _titulo + "', Peso = " + _peso + ",   SeccionID = " + _seccionID + " WHERE ActividadID = " + _ActividadID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }
        #endregion
        #region DQL
        public int ConsultarPesoActividad(string _idActividad)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            int actividadPeso = 0;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT Peso FROM Actividades WHERE ActividadID = " + _idActividad, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                actividadPeso = int.Parse(reader["Peso"].ToString());
            }
            conexion.Close();
            return actividadPeso;
        }

        public string ConsutlarNombreActividad(string _idActividad)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            string nombreActividad = "ERROR: No exste tal numero de actividad";
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT Titulo FROM Actividades WHERE ActividadID = " + _idActividad, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                nombreActividad = reader["Titulo"].ToString();
            }
            conexion.Close();
            return nombreActividad;
        }

        public string ConsutlarNombreSeccion(string _idSeccion)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            string nombreSeccion = "ERROR: No exste tal numero de seccion";
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT Titulo FROM Secciones WHERE SeccionID = " + _idSeccion, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                nombreSeccion = reader["Titulo"].ToString();
            }
            conexion.Close();

            return nombreSeccion;
        }

        public string ConsultarSeccionID(string _idActividad)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            string idSeccion = "ERROR: No exste tal numero de actividad";
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT SeccionID FROM Actividades WHERE ActividadID = " + _idActividad, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                idSeccion = reader["SeccionID"].ToString();
            }
            conexion.Close();
            return idSeccion;
        }

        public List<Seccion> MostrarSeccionesDisponibles(string _numeroControl)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            List<Seccion> secciones = new List<Seccion>();
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Secciones ORDER BY Titulo ", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                int x = ConsultarCreditosTerminadosDeUnaSeccion(_numeroControl, reader["SeccionID"].ToString());
                if (x < int.Parse(reader["PesoMaximo"].ToString()))
                {
                    secciones.Add(new Seccion(reader["Titulo"].ToString(), int.Parse(reader["SeccionID"].ToString()), int.Parse(reader["PesoMaximo"].ToString())));
                }
            }
            conexion.Close();
            return secciones;
        }

        public List<ActividadComplementaria> BuscarActividades(string _numeroControl)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            List<ActividadComplementaria> actividadesEcnontradas = new List<ActividadComplementaria>();

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();

            comando = new SqlCommand("SELECT * FROM Creditos WHERE NumeroDeControl = '" + _numeroControl + "'", conexion);
            reader = comando.ExecuteReader();

            while (reader.Read())
            {
                actividadesEcnontradas.Add(new ActividadComplementaria(
                    ConsultarPesoActividad(reader["ActividadID"].ToString()),
                    int.Parse(reader["CreditoID"].ToString()),
                    ConsutlarNombreActividad(reader["ActividadID"].ToString()).ToString(),
                    int.Parse(reader["ActividadID"].ToString()),
                    int.Parse(reader["JefeID"].ToString()),
                    ConsultarNombreCompletoDePersonal(reader["JefeID"].ToString()),
                    int.Parse(reader["ResponsableID"].ToString()),
                    ConsultarNombreCompletoDePersonal(reader["ResponsableID"].ToString()),
                    char.Parse(reader["EstadoDeLaActividad"].ToString()),
                    DateTime.Parse(reader["FechaDeOficio"].ToString()),
                    int.Parse(reader["Periodo"].ToString()),
                    int.Parse(reader["Pregunta1"].ToString()),
                    int.Parse(reader["Pregunta2"].ToString()),
                    int.Parse(reader["Pregunta3"].ToString()),
                    int.Parse(reader["Pregunta4"].ToString()),
                    int.Parse(reader["Pregunta5"].ToString()),
                    int.Parse(reader["Pregunta6"].ToString()),
                    int.Parse(reader["Pregunta7"].ToString()),
                    double.Parse(reader["Promedio"].ToString()),
                    char.Parse(reader["EstadoDeLaFirma"].ToString()),
                    ConsutlarNombreSeccion(ConsultarSeccionID(reader["ActividadID"].ToString()))
                    ));
            }
            conexion.Close();



            return actividadesEcnontradas;
        }

        public Boolean VerificarSiLlevaCiertaActividad(string _numeroControl, string _actividadID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            Boolean lleva = false;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT NumeroDeControl FROM Creditos WHERE NumeroDeControl = '" + _numeroControl + "'AND ActividadID = " + _actividadID, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                lleva = true;
            }
            conexion.Close();
            return lleva;
        }

        public int TraerIDDelCredito(string _numeroControl, string _actividadID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            int actividadID = 0;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT CreditoID FROM Creditos WHERE NumeroDeControl = '" + _numeroControl + "'AND ActividadID = " + _actividadID, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                actividadID = int.Parse(reader["CreditoID"].ToString());
            }
            conexion.Close();
            return actividadID;
        }

        //Ultimamente modificado
        public int ConsultarCuantasActividadesDeEseTipoTiene(string _numeroControl, string _actividadID)
        {
            int conteo = 0;
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT COUNT(CreditoID) AS 'Conteo' FROM Creditos WHERE NumeroDeControl = '" + _numeroControl + "'AND ActividadID = " + _actividadID, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                conteo = int.Parse(reader["Conteo"].ToString());
            }
            conexion.Close();
            return conteo;
        }

        public List<Actividad> MostrarActividadesDisponibles(string _numeroControl, string _seccionID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            List<Actividad> actividades = new List<Actividad>();
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Actividades WHERE SeccionID = " + _seccionID, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {

                if (ConsultarCuantasActividadesDeEseTipoTiene(_numeroControl, reader["ActividadID"].ToString()) >= ConsultarPesoActividad(reader["ActividadID"].ToString()))
                {

                }
                else
                {
                    actividades.Add(new Actividad(reader["Titulo"].ToString(), int.Parse(reader["ActividadID"].ToString()), int.Parse(reader["Peso"].ToString()), int.Parse(reader["SeccionID"].ToString()), ConsutlarNombreSeccion(reader["SeccionID"].ToString())));
                }

            }
            conexion.Close();
            return actividades;
        }

        public List<Seccion> MostrarSecciones()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            List<Seccion> secciones = new List<Seccion>();
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Secciones ORDER BY Titulo", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {

                secciones.Add(new Seccion(reader["Titulo"].ToString(), int.Parse(reader["SeccionID"].ToString()), int.Parse(reader["PesoMaximo"].ToString())));

            }
            conexion.Close();
            return secciones;
        }

        public List<Actividad> MostrarActividades()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            List<Actividad> actividades = new List<Actividad>();
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Actividades ORDER BY Titulo ", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {

                actividades.Add(new Actividad(reader["Titulo"].ToString(), int.Parse(reader["ActividadID"].ToString()), int.Parse(reader["Peso"].ToString()), int.Parse(reader["SeccionID"].ToString()), ConsutlarNombreSeccion(reader["SeccionID"].ToString())));


            }
            conexion.Close();
            return actividades;
        }
        #endregion
        #endregion
        
        #region ALUMNOS
        #region DML
        public void EvaluarAlumno(int _creditoID, int _p1, int _p2, int _p3, int _p4, int _p5, int _p6, int _p7, double _promedio)
        {
            string estado = "";
            if (_promedio >= 3)
            {
                estado = "T";
            }
            else
            {
                estado = "A";
            }
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("UPDATE Creditos SET Pregunta1 = " + _p1 + ", Pregunta2 = " + _p2 + ", Pregunta3= " + _p3 + ", Pregunta4 = " + _p4 + ", Pregunta5= " + _p5 + ", Pregunta6= " + _p6 + ", Pregunta7= " + _p7 + ", Promedio= " + _promedio + ", EstadoDeLaActividad = '" + estado + "' WHERE CreditoID = " + _creditoID + "", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }
        public void EvaluarGrupo(int _grupoID, List<Estudiante> _estudiantes, int _p1, int _p2, int _p3, int _p4, int _p5, int _p6, int _p7, double _promedio)
        {
            string estado = "";
            if (_promedio >= 3)
            {
                estado = "T";
            }
            else
            {
                estado = "A";
            }
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
             foreach (Estudiante e in _estudiantes)
            {
                comando = new SqlCommand($"UPDATE Creditos SET Pregunta1 = {_p1}, Pregunta2 = {_p2}, Pregunta3 = {_p3}, Pregunta4 = {_p4}, Pregunta5 = {_p5}, Pregunta6 = {_p6}, Pregunta7 = {_p7}, Promedio = {_promedio}, EstadoDeLaActividad = '{estado}' WHERE GrupoID =  {_grupoID} AND NumeroDeControl = '{e.NumeroDeControl}' ", conexion);
                reader = comando.ExecuteReader();
                reader.Close();
            }
            conexion.Close();

        }
        #endregion
        #region DQL
        public int ContarAlumnosConCreditosTerminados()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            int conteo = 0;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT DISTINCT NumeroDeControl FROM Creditos WHERE EstadoDeLaActividad = 'T' ", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                int creditosTerminados = ConsultarCreditosTerminados(reader["NumeroDeControl"].ToString());
                if (creditosTerminados >= 5)
                {
                    conteo++;
                }
            }
            conexion.Close();
            return conteo;
        }

        public int ContarAlumnosConCreditosPendientes()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            int conteo = 0;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT DISTINCT NumeroDeControl FROM Creditos", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                int creditosRealizados = ConsultarCreditosTerminados(reader["NumeroDeControl"].ToString());
                if (creditosRealizados < 5)
                {
                    conteo++;
                }
            }
            conexion.Close();

            return conteo;
        }
        #endregion
        #endregion

        #region  CREDITOS
        #region DQL
        public int ConsultarCreditosTerminadosDeUnaSeccion(string _numControl, string _idSeccion)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            int Conteo = 0;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT ActividadID FROM Creditos WHERE NumeroDeControl = '" + _numControl + "'", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (ConsultarSeccionID(reader["ActividadID"].ToString()) == _idSeccion)
                {
                    Conteo++;
                }
            }
            conexion.Close();
            return Conteo;
        }

        public int ConsultarCreditosPendientes(string _numControl)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            int Conteo = 0;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT COUNT(CreditoID) As 'Conteo' FROM Creditos WHERE NumeroDeControl = '" + _numControl + "' AND Promedio < 3", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Conteo = int.Parse(reader["Conteo"].ToString());
            }
            conexion.Close();
            return Conteo;
        }

        public int ConsultarCreditosTerminados(string _numControl)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            int Conteo = 0;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT COUNT(CreditoID) AS 'count' FROM Creditos WHERE NumeroDeControl = '" + _numControl + "' AND Promedio >= 3", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Conteo = int.Parse(reader["count"].ToString());
            }
            conexion.Close();
            return Conteo;
        }

        public string ConsultarDuenoDelCredito(string _creditoID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT NumeroDeControl FROM Creditos WHERE CreditoID = '" + _creditoID + "'", conexion);
            reader = comando.ExecuteReader();
            string name = "";
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader["NumeroDeControl"].ToString();
                }
            }
            else
            {
                name = "No existe tal credito";
            }
            conexion.Close();
            return name;
        }

        #endregion
        #endregion

        #region USUARIOS DEL SISTEMA
        #region DML
        public void InsertarUsuario(int _personalID, string _clave, string _rol, string _nombre, string _apellido, string _genero)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("INSERT INTO Usuarios (Nombre, Apellidos, Clave, Rol,PersonalID, Genero, DepartamentoID) VALUES ('" + _nombre + "', '" + _apellido + "', '" + _clave + "', '" + _rol + "', " + _personalID + ", '" + _genero + "', " + ConsultarDepartamentoDePersonal(_personalID.ToString()) + ")", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void EliminarUsuario(string _Usuarioid)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("DELETE  FROM Usuarios WHERE UsuarioID = '" + _Usuarioid + "'", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void ActualizarDatosDeUsuario(string _rol, string _clave, string _genero, int _userID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("UPDATE Usuarios SET Rol = '" + _rol + "', Clave = '" + _clave + "', Genero = '" + _genero + "' WHERE UsuarioID = " + _userID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }
        
        #endregion
        #region DQL
        public Usuario BuscarUsuario(string _nombre, string _clave)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            Usuario user = null;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Usuarios WHERE Nombre = '" + _nombre + "'" + " AND Clave = '" + _clave + "'", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                user = new Usuario(reader["Nombre"].ToString(), reader["Clave"].ToString(), int.Parse(reader["UsuarioID"].ToString()), reader["Rol"].ToString(), int.Parse(reader["PersonalID"].ToString()), reader["Apellidos"].ToString(), reader["Genero"].ToString(), int.Parse(reader["DepartamentoID"].ToString()));
            }
            conexion.Close();

            return user;
        }

        public Boolean VerificarSiExisteUsuario(string _personalID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT PersonalID FROM Usuarios WHERE PersonalID = '" + _personalID + "'", conexion);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                conexion.Close();
                return true;
            }
            else
            {
                conexion.Close();
                return false;
            }
        }

        public List<string> MostrarUsuarios()
        {

            SqlConnection conexion;
            List<string> usuarios = new List<string>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT Nombre FROM Usuarios ORDER BY Nombre ", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                usuarios.Add(reader["Nombre"].ToString());
            }
            conexion.Close();
            return usuarios;

        }

        public int ContarUsuarios()
        {

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT COUNT(UsuarioID) AS 'Count' FROM Usuarios ", conexion);
            reader = comando.ExecuteReader();

            int conteo = 0;
            while (reader.Read())
            {
                conteo = int.Parse(reader["Count"].ToString());
            }
            conexion.Close();
            return conteo;

        }

        public List<Usuario> MostrarUsuariosRegistrados()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            List<Usuario> usuarios = new List<Usuario>();
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Usuarios ORDER BY Nombre", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                usuarios.Add(new Usuario(reader["Nombre"].ToString(), reader["Clave"].ToString(), int.Parse(reader["UsuarioID"].ToString()), reader["Rol"].ToString(), int.Parse(reader["PersonalID"].ToString()), reader["Apellidos"].ToString(), reader["Genero"].ToString(), int.Parse(reader["DepartamentoID"].ToString())));
            }
            conexion.Close();
            return usuarios;
        }

        public string MostrarNombreDeUsuario(string _ID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            string name = "";
            comando = new SqlCommand("SELECT Nombre, Apellidos FROM Usuarios WHERE UsuarioID = '" + _ID + "'", conexion);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader["Nombre"].ToString() + " " + reader["Apellidos"].ToString();
                }

            }
            else
            {
                name = "No existe el usuario";
            }
            conexion.Close();
            return name;
        }
        #endregion
        #endregion

        #region GRUPOS
        #region DML
        public void EliminarAlumnoDeUnGrupo(string _numControl, string _grupoID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("UPDATE Creditos SET GrupoID = NULL WHERE GrupoID = " + _grupoID + "AND NumeroDeControl = " + _numControl, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void AsignarGrupo(string _creditoID, string _grupoID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("UPDATE Creditos SET GrupoID = " + _grupoID + " WHERE CreditoID = " + _creditoID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

       
        public void InsertarNuevoGrupo(string _titulo, string _actividadID, string _limite, string _responsableID, string _periodo)
        {

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand(" INSERT INTO Grupos(Titulo, ActividadID, Limite, ResponsableID, Periodo) VALUES('" + _titulo + "', " + _actividadID + ", " + _limite + ", " + _responsableID + " , "+ _periodo+")", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void EditarGrupo(string _titulo, string _limite, string _responsableID, string _periodo, string _grupoID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand(" UPDATE  Grupos SET Titulo = '" + _titulo + "', Limite = " + _limite + " , ResponsableID = " + _responsableID + ", Periodo = '" + _periodo +  "' WHERE GrupoID = " + _grupoID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }

        public void EliminarGrupo(string _grupoID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("DELETE FROM Grupos WHERE GrupoID = " + _grupoID, conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }
        #endregion
        #region DQL

        public List<string> MostrarPeriodosGrupos()
        {
         
                SqlConnection conexion;
                SqlCommand comando = new SqlCommand();
                SqlDataReader reader;

                List<string> periodos = new List<string>();

                conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
                conexion.Open();
                comando = new SqlCommand("SELECT DISTINCT Periodo FROM Grupos WHERE Periodo IS NOT NULL", conexion);
                reader = comando.ExecuteReader();
                periodos.Add("Sin periodo");
                while (reader.Read())
                {
                periodos.Add(reader["Periodo"].ToString());
                 }
                conexion.Close();

                return periodos;
            
        }
        public List<Grupo> MostrarGrupos()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            List<Grupo> grupos = new List<Grupo>();

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Grupos ORDER BY Titulo", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                grupos.Add(new Grupo(int.Parse(reader["GrupoID"].ToString()), reader["Titulo"].ToString(), int.Parse(reader["Limite"].ToString()), int.Parse(reader["ResponsableID"].ToString()), int.Parse(reader["ActividadID"].ToString()), ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()), reader["Periodo"].ToString()));
            }
            conexion.Close();

            return grupos;
        }
        public List<Grupo> MostrarGruposPorPeriodo(string _periodo)
        {
            if(_periodo == "Sin periodo")
            {
                SqlConnection conexion;
                SqlCommand comando = new SqlCommand();
                SqlDataReader reader;

                List<Grupo> grupos = new List<Grupo>();

                conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
                conexion.Open();
                comando = new SqlCommand($"SELECT * FROM Grupos WHERE Periodo IS NULL ORDER BY Titulo", conexion);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    grupos.Add(new Grupo(int.Parse(reader["GrupoID"].ToString()), reader["Titulo"].ToString(), int.Parse(reader["Limite"].ToString()), int.Parse(reader["ResponsableID"].ToString()), int.Parse(reader["ActividadID"].ToString()), ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()), reader["Periodo"].ToString()));
                }
                conexion.Close();

                return grupos;
            }
            else
            {
                SqlConnection conexion;
                SqlCommand comando = new SqlCommand();
                SqlDataReader reader;

                List<Grupo> grupos = new List<Grupo>();

                conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
                conexion.Open();
                comando = new SqlCommand($"SELECT * FROM Grupos WHERE Periodo = '{_periodo}'  ORDER BY Titulo", conexion);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    grupos.Add(new Grupo(int.Parse(reader["GrupoID"].ToString()), reader["Titulo"].ToString(), int.Parse(reader["Limite"].ToString()), int.Parse(reader["ResponsableID"].ToString()), int.Parse(reader["ActividadID"].ToString()), ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()), reader["Periodo"].ToString()));
                }
                conexion.Close();

                return grupos;
            }
        }
           


        public int ContarGrupos()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            int conteo = 0;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT COUNT(GrupoID) AS 'Conteo' FROM Grupos ", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                conteo = int.Parse(reader["Conteo"].ToString());
            }
            conexion.Close();
            return conteo;
        }

        public List<Grupo> MostrarGruposDisponibles()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            List<Grupo> grupos = new List<Grupo>();

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Grupos ORDER BY Titulo ", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (!(ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()) >= int.Parse(reader["Limite"].ToString())))
                {
                    grupos.Add(new Grupo(int.Parse(reader["GrupoID"].ToString()), reader["Titulo"].ToString(), int.Parse(reader["Limite"].ToString()), int.Parse(reader["ResponsableID"].ToString()), int.Parse(reader["ActividadID"].ToString()), ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()), reader["Periodo"].ToString()));
                }
                
            }
            conexion.Close();

            return grupos;
        }

        public Grupo MostrarUnGrupoEnEspecifico(string _gurpoID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            Grupo grupo = null;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Grupos WHERE GrupoID = " + _gurpoID, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                grupo = new Grupo(int.Parse(reader["GrupoID"].ToString()), reader["Titulo"].ToString(), int.Parse(reader["Limite"].ToString()), int.Parse(reader["ResponsableID"].ToString()), int.Parse(reader["ActividadID"].ToString()), ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()), reader["Periodo"].ToString());
            }
            conexion.Close();

            return grupo;
        }

        public List<Grupo> MostrarGruposPorActividad(string _actividadID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            List<Grupo> grupos = new List<Grupo>();

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Grupos WHERE ActividadID = " + _actividadID + " ORDER BY Titulo", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()) >= int.Parse(reader["Limite"].ToString()))
                {

                }
                else
                {
                    grupos.Add(new Grupo(int.Parse(reader["GrupoID"].ToString()), reader["Titulo"].ToString(), int.Parse(reader["Limite"].ToString()), int.Parse(reader["ResponsableID"].ToString()), int.Parse(reader["ActividadID"].ToString()), ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()), reader["Periodo"].ToString()));
                }
            }
            conexion.Close();

            return grupos;
        }

        public bool BuscarDisponibilidadDeGrupo(string _actividadID)
        {

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            List<Grupo> grupos = new List<Grupo>();

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Grupos WHERE ActividadID = " + _actividadID, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()) >= int.Parse(reader["Limite"].ToString()))
                {

                }
                else
                {
                    grupos.Add(new Grupo(int.Parse(reader["GrupoID"].ToString()), reader["Titulo"].ToString(), int.Parse(reader["Limite"].ToString()), int.Parse(reader["ResponsableID"].ToString()), int.Parse(reader["ActividadID"].ToString()), ContarAlumnosDeUnGrupo(reader["GrupoID"].ToString()), reader["Periodo"].ToString()));
                }
            }
            conexion.Close();
            foreach (Grupo x in grupos)
            {
                if (!(ContarAlumnosDeUnGrupo(x.ID.ToString()) >= x.Cupo))
                {
                    return true;
                }
            }
            return false;
        }

        public int ContarAlumnosDeUnGrupo(string _grupoID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            int conteo = 0;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT COUNT(CreditoID) AS 'Conteo' FROM Creditos WHERE GrupoID = " + _grupoID + " ", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                conteo = int.Parse(reader["Conteo"].ToString());
            }
            conexion.Close();
            return conteo;
        }

        public List<Estudiante> MostrarEstudiantesDeUnGrupo(string _grupoID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            List<Estudiante> estudiantes = new List<Estudiante>();

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT NumeroDeControl, CarreraID FROM Creditos WHERE GrupoID = " + _grupoID + " ", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {

                OleDbConnection fxConexion;
                OleDbCommand fxComando = new OleDbCommand();
                OleDbDataReader fxReader;
                fxConexion = new OleDbConnection(RutaFx + "dalumn.dbf;");
                fxConexion.Open();
                fxComando = new OleDbCommand("SELECT ALUNOM, ALUAPP, ALUAPM FROM dalumn WHERE dalumn.ALUCTR = '" + reader["NumeroDeControl"].ToString() + "'", fxConexion);
                fxReader = fxComando.ExecuteReader();
                if (fxReader.HasRows)
                {
                    while (fxReader.Read())
                    {
                        estudiantes.Add(new Estudiante(fxReader["ALUNOM"].ToString().TrimEnd(), fxReader["ALUAPP"].ToString().TrimEnd(), fxReader["ALUAPM"].ToString().TrimEnd(), reader["NumeroDeControl"].ToString(), int.Parse(reader["CarreraID"].ToString()), ConsultarCreditosTerminados(reader["NumeroDeControl"].ToString()), ConsultarCreditosPendientes(reader["NumeroDeControl"].ToString())));
                    }
                }
                fxConexion.Close();


            }
            conexion.Close();

            return estudiantes;
        }

        #endregion
        #endregion

        #region LOGS
        #region DML
        public void InsertarNuevoLog(string _contenido)
        {

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand(" INSERT INTO Logs(UsuarioID, Contenido, Fecha) VALUES(" + Nucleo.UsuarioLogueado.UsuarioID + ", '" + _contenido + "', '" + DateTime.Now.ToString("yyyyMMdd") + "')", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }
        public void BorrarLogs()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("TRUNCATE TABLE Logs", conexion);
            reader = comando.ExecuteReader();
            conexion.Close();
        }
        #endregion
        #region DDL
        public List<Registro> MostrarLogs()
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            List<Registro> registros = new List<Registro>();

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Logs ORDER BY LogID desc ", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                registros.Add(new Registro(int.Parse(reader["LogID"].ToString()), int.Parse(reader["UsuarioID"].ToString()), reader["Contenido"].ToString(), reader["Fecha"].ToString()));
            }
            conexion.Close();

            return registros;
        }
        #endregion
        #endregion
        #region REPORTES 
        #region DQL
        public List<Reporte> MostrarReportes()
        {
            List<Reporte> Reportes =  new List<Reporte>();

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
 
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT * FROM Reportes", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Reportes.Add(new Reporte(reader["Titulo"].ToString(), DateTime.Parse(reader["FechaDeOficio"].ToString()), BuscarNombreDeCarrera(int.Parse(reader["CarreraID"].ToString())), int.Parse(reader["ID"].ToString())));
            }
            conexion.Close();

            return Reportes;
        }
        public List<Estudiante> MostrarEstudiantesDeUnReporte(string _ID)
        {
            List<Estudiante> Estudiantes = new List<Estudiante>();
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand($"SELECT NumeroDeControl FROM AlumnoReporte WHERE ReporteID = {_ID}", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Estudiantes.Add(new Estudiante(reader["NumeroDeControl"].ToString(), ConsultarNombreDeAlumno(reader["NumeroDeControl"].ToString()), ConsultarApellidoMaternoDeAlumno(reader["NumeroDeControl"].ToString()), ConsultarApellidoPaternoDeAlumno(reader["NumeroDeControl"].ToString())));
            }
            conexion.Close();
            return Estudiantes;
        }
        public Reporte MostrarReporteEspecifico(string _ID)
        {
            Reporte ReporteDevolver = null;

            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
 
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand($"SELECT * FROM Reportes WHERE ID = {_ID}", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ReporteDevolver = new Reporte(reader["Titulo"].ToString(), DateTime.Parse(reader["FechaDeOficio"].ToString()), BuscarNombreDeCarrera(int.Parse(reader["CarreraID"].ToString())), int.Parse(reader["ID"].ToString()));
            }
            conexion.Close();

            ReporteDevolver.Estudiantes = MostrarEstudiantesDeUnReporte(_ID);

            return ReporteDevolver;
        }
        
        public string MostrarUltimoReporteID()
        {
            string id = "";
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand("SELECT MAX(ID) AS MAX FROM Reportes", conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                id = reader["MAX"].ToString();
            }
            conexion.Close();
             return id;
        }

        #endregion
        #region DML
        public bool NuevoReporte(string _titulo, string _carrera,  int _semestre)
        {
            bool xd = false;
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand($"SELECT NumeroDeControl FROM Creditos c WHERE EstadoDeLaActividad = 'T' AND CarreraID = '{_carrera}'  AND NOT EXISTS (SELECT NULL FROM AlumnoReporte a WHERE c.NumeroDeControl = a.NumeroDeControl)GROUP BY NumeroDeControl HAVING COUNT(NumeroDeControl) >= 5 ORDER BY NumeroDeControl ", conexion);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                //Todos los semestres
                if (_semestre == -1)
                {
                    xd = true;
                    InsertarReporte(_titulo, _carrera);
                    while (reader.Read())
                    {
                        InsertarAlumnoReporte(reader["NumeroDeControl"].ToString(), MostrarUltimoReporteID());
                    }
                }
                //Semestre en especifico
                else
                {
                    int x = 0;
                    while (reader.Read())
                    {
                        if(CalcularSemestre(reader["NumeroDeControl"].ToString()) == _semestre){
                            x++;
                            if (x == 1)
                            {
                                xd = true;
                                InsertarReporte(_titulo, _carrera);
                            }
                            InsertarAlumnoReporte(reader["NumeroDeControl"].ToString(), MostrarUltimoReporteID());
                        }
                    }
                }
            }
            conexion.Close();
            return xd;
        }
        public void InsertarReporte(string _titulo, string _carreraID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand($"INSERT INTO Reportes VALUES('{_titulo}', '{DateTime.Now.ToString("yyyy-MM-dd")}', {_carreraID})", conexion);
            comando.ExecuteNonQuery();
        }
        public void InsertarAlumnoReporte(string _numeroDeControl, string _reporteID)
        {
            SqlConnection conexion;
            SqlCommand comando = new SqlCommand();
            conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + BD + ";User ID=" + Usuario + ";Password=" + Clave);
            conexion.Open();
            comando = new SqlCommand($"INSERT INTO AlumnoReporte VALUES('{_numeroDeControl}', {_reporteID})", conexion);
            comando.ExecuteNonQuery();
        }
        #endregion
        #endregion
        #endregion

        #endregion
    }
}