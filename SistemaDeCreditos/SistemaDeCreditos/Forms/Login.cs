using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaDeCreditos.Clases;
using System.Threading;

namespace SistemaDeCreditos.Forms
{
    public partial class Login : Form
    {
         public Login()
        {

            Nucleo.CrearConexion();
            while (!(Nucleo.miConexion.TestearConexiones() == "No se encuentra ningun error"))
            {
                MessageBox.Show("Se encuentran errores de conexion, favor de revizar los datos de acceso");
                Configuracion miConfiguracion = new Configuracion();
                miConfiguracion.ShowDialog();
                if (Nucleo.salirTesteo == true)
                {
                    Environment.Exit(0);
                }
            }

            InitializeComponent();
            try
            {
                List<string> usuarios = Nucleo.miConexion.MostrarUsuarios();
                foreach (string x in usuarios)
                {
                    cbUsuario.Items.Add(x);
                }
            }
            catch
            {
                MessageBox.Show("ERROR: NO EXISTE LA TABLA DE USUARIOS EN LA BASE DE DATOS DE SQL SERVER");
                Environment.Exit(1);
            }



        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario miUsuario = Nucleo.miConexion.BuscarUsuario(cbUsuario.Text, tbClave.Text);
            Nucleo.UsuarioLogueado = miUsuario;
            if (miUsuario != null)
            {
                Task<int> AlumnosConCreditosPendientes = new Task<int>(Nucleo.miConexion.ContarAlumnosConCreditosPendientes);
                AlumnosConCreditosPendientes.Start();

                Task<int> AlumnosConCreditosTerminados = new Task<int>(Nucleo.miConexion.ContarAlumnosConCreditosTerminados);
                AlumnosConCreditosTerminados.Start();

                Task<int> AlumnosConCreditosUrge = new Task<int>(Nucleo.miConexion.ContarAlumnosConCreditosPendientesUrgentes);
                AlumnosConCreditosUrge.Start();
                this.FormBorderStyle = FormBorderStyle.None;
                 pnLoad.Visible = true;
                Nucleo.AlumnosConCreditosPendientes = await AlumnosConCreditosPendientes;
                Nucleo.AlumnosConCreditosTerminados = await AlumnosConCreditosTerminados;
                Nucleo.AlumnosConCreditosUrge = await AlumnosConCreditosUrge;


               
                this.Hide();
                Menu miMenu = new Menu();
                miMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos incorrectos, intentelo nuevamente");
               }
        }

        public void ContarDatos()
        {
         }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbClave_OnValueChanged(object sender, EventArgs e)
        {
            if (tbClave.Text == "Introduzca su clave de usuario")
            {
                tbClave.Text = "";
            }
        }

        private void tbClave_Click(object sender, EventArgs e)
        {
            if(tbClave.Text == "Introduzca su clave de usuario")
            {
                tbClave.Text = "";
            }
        }

        private void pnLoad_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void tbClave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Usuario miUsuario = Nucleo.miConexion.BuscarUsuario(cbUsuario.Text, tbClave.Text);
                Nucleo.UsuarioLogueado = miUsuario;
                if (miUsuario != null)
                {
                    Task<int> AlumnosConCreditosPendientes = new Task<int>(Nucleo.miConexion.ContarAlumnosConCreditosPendientes);
                    AlumnosConCreditosPendientes.Start();

                    Task<int> AlumnosConCreditosTerminados = new Task<int>(Nucleo.miConexion.ContarAlumnosConCreditosTerminados);
                    AlumnosConCreditosTerminados.Start();

                    Task<int> AlumnosConCreditosUrge = new Task<int>(Nucleo.miConexion.ContarAlumnosConCreditosPendientesUrgentes);
                    AlumnosConCreditosUrge.Start();
                    this.FormBorderStyle = FormBorderStyle.None;
                    pnLoad.Visible = true;
                    Nucleo.AlumnosConCreditosPendientes = await AlumnosConCreditosPendientes;
                    Nucleo.AlumnosConCreditosTerminados = await AlumnosConCreditosTerminados;
                    Nucleo.AlumnosConCreditosUrge = await AlumnosConCreditosUrge;



                    this.Hide();
                    Menu miMenu = new Menu();
                    miMenu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos, intentelo nuevamente");
                }
            }
        }
    }
}
