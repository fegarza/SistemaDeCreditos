using SistemaDeCreditos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeCreditos.Forms
{
    public partial class Reportes : Form
    {
        List<Reporte> misReportes = new List<Reporte>();
        public Reportes()
        {
            InitializeComponent();
            CargarReportes();
            cbCarrera.DataSource = Nucleo.miConexion.MostrarCarreras();
            lbReportes.DataSource = misReportes;

        }
        public void CargarReportes()
        {
             misReportes = Nucleo.miConexion.MostrarReportes();
            lbReportes.DataSource = misReportes;

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if(lbReportes.SelectedIndex >= 0)
            {
                PDF.ExportarReporte(Nucleo.miConexion.MostrarReporteEspecifico(misReportes[lbReportes.SelectedIndex].ID.ToString()), dtFecha.Value.ToString("dd/MM/yyyy"));
            }


        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if(cbCarrera.SelectedIndex >= 0 && cbSemestre.SelectedIndex >= 0)
            {
                if(Nucleo.miConexion.NuevoReporte(tbTitulo.Text, Nucleo.miConexion.BuscarIDDeCarrera(cbCarrera.SelectedItem.ToString()), (cbSemestre.SelectedIndex - 1)))
                {
                PDF.ExportarReporte(Nucleo.miConexion.MostrarReporteEspecifico(Nucleo.miConexion.MostrarUltimoReporteID()), DateTime.Now.ToString(("dd/MM/yyyy")));
                    CargarReportes();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado a ningun alumno con sus 5 créditos recientemente registrados");
                }

                //   MessageBox.Show(cbCarrera.SelectedItem.ToString() + " " + cbSemestre.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Datos incompletos");
            }
        }

        private void cbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
