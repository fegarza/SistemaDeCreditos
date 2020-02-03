using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaDeCreditos.Forms
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();

            tbRuta.Text = Nucleo.miConexion.SemiRuta;
            tbClave.Text = Nucleo.miConexion.Clave;
            tbServidor.Text = Nucleo.miConexion.Server;
            tbUsuario.Text = Nucleo.miConexion.Usuario;
            tbBaseDeDatos.Text = Nucleo.miConexion.BD;
        }

        private void btnTestear_Click(object sender, EventArgs e)
        {
            EstablecerDatosDeConexion(tbRuta.Text, tbServidor.Text, tbBaseDeDatos.Text, tbUsuario.Text, tbClave.Text);
            Nucleo.CrearConexion();
            if(Nucleo.miConexion.TestearConexiones() == "No se encuentra ningun error")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(Nucleo.miConexion.TestearConexiones());
            }
            
        }


        public void EstablecerDatosDeConexion(string _ruta, string _server, string _baseDeDatos, string _usuario, string _clave)
        {
            if (File.Exists(Nucleo.rutaConfig))
            {
                File.Delete(Nucleo.rutaConfig);
            }
            StreamWriter mylogs = File.AppendText(Nucleo.rutaConfig);
            mylogs.WriteLine(_server);
            mylogs.WriteLine(_baseDeDatos);
            mylogs.WriteLine(_usuario);
            mylogs.WriteLine(_clave);
            mylogs.WriteLine(_ruta);
            mylogs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nucleo.salirTesteo = true;
            this.Close();
        }
    }

}