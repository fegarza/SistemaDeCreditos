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
    public partial class Asignar_grupo : Form
    {

        List<Grupo> grupos = null;
        String CreditoID;

        public Asignar_grupo(string _creditoID, string _actividadID)
        {
            InitializeComponent();
            CreditoID = _creditoID;
            grupos = Nucleo.miConexion.MostrarGruposPorActividad(_actividadID); 
            foreach(Grupo n in grupos)
            {
                cbGrupo.Items.Add(n.Titulo);
            }

            
        }
     

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbGrupo.Text))
            {
                MessageBox.Show("Debe seleccionar un grupo");
            }
            else {
                Nucleo.miConexion.AsignarGrupo(CreditoID, grupos[cbGrupo.SelectedIndex].ID.ToString());
                Nucleo.miConexion.InsertarNuevoLog("le ha asignado el grupo: " + cbGrupo.Text + " al credito: "+ CreditoID + " de: " + Nucleo.miConexion.ConsultarNombreDeAlumno(Nucleo.miConexion.ConsultarDuenoDelCredito(CreditoID.ToString())) + " con numero de control: " + Nucleo.miConexion.ConsultarDuenoDelCredito(CreditoID.ToString()));
                MessageBox.Show("Se ha guardado correctamente!");
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
