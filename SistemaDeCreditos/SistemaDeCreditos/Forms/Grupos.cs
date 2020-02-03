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
    public partial class Grupos : Form
    {

        List<Grupo> grupos = null;
        List<Estudiante> estudiantes = new List<Estudiante>();

        public Grupos()
        {
            InitializeComponent();
            cbPeriodos.DataSource = Nucleo.miConexion.MostrarPeriodosGrupos();
            /*
            grupos = Nucleo.miConexion.MostrarGrupos();
            foreach (Grupo n in grupos)
            {
                lbGrupos.Items.Add(n.Titulo);
            }*/

        }

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {

        }

        private void lbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblPeriodo.Text = grupos[lbGrupos.SelectedIndex].Periodo;
                lblNombreGrupo.Text = grupos[lbGrupos.SelectedIndex].Titulo.ToUpper();
                lblActividadTitulo.Text = Nucleo.miConexion.ConsutlarNombreActividad(grupos[lbGrupos.SelectedIndex].ActividadID.ToString());
                lblResponsable.Text = Nucleo.miConexion.ConsultarNombreCompletoDePersonal(grupos[lbGrupos.SelectedIndex].ResponsableID.ToString());
                lblLimite.Text = grupos[lbGrupos.SelectedIndex].Cupo.ToString();
                estudiantes.Clear();
                lbEstudiantes.Items.Clear();
                estudiantes = Nucleo.miConexion.MostrarEstudiantesDeUnGrupo(grupos[lbGrupos.SelectedIndex].ID.ToString());
                foreach (Estudiante x in estudiantes)
                {
                    lbEstudiantes.Items.Add(x.NumeroDeControl);
                }
                lblAlumnos.Text = "Alumnos: " + lbEstudiantes.Items.Count;
                if (lbEstudiantes.Items.Count == 0)
                {
                    btnCalificar.Visible = false;
                    btnExportar.Visible = false;
                }
                else
                {
                    btnCalificar.Visible = true;
                    btnExportar.Visible = true;
                }
                pnDatos.Visible = true;
                pnAlumnoTop.Visible = false;
                tbAlumno.Visible = false;
                if(grupos[lbGrupos.SelectedIndex].Conteo >= grupos[lbGrupos.SelectedIndex].Cupo)
                {
                    btnAgregarAlumnos.Visible = false;
                }
                else
                {
                    btnAgregarAlumnos.Visible = true;
                }
            }
            catch
            {

            }
        }

        private void lbEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbNombreDeAlumno.Text = estudiantes[lbEstudiantes.SelectedIndex].Nombre + " " + estudiantes[lbEstudiantes.SelectedIndex].ApellidoPaterno + " " + estudiantes[lbEstudiantes.SelectedIndex].ApellidoMaterno;
                pnAlumnoTop.Visible = true;
                tbAlumno.Visible = true;
                pnAlumno.Visible = true;
            }
            catch { }
        
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.PersonalClave == grupos[lbGrupos.SelectedIndex].ResponsableID || Nucleo.UsuarioLogueado.Rol == "Supervisor")
            {
                if (MessageBox.Show("¿Estas seguro de sacar a este alumno del grupo ?", "Sacar alumno del grupo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    Nucleo.miConexion.EliminarAlumnoDeUnGrupo(estudiantes[lbEstudiantes.SelectedIndex].NumeroDeControl, grupos[lbGrupos.SelectedIndex].ID.ToString());
                    Nucleo.miConexion.InsertarNuevoLog("ha sacado a " + Nucleo.miConexion.ConsultarNombreDeAlumno(estudiantes[lbEstudiantes.SelectedIndex].NumeroDeControl) + " con el número de control: " + estudiantes[lbEstudiantes.SelectedIndex].NumeroDeControl + " del grupo de: " + grupos[lbGrupos.SelectedIndex].Titulo);
                    try
                    {
                        estudiantes.Clear();
                        lbEstudiantes.Items.Clear();
                        estudiantes = Nucleo.miConexion.MostrarEstudiantesDeUnGrupo(grupos[lbGrupos.SelectedIndex].ID.ToString());

                        foreach (Estudiante x in estudiantes)
                        {
                            lbEstudiantes.Items.Add(x.NumeroDeControl);
                        }

                        lblAlumnos.Text = "Alumnos: " + lbEstudiantes.Items.Count;
                        grupos[lbGrupos.SelectedIndex].Conteo = estudiantes.Count();
                        lblAlumnos.Text = $"Alumnos: { grupos[lbGrupos.SelectedIndex].Conteo.ToString()}";
                        if (grupos[lbGrupos.SelectedIndex].Conteo >= grupos[lbGrupos.SelectedIndex].Cupo)
                        {
                            btnAgregarAlumnos.Visible = false;
                        }
                        else
                        {
                            btnAgregarAlumnos.Visible = true;
                        }
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.ToString());
                    }
                    pnAlumno.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("No tienes permiso de editar a los alumnos de este grupo");
            }


        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            Estudiantes bs = new Estudiantes(estudiantes[lbEstudiantes.SelectedIndex].NumeroDeControl);
            bs.ShowDialog();
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            NuevoGrupo xd = new NuevoGrupo();
            xd.ShowDialog();
            //lbGrupos.Items.Clear();
            // grupos.Clear();
            //grupos = Nucleo.miConexion.MostrarGrupos();
            // foreach (Grupo n in grupos)
            //{
            //   lbGrupos.Items.Add(n.Titulo);
            //}
            lbGrupos.Items.Clear();
            cbPeriodos.DataSource = Nucleo.miConexion.MostrarPeriodosGrupos();
            pnDatos.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.PersonalClave == grupos[lbGrupos.SelectedIndex].ResponsableID || Nucleo.UsuarioLogueado.Rol == "Supervisor")
                {

                    NuevoGrupo xd = new NuevoGrupo(grupos[lbGrupos.SelectedIndex].ID.ToString());
                    xd.ShowDialog();
                    //lbGrupos.Items.Clear();
                    /* grupos.Clear();
                     grupos = Nucleo.miConexion.MostrarGrupos();
                     foreach (Grupo n in grupos)
                     {
                         lbGrupos.Items.Add(n.Titulo);
                     }*/
                    lbGrupos.Items.Clear();
                    cbPeriodos.DataSource = Nucleo.miConexion.MostrarPeriodosGrupos();
                    pnDatos.Visible = false;

                }
                else
                {
                    MessageBox.Show("No tienes permiso para editar este grupo");
                }
            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.PersonalClave == grupos[lbGrupos.SelectedIndex].ResponsableID || Nucleo.UsuarioLogueado.Rol == "Supervisor")
                {
                    if (MessageBox.Show("¿Estas seguro de eliminar este grupo ?", "Eliminar grupo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        Nucleo.miConexion.EliminarGrupo(grupos[lbGrupos.SelectedIndex].ID.ToString());
                        Nucleo.miConexion.InsertarNuevoLog("ha borrado el grupo: " + grupos[lbGrupos.SelectedIndex].Titulo + " que tiene como identificador: " + grupos[lbGrupos.SelectedIndex].ID);
                        lbGrupos.Items.Clear();
                        cbPeriodos.DataSource = Nucleo.miConexion.MostrarPeriodosGrupos();
                        //grupos.Clear();
                        //grupos = Nucleo.miConexion.MostrarGrupos();
                        /*foreach (Grupo n in grupos)
                        {
                            lbGrupos.Items.Add(n.Titulo);
                        }*/
                        pnDatos.Visible = false;

                    }
                }
                else
                {
                    MessageBox.Show("No tienes permisos para eliminar este grupo");
                }
            }
            catch { }

        }

        private void pnDatosCont_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            PDF pdf = new PDF();
            pdf.ExportarGrupo(estudiantes, grupos[lbGrupos.SelectedIndex].Titulo, Nucleo.miConexion.ConsutlarNombreActividad(grupos[lbGrupos.SelectedIndex].ActividadID.ToString()), Nucleo.miConexion.ConsultarNombreCompletoDePersonal(grupos[lbGrupos.SelectedIndex].ResponsableID.ToString()));
        }

        private void btnAgregarAlumnos_Click(object sender, EventArgs e)
        {
            AgregarAlumnos agAlumnos = new AgregarAlumnos(grupos[lbGrupos.SelectedIndex].ID.ToString());
            agAlumnos.ShowDialog();
            estudiantes.Clear();
            lbEstudiantes.Items.Clear();
            estudiantes = Nucleo.miConexion.MostrarEstudiantesDeUnGrupo(grupos[lbGrupos.SelectedIndex].ID.ToString());
            foreach (Estudiante x in estudiantes)
            {
                lbEstudiantes.Items.Add(x.NumeroDeControl);
            }
            grupos[lbGrupos.SelectedIndex].Conteo = estudiantes.Count();
            lblAlumnos.Text = $"Alumnos: { grupos[lbGrupos.SelectedIndex].Conteo.ToString()}";

            if (grupos[lbGrupos.SelectedIndex].Conteo >= grupos[lbGrupos.SelectedIndex].Cupo)
            {
                btnAgregarAlumnos.Visible = false;
            }
            else
            {
                btnAgregarAlumnos.Visible = true;
            }
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            CalificarGrupo cg = new CalificarGrupo(estudiantes, grupos[lbGrupos.SelectedIndex].ID);
            cg.ShowDialog();
        }

        private void cbPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbPeriodos.SelectedIndex != -1)
            {
                //MessageBox.Show(cbPeriodos.Items[cbPeriodos.SelectedIndex].ToString());
                lbGrupos.Items.Clear();
                grupos = Nucleo.miConexion.MostrarGruposPorPeriodo(cbPeriodos.Items[cbPeriodos.SelectedIndex].ToString());
                foreach (Grupo n in grupos)
                {
                    lbGrupos.Items.Add(n.Titulo);
                }
            }
        }
    }
}
