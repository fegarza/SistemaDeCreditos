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
    public partial class Menu : Form
    {
        #region TODO SOBRE LOS BOTONES DEL MENU

        //Banderas que me permiten saber si un boton esta activado
        bool btnInicioActivado = false;
        bool btnConsultarEstudianteActivado = false;
        bool btnAjustesActivado = false;
        bool btnReportesActivado = false;
        bool btnGruposActivado = false;
        bool btnLogsActivado = false;

        //Metodo para activar y desactivar banderas
        public void EstablecerActivoUnBoton(string _tipo)
        {
            btnInicioActivado = false;
            btnConsultarEstudianteActivado = false;
            btnAjustesActivado = false;
            btnReportesActivado = false;
            btnGruposActivado = false;
            btnLogsActivado = false;

            switch (_tipo)
            {
                case "inicio":
                    btnInicioActivado = true;
                    pnBtnConsultarEstudiante.Visible = false;
                    pnBtnAjustes.Visible = false;
                    pnBtnReportes.Visible = false;
                    pnBtnGrupos.Visible = false;
                    pnBtnLogs.Visible = false;
                    break;
                case "consultarEstudiantes":
                    btnConsultarEstudianteActivado = true;
                    pnBtnInicio.Visible = false;
                    pnBtnAjustes.Visible = false;
                    pnBtnReportes.Visible = false;
                    pnBtnGrupos.Visible = false;
                    pnBtnLogs.Visible = false;
                    break;
                case "ajustes":
                    btnAjustesActivado = true;
                    pnBtnInicio.Visible = false;
                    pnBtnConsultarEstudiante.Visible = false;
                    pnBtnReportes.Visible = false;
                    pnBtnGrupos.Visible = false;
                    pnBtnLogs.Visible = false;
                    break;
                case "reportes":
                    btnReportesActivado = true;
                    pnBtnInicio.Visible = false;
                    pnBtnConsultarEstudiante.Visible = false;
                    pnBtnAjustes.Visible = false;
                    pnBtnGrupos.Visible = false;
                    pnBtnLogs.Visible = false;
                    break;
                case "grupos":
                    btnGruposActivado = true;
                    pnBtnReportes.Visible = false;
                    pnBtnInicio.Visible = false;
                    pnBtnConsultarEstudiante.Visible = false;
                    pnBtnAjustes.Visible = false;
                    pnBtnLogs.Visible = false;
                    break;
                case "logs":
                    btnLogsActivado = true;
                    pnBtnGrupos.Visible = false;
                    pnBtnReportes.Visible = false;
                    pnBtnInicio.Visible = false;
                    pnBtnConsultarEstudiante.Visible = false;
                    pnBtnAjustes.Visible = false;
                    break;
            }
        }

        #region Acciones de los botones del menu
        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (!btnInicioActivado)
            {
                MostarPanel(new Inicio());
                EstablecerActivoUnBoton("inicio");

            }

        }
        private void btnConsultarEstudiantes_Click(object sender, EventArgs e)
        {
            if (!btnConsultarEstudianteActivado)
            {
                MostarPanel(new Estudiantes());
                EstablecerActivoUnBoton("consultarEstudiantes");
            }

        }
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (!btnAjustesActivado)
            {
                MostarPanel(new Ajustes());
                EstablecerActivoUnBoton("ajustes");
            }
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (!btnReportesActivado)
            {
                MostarPanel(new Reportes());
                EstablecerActivoUnBoton("reportes");
            }
        }
        #endregion




        //BTN INICIO
        private void btnInicio_MouseEnter(object sender, EventArgs e)
        {
            pnBtnInicio.Visible = true;
        }
        private void btnInicio_MouseLeave(object sender, EventArgs e)
        {
            if (!btnInicioActivado)
            {
                pnBtnInicio.Visible = false;
            }
        }

        //BTN CONSULTAR USUARIO
        private void btnConsultarEstudiante_MouseEnter(object sender, EventArgs e)
        {
            pnBtnConsultarEstudiante.Visible = true;
        }
        private void btnConsultarEstudiante_MouseLeave(object sender, EventArgs e)
        {
            if (!btnConsultarEstudianteActivado)
            {
                pnBtnConsultarEstudiante.Visible = false;
            }
        }

        //BTN AJUSTES
        private void btnConfiguracion_MouseEnter(object sender, EventArgs e)
        {
            pnBtnAjustes.Visible = true;
        }

        private void btnConfiguracion_MouseLeave(object sender, EventArgs e)
        {
            if (!btnAjustesActivado)
            {
                pnBtnAjustes.Visible = false;
            }
        }

        //BTN REPORTES
        private void btnReportes_MouseEnter(object sender, EventArgs e)
        {
            pnBtnReportes.Visible = true;
        }
        private void btnReportes_MouseLeave(object sender, EventArgs e)
        {
            if (!btnReportesActivado)
            {
                pnBtnReportes.Visible = false;
            }
        }
       
 
        #endregion

        

        public void MostarPanel(object _panel)
        {
            if (pnAll.Controls.Count > 0)
            {
                pnAll.Controls.RemoveAt(0);
            }

            Form mostrar = _panel as Form;
            mostrar.TopLevel = false;
            mostrar.Dock = DockStyle.Fill;
            pnAll.Controls.Add(mostrar);
            pnAll.Tag = mostrar;
            mostrar.Show();


            if(Nucleo.UsuarioLogueado.Genero == "H")
            {
                picMen.Visible = true;
                picWomen.Visible = false;
            }
            else
            {
                picWomen.Visible = true;
                picMen.Visible = false;

            }
        }


 
        public Menu()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            MostarPanel(new Inicio());
            EstablecerActivoUnBoton("inicio");
            pnBtnInicio.Visible = true;

            //Solo si tiene permisos de administrador podra ver dichas configuraciones 
            if(Nucleo.UsuarioLogueado.Rol == "Administrador")
            {
                panel7.Visible = true;
                panel2.Visible = true;
            }
            else
            {
                panel7.Visible = false;
                panel2.Visible = false;
            }

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (pnLeft.Width == 65)
            {
                pnLeft.Size = new System.Drawing.Size(290, 1043);

                btnResize.Text = "     Ocultar menú";
                btnInicio.Text = "     Inicio";
                btnConsultarEstudiante.Text = "     Consultar estudiante";
                btnGrupos.Text = "     Grupos";
                btnReportes.Text = "     Reportes";
                btnConfiguracion.Text = "     Configuración";
                btnLogs.Text = "     Registros";

                pnPic.Size = new System.Drawing.Size(290, 224);
            }
            else
            {
                pnLeft.Size = new System.Drawing.Size(65, 1043);

                pnPic.Size = new System.Drawing.Size(290, 80);
 
                btnResize.Text = "";
                btnInicio.Text = "";
                btnConsultarEstudiante.Text = "";
                btnGrupos.Text = "";
                btnReportes.Text = "";
                btnConfiguracion.Text = "";
                btnLogs.Text = "";
            }
           
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            if (!btnGruposActivado)
            {
                MostarPanel(new Grupos());
                EstablecerActivoUnBoton("grupos");
            }
            
        }


        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void btnGrupos_MouseEnter(object sender, EventArgs e)
        {
            pnBtnGrupos.Visible = true;
        }

        private void btnGrupos_MouseLeave(object sender, EventArgs e)
        {
            if (!btnGruposActivado)
            {
                pnBtnGrupos.Visible = false;
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            if (!btnLogsActivado)
            {
                MostarPanel(new Logs());
                EstablecerActivoUnBoton("logs");
            }
        }

        private void btnLogs_MouseEnter(object sender, EventArgs e)
        {
            pnBtnLogs.Visible = true;
        }

        private void btnLogs_MouseLeave(object sender, EventArgs e)
        {
            if (!btnLogsActivado)
            {
                pnBtnLogs.Visible = false;
            }
        }
    }
}







