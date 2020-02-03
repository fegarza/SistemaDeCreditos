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
    public partial class NuevaActividad : Form
    {
        /*
            -> VARIABLES GLOBALES 
        */
        #region VARIABLES GLOBALES

        //Listas para jugar con los combobox del form
        List<Personal> PersonalLista;
        List<Personal> Jefes;
        List<Seccion> SeccionesDisponibles = new List<Seccion>();
        List<Actividad> actividadesDisponibles = new List<Actividad>();
        //Banderas
        bool ModoEditar = false;
        bool PrimeraVez = true;
        bool ContarCeroDeActividad = false;
        //Datos a jugar
        string numeroDeControl;
        int AnteriorActividadID = 0;
        int AnteriorSeccionID = 0;
        int CreditoEditarID = 0;

        #endregion

        /*
            -> CONSTRUCTORES 
        */
        #region CONSTRUCTOR EN CASO DE EDITAR UNA ACTIVIDAD

        public NuevaActividad(string _numeroDeControl, int _creditoID, int _seccionID, int _actividadID, int _responsableID, int _jefeID, DateTime _fechaOficio, int _periodo)
        {
            InitializeComponent();

            //ASIGNACION DE VARIABLES
            ModoEditar = true;  
            this.Text = "Editar actividad";
            lblTitulo.Text = "EDITAR ACTIVIDAD";
            btnGuardar.Text = "EDITAR";
            AnteriorActividadID = _actividadID;
            AnteriorSeccionID = _seccionID;
            CreditoEditarID = _creditoID;
            numeroDeControl = _numeroDeControl;
            SeccionesDisponibles = Nucleo.miConexion.MostrarSeccionesDisponibles(_numeroDeControl);
            
            //OBTENER LAS SECCIONES DISPONIBLES
            cbSeccion.Items.Add(Nucleo.miConexion.ConsutlarNombreSeccion(_seccionID.ToString()));
            foreach (Seccion x in SeccionesDisponibles)
            {
                cbSeccion.Items.Add(x.Nombre + " (Creditos permitidos por seccion: " + x.Peso + " )");
            }

            //PONER POR DEFAULT LA ACTIVIDAD QUE SE TENIA ANTERIORMENTE
            cbActividad.Items.Add(Nucleo.miConexion.ConsutlarNombreActividad(_actividadID.ToString()));
            cbSeccion.SelectedIndex = 0;
            cbActividad.SelectedIndex = 0;


            //ESTABLECER PERMISOS DE USUARIO
            if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.Rol == "Supervisor")
            {
                PersonalLista = Nucleo.miConexion.MostrarPersonal();
            }
            else
            {
                PersonalLista = new List<Personal>();
                PersonalLista.Add(new Personal(Nucleo.UsuarioLogueado.Nombre, Nucleo.UsuarioLogueado.Apellidos, Nucleo.UsuarioLogueado.PersonalClave));

            }

            //ESTABLECER DATOS ANTERIORES CON RESPECTO AL PERSONAL
            int ResponsablelSeleccionadoAnteriormente = 0;
            int count = -1;

            foreach (Personal x in PersonalLista)
            {
                count++;
                cbResponsable.Items.Add(x.Nombre + " " + x.Apellidos);
                if (x.Clave == _responsableID)
                {
                    ResponsablelSeleccionadoAnteriormente = count;
                }
            }

            cbResponsable.SelectedIndex = ResponsablelSeleccionadoAnteriormente;
            cbJefes.Items.Clear();
            Jefes = Nucleo.miConexion.MostrarPersonal();
            int JefeSeleccionadoAnteriormente = 0;
            count = -1;

            foreach (Personal x in Jefes)
            {
                count++;
                cbJefes.Items.Add(x.Nombre + " " + x.Apellidos);
                if (x.Clave == _jefeID)
                {
                    JefeSeleccionadoAnteriormente = count;
                }
            }

            cbJefes.SelectedIndex = JefeSeleccionadoAnteriormente;
            int ultimoID = Jefes.Count - 1;
            dtOficio.Text = _fechaOficio.ToShortDateString();
            tbAño.Text = "20" + _periodo.ToString()[1] + _periodo.ToString()[2];

            switch (_periodo.ToString()[3])
            {
                case '1':
                    cbSemestre.SelectedIndex = 0;
                    break;
                case '2':
                    cbSemestre.SelectedIndex = 1;
                    break;
                case '3':
                    cbSemestre.SelectedIndex = 2;
                    break;
            }

        }

        #endregion

        #region CONSTRUCTOR PARA AGREGAR UNA NUEVA ACTIVIDAD

        public NuevaActividad(string _numeroDeControl)
        {
            InitializeComponent();
            numeroDeControl = _numeroDeControl;
            SeccionesDisponibles = Nucleo.miConexion.MostrarSeccionesDisponibles(_numeroDeControl);
            foreach (Seccion x in SeccionesDisponibles)
            {
                cbSeccion.Items.Add(x.Nombre + " (Creditos permitidos por seccion: " + x.Peso + " )");
            }


            if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.Rol == "Supervisor")
            {
                PersonalLista = Nucleo.miConexion.MostrarPersonal();

            }
            else
            {
                PersonalLista = new List<Personal>();
                PersonalLista.Add(new Personal(Nucleo.UsuarioLogueado.Nombre, Nucleo.UsuarioLogueado.Apellidos, Nucleo.UsuarioLogueado.PersonalClave));
            }
            foreach (Personal x in PersonalLista)
            {
                cbResponsable.Items.Add(x.Nombre + " " + x.Apellidos);
            }

        }

        #endregion



        /*
            -> EVENTOS DE CONTROLES
        */
        #region COMBOBOX EVENTOS
        private void cbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModoEditar)
            {
                if (PrimeraVez)
                {
                    PrimeraVez = false;
                }
                else
                {
                    cbActividad.Items.Clear();
                    ContarCeroDeActividad = true;
                }
                if (cbSeccion.SelectedIndex == 0)
                {
                    actividadesDisponibles = Nucleo.miConexion.MostrarActividadesDisponibles(numeroDeControl, AnteriorSeccionID.ToString());
                }
                else
                {
                    actividadesDisponibles = Nucleo.miConexion.MostrarActividadesDisponibles(numeroDeControl, SeccionesDisponibles[cbSeccion.SelectedIndex - 1].ID.ToString());

                }
            }
            else
            {
                cbActividad.Items.Clear();
                actividadesDisponibles = Nucleo.miConexion.MostrarActividadesDisponibles(numeroDeControl, SeccionesDisponibles[cbSeccion.SelectedIndex].ID.ToString());

            }


            foreach (Actividad x in actividadesDisponibles)
            {
                cbActividad.Items.Add(x.Nombre + " (Peso: " + x.Peso + " )");
            }
        }
        private void cbActividad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbJefes.Items.Clear();
            Jefes = Nucleo.miConexion.ConsultarPosiblesJefes(PersonalLista[cbResponsable.SelectedIndex].Clave.ToString());

            foreach (Personal x in Jefes)
            {
                cbJefes.Items.Add(x.Nombre + " " + x.Apellidos);
            }

            if (Jefes.Count > 0)
            {
                cbJefes.SelectedIndex = cbJefes.Items.Count -1;
            }

        }
        private void cbJefes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region  TEXTBOX EVENTOS
        private void tbAño_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(tbAño.Text);
                if(tbAño.Text.Count() > 4)
                {
                    tbAño.Text = tbAño.Text[0].ToString() + tbAño.Text[1].ToString() + tbAño.Text[2].ToString() + tbAño.Text[3].ToString();
                }
            }
            catch
            {
                tbAño.Text = "";
            }
        }
        #endregion

        #region BOTONES EVENTOS
        private void btnTodo_Click(object sender, EventArgs e)
        {
            cbJefes.Items.Clear();
            Jefes = Nucleo.miConexion.MostrarPersonal();

            foreach (Personal x in Jefes)
            {
                cbJefes.Items.Add(x.Nombre + " " + x.Apellidos);
            }

            int ultimoID = Jefes.Count - 1;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (tbAño.Text.Length == 4)
            {

                if (String.IsNullOrEmpty(cbJefes.Text) || String.IsNullOrEmpty(tbAño.Text) || String.IsNullOrEmpty(cbSemestre.Text) || String.IsNullOrEmpty(cbResponsable.Text) || String.IsNullOrEmpty(cbActividad.Text) || String.IsNullOrEmpty(cbSeccion.Text))
                {
                    MessageBox.Show("No debe haber datos vacios");
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





                    /* 
                     * 
                     *DESCOMENTAR EN CASO DE MANTENIMIENTO 
                     * 
                    MessageBox.Show(String.Format("Seccion: \n{0}, \nSeccionID{1}, \nActividad: {2} ,\nActividad ID: {3},  \nResponsable: {4},\n ResponsableID {5},\n Jefe : {6}, \nJefeID: {7}",
                        SeccionesDisponibles[cbSeccion.SelectedIndex].Nombre,
                        SeccionesDisponibles[cbSeccion.SelectedIndex].ID,
                        actividadesDisponibles[cbActividad.SelectedIndex].Nombre,
                        actividadesDisponibles[cbActividad.SelectedIndex].ID,
                        PersonalLista[cbResponsable.SelectedIndex].Nombre,
                        PersonalLista[cbResponsable.SelectedIndex].Clave,
                        Jefes[cbJefes.SelectedIndex].Nombre,
                        Jefes[cbJefes.SelectedIndex].Clave
                        ));
                        */

                    if (ModoEditar)
                    {

                        int NuevaActividadID = 0;
                        if (!ContarCeroDeActividad)
                        {
                            if (cbActividad.SelectedIndex == 0)
                            {
                                NuevaActividadID = AnteriorActividadID;
                            }
                            else
                            {
                                NuevaActividadID = actividadesDisponibles[cbActividad.SelectedIndex - 1].ID;
                            }
                        }
                        else
                        {
                            NuevaActividadID = actividadesDisponibles[cbActividad.SelectedIndex].ID;
                        }
                        Nucleo.miConexion.ActualizarActividad(
                        CreditoEditarID.ToString(),
                        dtOficio.Value.Date.ToString("yyyyMMdd"),
                        NuevaActividadID,
                        int.Parse(Periodostr),
                        PersonalLista[cbResponsable.SelectedIndex].Clave,
                        Jefes[cbJefes.SelectedIndex].Clave
                        );
                        Nucleo.miConexion.InsertarNuevoLog("ha modificado el crédito: " + CreditoEditarID.ToString() + " del alumno " + Nucleo.miConexion.ConsultarNombreDeAlumno(numeroDeControl) + " número de control: " + numeroDeControl.ToString());
                        MessageBox.Show("Se ha actualizado la actividad!");
                        this.Close();
                    }
                    else
                    {
                        Nucleo.miConexion.InsertarActividad(
                                                numeroDeControl,
                                                dtOficio.Value.Date.ToString("yyyyMMdd"),
                                                actividadesDisponibles[cbActividad.SelectedIndex].ID,
                                                int.Parse(Periodostr),
                                                PersonalLista[cbResponsable.SelectedIndex].Clave,
                                                Jefes[cbJefes.SelectedIndex].Clave,
                                                Nucleo.miConexion.ConsultarCarreraDelEstudiante(numeroDeControl)
                                                );
                        Nucleo.miConexion.InsertarNuevoLog("ha insertado el crédito: " + CreditoEditarID.ToString() + " del alumno " + Nucleo.miConexion.ConsultarNombreDeAlumno(numeroDeControl) + " número de control: " + numeroDeControl.ToString());
                        MessageBox.Show("Se ha insertado la nueva actividad!");
                        this.Close();
                    }

                }


            }
            else
            {
                MessageBox.Show("El año debe tener solo 4 digitos");
            }



            //Nucleo.miConexion.InsertarActividad(numeroDeControl,dtOficio.ToString(),)

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
       

    }
}
