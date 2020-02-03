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
    public partial class SeleccionDeDepartamento : Form
    {
        List<Departamento> departamentosLista;
        public SeleccionDeDepartamento()
        {
            InitializeComponent();

            departamentosLista = Nucleo.miConexion.MostrarDepartamentos();
            
            foreach(Departamento x in departamentosLista)
            {
                cbDepartamentos.Items.Add(x.Nombre);
            }
            
        }

        

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbDepartamentos.Text))
            {
                MessageBox.Show("Complete los campos por favor");
            }
            else
            {
                Nucleo.departamentoJefeGenerado = departamentosLista[cbDepartamentos.SelectedIndex].Nombre;
                this.Close();
            }
        }

        private void cbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
