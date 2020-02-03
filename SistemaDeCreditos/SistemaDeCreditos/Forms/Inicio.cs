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
 


namespace SistemaDeCreditos.Forms
{
    public partial class Inicio : Form
    {
      
        public Inicio()
        {
            


            InitializeComponent();

            //Notificaciones
            lblAlumnosCreditosTerminados.Text =  Nucleo.AlumnosConCreditosTerminados.ToString();
            lblAlumnosCreditosPendientes.Text = Nucleo.AlumnosConCreditosPendientes.ToString();
            lblAlumnosCreditosUrge.Text =Nucleo.AlumnosConCreditosUrge.ToString();
            lblGruposCreados.Text = Nucleo.miConexion.ContarGrupos().ToString();
            lblPersonalCreado.Text = Nucleo.miConexion.ContarUsuarios().ToString();



            lblUsuarioLogueadoNombre.Text =   Nucleo.UsuarioLogueado.Nombre + Nucleo.UsuarioLogueado.Apellidos;
            lblID.Text =  Nucleo.UsuarioLogueado.PersonalClave.ToString();
            lblNivel.Text =  Nucleo.UsuarioLogueado.Rol.ToString();
            lblDepartamento.Text =  Nucleo.miConexion.BuscarNombreDepartamento(Nucleo.UsuarioLogueado.DepartamentoID.ToString());


            if (Nucleo.UsuarioLogueado.Genero == "H")
            {
 
            }
            else
            {
               

            }
        }

      

        private void lblUsuarioLogueadoNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblPuesto_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnUsuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVerManual_Click(object sender, EventArgs e)
        {
            Clases.PDF.AbrirManual();
        }

        private void pnBody_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
