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
    public partial class CalificarGrupo : Form
    {
        List<Estudiante> Estudiantes = new List<Estudiante>();
        List<Estudiante> Seleccionados = new List<Estudiante>();

        int GrupoID;
        public CalificarGrupo(List<Estudiante> _estudiantes, int _GrupoID)
        {
            InitializeComponent();
            GrupoID = _GrupoID;
            foreach(Estudiante e in _estudiantes)
            {
                Estudiantes.Add(new Estudiante(e.NumeroDeControl, e.CarreraID, e.CreditosTerminados, e.CreditosPendientes));
                lbLeft.Items.Add(e.NumeroDeControl);
            }
        }

        private void lbLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Seleccionados.Add(new Estudiante(Estudiantes[lbLeft.SelectedIndex].NumeroDeControl, Estudiantes[lbLeft.SelectedIndex].CarreraID, Estudiantes[lbLeft.SelectedIndex].CreditosTerminados, Estudiantes[lbLeft.SelectedIndex].CreditosPendientes));
                Estudiantes.Remove(Estudiantes[lbLeft.SelectedIndex]);
                lbRight.Items.Add(lbLeft.Items[lbLeft.SelectedIndex]);
                lbLeft.Items.Remove(lbLeft.Items[lbLeft.SelectedIndex]);
            }
            catch { }
        }

        private void lbRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Estudiantes.Add(Seleccionados[lbRight.SelectedIndex]);
                Seleccionados.Remove(Seleccionados[lbRight.SelectedIndex]);
                lbLeft.Items.Add(lbRight.Items[lbRight.SelectedIndex]);
                lbRight.Items.Remove(lbRight.Items[lbRight.SelectedIndex]);
            }
            catch { }
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            if (Seleccionados.Count > 0)
            {
                Calificar mc = new Calificar(Seleccionados, GrupoID);
                mc.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("¡No se ha seleccionado ningún alumno para ser calificado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CalificarGrupo_Load(object sender, EventArgs e)
        {

        }

        private void btnQuitarATodos_Click(object sender, EventArgs e)
        {
            foreach(Estudiante s in Seleccionados)
            {
                Estudiantes.Add(new Estudiante(s.NumeroDeControl, s.CarreraID, s.CreditosTerminados, s.CreditosPendientes));
                lbLeft.Items.Add(s.NumeroDeControl);
            }
            Seleccionados.Clear();
            lbRight.Items.Clear();
        }

        private void btnAgregarATodos_Click(object sender, EventArgs e)
        {
            foreach (Estudiante s in Estudiantes)
            {
                Seleccionados.Add(new Estudiante(s.NumeroDeControl, s.CarreraID, s.CreditosTerminados, s.CreditosPendientes));
                lbRight.Items.Add(s.NumeroDeControl);
            }
            Estudiantes.Clear();
            lbLeft.Items.Clear();
        }
    }
}
