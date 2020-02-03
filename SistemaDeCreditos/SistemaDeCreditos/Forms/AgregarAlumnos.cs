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
    public partial class AgregarAlumnos : Form
    {

        List<string> numerosDeControl = new List<string>();
        Grupo grupoActual;
        List<Personal> Jefes;


        public AgregarAlumnos(string _grupoID)
        {
            InitializeComponent();
            grupoActual = Nucleo.miConexion.MostrarUnGrupoEnEspecifico(_grupoID);
            Jefes = Nucleo.miConexion.MostrarPersonal();
            foreach (Personal x in Jefes)
            {
                cbJefes.Items.Add($"{x.Nombre} {x.Apellidos}");
            }
        }

        private void AgregarAlumnos_Load(object sender, EventArgs e)
        {

        }

        public void ActualizarLista()
        {
            lbAlumnos.Items.Clear();
            foreach (string x in numerosDeControl)
            {
                lbAlumnos.Items.Add($"{x}");
            }
        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {

            if (numerosDeControl.Count >= (grupoActual.Cupo - grupoActual.Conteo))
            {
                MessageBox.Show("El grupo se ha llenado!");
            }
            else
            {


                if (Nucleo.miConexion.ConsultarExistenciaDeAlumno(tbNumControl.Text))
                {
                    if (Nucleo.miConexion.VerificarSiLlevaCiertaActividad(tbNumControl.Text, grupoActual.ActividadID.ToString()))
                    {
                        if (numerosDeControl.Exists(element => element == tbNumControl.Text))
                        {
                            MessageBox.Show("Ya existe un numero de control asi");
                        }
                        else
                        {
                            numerosDeControl.Add(tbNumControl.Text);
                            ActualizarLista();
                        }

                    }
                    else
                    {
                        if (Nucleo.miConexion.ConsultarCreditosTerminados(tbNumControl.Text) >= 5)
                        {
                            MessageBox.Show("No se puede agregar porque este alumno ya tiene todos sus creditos y se le es imposible agregar un actividad");
                        }
                        else
                        {
                            if (numerosDeControl.Exists(element => element == tbNumControl.Text))
                            {
                                MessageBox.Show("Ya existe un numero de control asi");
                            }
                            else
                            {
                                numerosDeControl.Add(tbNumControl.Text);
                                ActualizarLista();
                            }
                        }
                    }
                }
                else { MessageBox.Show("No existe alumno con ese número de control"); }
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbJefes.Text) || String.IsNullOrEmpty(dtOficio.Text) || String.IsNullOrEmpty(tbAño.Text) || String.IsNullOrEmpty(cbSemestre.Text))
            {
                MessageBox.Show("Favor de llenar todos los datos");
            }
            else
            {
                if (tbAño.Text.Length == 4)
                {
                    if (lbAlumnos.Items.Count > 0)
                    {

                        foreach (string x in numerosDeControl)
                        {
                            if (Nucleo.miConexion.VerificarSiLlevaCiertaActividad(x, grupoActual.ActividadID.ToString()))
                            {
                                Nucleo.miConexion.AsignarGrupo(Nucleo.miConexion.TraerIDDelCredito(x, grupoActual.ActividadID.ToString()).ToString(), grupoActual.ID.ToString());
                            }
                            else
                            {

                                string Periodostr = "2";
                                Periodostr = Periodostr + tbAño.Text[2].ToString() + tbAño.Text[3].ToString();
                                switch (cbSemestre.Text)
                                {
                                    case "ENERO - JUNIO":
                                        Periodostr = Periodostr + "1";
                                        break;
                                    case "VERANO":
                                        Periodostr = Periodostr + "2";

                                        break;
                                    case "AGOSTO - DICIEMBRE":
                                        Periodostr = Periodostr + "3";
                                        break;
                                }

                                Nucleo.miConexion.InsertarActividad(
                                                       x,
                                                       dtOficio.Value.Date.ToString("yyyyMMdd"),
                                                       grupoActual.ActividadID,
                                                       int.Parse(Periodostr),
                                                       grupoActual.ResponsableID,
                                                       Jefes[cbJefes.SelectedIndex].Clave,
                                                       Nucleo.miConexion.ConsultarCarreraDelEstudiante(x),
                                                       grupoActual.ID
                                                       );

                            }
                        }
                        MessageBox.Show("Se han agregado con exito los alumnos al grupo!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se ha introducido ningun alumno");
                    }
                }
                else
                {
                    MessageBox.Show("El año introducido no es correcto");
                }

            }
        }

        private void tbAño_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(tbAño.Text);
            }
            catch
            {
                tbAño.Text = "";
            }
        }

        private void lbAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbNumControl_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}