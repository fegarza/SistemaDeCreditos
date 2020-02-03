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
    public partial class Logs : Form
    {
        List<Registro> registros = Nucleo.miConexion.MostrarLogs();

        public Logs()
        {
            InitializeComponent();



            foreach(Registro x in registros)
            {
                dataGridView1.Rows.Add(x.ID.ToString(),Nucleo.miConexion.MostrarNombreDeUsuario(x.UserID.ToString()), x.Contenido, x.Fecha.ToString());
            }


        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            Nucleo.miConexion.BorrarLogs();

            registros.Clear();
            registros = Nucleo.miConexion.MostrarLogs();

            dataGridView1.Rows.Clear();
            foreach (Registro x in registros)
            {
                dataGridView1.Rows.Add(x.ID.ToString(), Nucleo.miConexion.MostrarNombreDeUsuario(x.UserID.ToString()), x.Contenido, x.Fecha.ToString());
            }
        }
    }
}
