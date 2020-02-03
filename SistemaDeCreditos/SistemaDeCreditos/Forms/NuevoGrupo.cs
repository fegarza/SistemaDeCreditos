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
    public partial class NuevoGrupo : Form
    {
        List<Personal> personal = new List<Personal>();
        List<Actividad> actividades = new List<Actividad>();
        Grupo miGrupo = null;
        bool modificar = false;
        string GrupoID;


        public NuevoGrupo()
        {
            InitializeComponent();


            if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.Rol == "Supervisor")
            {
                personal = Nucleo.miConexion.MostrarPersonal();
                foreach (Personal x in personal)
                {
                    cbResponsable.Items.Add(x.Nombre + " " + x.Apellidos);
                }
            }
            else
            {
                personal.Add(Nucleo.miConexion.TraerPersonalEnEspecifico(Nucleo.UsuarioLogueado.PersonalClave.ToString()));
                foreach (Personal x in personal)
                {
                    cbResponsable.Items.Add(x.Nombre + " " + x.Apellidos);
                }
            }

                



            actividades = Nucleo.miConexion.MostrarActividades();
            foreach (Actividad x in actividades)
            {
                cbActividad.Items.Add(x.Nombre);
            }

        }

        public NuevoGrupo(string _grupoID)
        {
            modificar = true;
            InitializeComponent();

            lblActividad.Visible = false;
            cbActividad.Visible = false;

            GrupoID = _grupoID;
            if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.Rol == "Supervisor")
            {
                personal = Nucleo.miConexion.MostrarPersonal();
                foreach (Personal x in personal)
                {
                    cbResponsable.Items.Add(x.Nombre + " " + x.Apellidos);
                }
            }
            else
            {
                personal.Add(Nucleo.miConexion.TraerPersonalEnEspecifico(Nucleo.UsuarioLogueado.PersonalClave.ToString()));
                foreach (Personal x in personal)
                {
                    cbResponsable.Items.Add(x.Nombre + " " + x.Apellidos);
                }
            }
            actividades = Nucleo.miConexion.MostrarActividades();
            foreach (Actividad x in actividades)
            {
                cbActividad.Items.Add(x.Nombre);
            }

            miGrupo =  Nucleo.miConexion.MostrarUnGrupoEnEspecifico(_grupoID);
            tbLimite.Text = miGrupo.Cupo.ToString();
            tbTitulo.Text = miGrupo.Titulo;
            btnCrear.Text = "MODIFICAR";

        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            

            if (modificar)
            {
                if (String.IsNullOrEmpty(tbLimite.Text) || String.IsNullOrEmpty(tbTitulo.Text) || String.IsNullOrEmpty(cbResponsable.Text) || String.IsNullOrEmpty(tbAño.Text) || String.IsNullOrEmpty(cbSemestre.Text))
                {
                    MessageBox.Show("Hace falta llenar un campo, porfavor verifique bein el cuestionario");
                }
                else
                {
                    if (tbAño.Text.Length == 4)
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
                        Nucleo.miConexion.EditarGrupo(tbTitulo.Text, tbLimite.Text, personal[cbResponsable.SelectedIndex].Clave.ToString(), Periodostr, GrupoID);
                        Nucleo.miConexion.InsertarNuevoLog("ha modificado el grupo: " + tbTitulo.Text + " que tiene como identificador: " + GrupoID.ToString());
                        MessageBox.Show("Se ha modificado el grupo con exito!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El año no es correcto");
                    }
                                    
                }
               
            }
            else
            {
                if (String.IsNullOrEmpty(tbLimite.Text) || String.IsNullOrEmpty(tbTitulo.Text) || String.IsNullOrEmpty(cbActividad.Text) || String.IsNullOrEmpty(cbResponsable.Text))
                {
                    MessageBox.Show("Hace falta llenar un campo, porfavor verifique bein el cuestionario");
                }
                else
                {
                    if (tbAño.Text.Length == 4)
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
                        Nucleo.miConexion.InsertarNuevoGrupo(tbTitulo.Text, actividades[cbActividad.SelectedIndex].ID.ToString(), tbLimite.Text, personal[cbResponsable.SelectedIndex].Clave.ToString(), Periodostr);
                        Nucleo.miConexion.InsertarNuevoLog("ha creado el grupo: " + tbTitulo.Text);
                        MessageBox.Show("Se ha creado el grupo con exito!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El año no es correcto");
                    }
                }
               
            }
           
        }

        private void tbLimite_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(tbLimite.Text);
            }
            catch
            {
                tbLimite.Text = "";
            }
        }

        private void NuevoGrupo_Load(object sender, EventArgs e)
        {

        }
    }
}