/*
 

    RESPALDO

        //Lista de estudiantes con los que se va a trabajar (cambai dependiendo de la cosnulta realizada)
        List<Estudiante> estudiantesTrabajar = new List<Estudiante>();
        List<ActividadComplementaria> actividadesDeEstudianteSeleccionado = new List<ActividadComplementaria>();

        //Objeto conexion que me permite realizar todas mis consultas y pruebas
        Conexion Nucleo.miConexion = new Conexion();

        public Menu()
        {
            InitializeComponent();
            MessageBox.Show(Nucleo.miConexion.TestearConexiones());


            List<string> carreras = Nucleo.miConexion.MostrarCarreras();
            foreach(string x in carreras)
            {
                cbDato.Items.Add(x);
            }
        }






       


       
 


        //Busqueda de estudiante
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void cbTipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lblDato.Visible)
            {
                lblDato.Visible = true;
                tbDato.Visible = true;
                btnBuscar.Visible = true;
            }
            switch (cbTipoConsulta.SelectedItem)
            {
                case "Numero de control":
                    tbDato.Visible = true;
                    cbDato.Visible = false;
                    lblDato.Text = "Introduzca el numero de control";
                    break;
                case "Nombre":
                    lblDato.Text = "Introduzca el nombre";
                    break;
                case "Apellido":
                    lblDato.Text = "Introduzca el apellido";
                    break;
                case "Carrera":
                    tbDato.Visible = false;
                    cbDato.Visible = true;
                    lblDato.Text = "Introduzca la carrera";
                    break;
                default:
                    break;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            lbEstudiantes.Items.Clear();
            estudiantesTrabajar.Clear();


            switch (cbTipoConsulta.SelectedItem)
            {
                case "Numero de control":

                    estudiantesTrabajar =  Nucleo.miConexion.BuscarEstudiante("numeroDeControl", tbDato.Text);
                    foreach(Estudiante n in estudiantesTrabajar)
                    {
                        lbEstudiantes.Items.Add(n.NumeroDeControl + " " + n.Nombre);
                    }


                   break;
                case "Nombre":
                    
                    break;
                case "Apellido":
                    

                    break;
                case "Semestre":
                    
                    break;
                case "Carrera":
                    estudiantesTrabajar =  Nucleo.miConexion.BuscarEstudiante("carrera", cbDato.Text);
                    foreach (Estudiante n in estudiantesTrabajar)
                    {
                        lbEstudiantes.Items.Add(n.NumeroDeControl + " | " + n.Nombre);
                    }
                    break;
            }

            lblCantidadResultados.Text = estudiantesTrabajar.Count().ToString();
            
        }

        private void lbEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbActividad.Visible = false;
            try
            {
                actividadesDeEstudianteSeleccionado.Clear();
                lbActividades.Items.Clear();
                
                lblNombre.Text = "Nombre completo: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Nombre.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoPaterno.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoMaterno.TrimEnd();
                lblNumeroDeControl.Text = "Numero de control: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl;
                lblCarrera.Text = "Carrera: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Carrera;
                actividadesDeEstudianteSeleccionado = Nucleo.miConexion.BuscarActividades(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString());
                foreach (ActividadComplementaria n in actividadesDeEstudianteSeleccionado)
                {
                    lbActividades.Items.Add(n.ActividadTitulo.ToString());
                }
                lblCreditos.Text = Nucleo.miConexion.ConsultarCreditosTerminados(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()).ToString();
                gbAlumno.Visible = true;
            }
            catch 
            {
                MessageBox.Show("Error al seleccionar algun estudiante"); 
            }

        }

        private void lbActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbActividad.Visible = true;
            try
            {
                if(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].EstadoDeLaActividad.ToString() == "T")
                {
                    lblActividadEstatus.Text = "Terminado";
                    btnCalificar.Text = "MODIFICAR EVALUACION";
                    btnGenerarConstancia.Visible = true;
                }
                else
                {
                    lblActividadEstatus.Text = "Activo";
                    btnCalificar.Text = "TERMINAR ACTIVIDAD";
                    btnGenerarConstancia.Visible = false;
                }
                


                lblActividadSeleccionada.Text = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadTitulo.ToString();
                lblFechaDeOficio.Text = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].FechaDeOficio.ToString();
                lblActividadEncargado.Text = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Responsable.ToString();
                lblActividadJefe.Text = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Jefe.ToString();
                
            }
            catch
            {
                MessageBox.Show("Error al seleccionar alguna actividad");
            }
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            Calificar miCalificar = new Calificar();
            miCalificar.Show();
        }

        private void btnAgregarNuevaActividad_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void cbDato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerarConstancia_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarActividad_Click(object sender, EventArgs e)
        {

        }
     */
