using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeCreditos.Clases;
using SistemaDeCreditos.Conexiones;
using System.IO;
using System.Windows.Forms;

namespace SistemaDeCreditos
{
    public static class Nucleo
    {
        public static string departamentoJefeGenerado = "";
        public static Usuario UsuarioLogueado = null;
        public static int AlumnosConCreditosTerminados = 0;
        public static int AlumnosConCreditosPendientes = 0;
        public static int AlumnosConCreditosUrge = 0;
        public static string rutaConfig = @".\config.txt";
        public static Conexion miConexion;
        public static bool salirTesteo = false;
        public static void CrearConexion()
        {
            try
            {
                string[] datosDeConexion = System.IO.File.ReadAllLines(rutaConfig);
                miConexion = new Conexion(datosDeConexion[0], datosDeConexion[1], datosDeConexion[2], datosDeConexion[3], datosDeConexion[4]);
            }
            catch { MessageBox.Show("ERROR EN EL ARCHIVO CONFIG.TXT \nPUEDE QUE:\n\n -> Se encuentre abierto el archivo \n->No respeta las 5 lineas que debe tiener \n-> No se encuentra el archivo"); Environment.Exit(0); }
        }
}



}
