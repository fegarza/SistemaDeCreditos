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
    public partial class Estudiantes : Form
    {
        //Lista de estudiantes con los que se va a trabajar (cambia dependiendo de la cosnulta realizada)
        List<Estudiante> estudiantesTrabajar = new List<Estudiante>();
        List<ActividadComplementaria> actividadesDeEstudianteSeleccionado = new List<ActividadComplementaria>();

  
        //GENERADOR DE CONSTANCIA
        PDF pdf = new PDF();

        public Estudiantes()
        {
            InitializeComponent();
            List<string> carreras = Nucleo.miConexion.MostrarCarreras();
            foreach (string x in carreras)
            {
                cbDato.Items.Add(x);
            }
        }
        public Estudiantes(string _numControl)
        {
            InitializeComponent();
            List<string> carreras = Nucleo.miConexion.MostrarCarreras();
            foreach (string x in carreras)
            {
                cbDato.Items.Add(x);
            }
            cbTipoConsulta.SelectedItem = "Numero de control";
            tbDato.Text = _numControl;
            btnBuscar_Click(null, null);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            lbEstudiantes.SetSelected(0,true);
        }

        //Busqueda de estudiante
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            lbEstudiantes.Items.Clear();
            estudiantesTrabajar.Clear();


            switch (cbTipoConsulta.SelectedItem)
            {
                case "Numero de control":
                    if (tbDato.TextLength > 4)
                    {
                        estudiantesTrabajar = Nucleo.miConexion.BuscarEstudiante("numeroDeControl", tbDato.Text, 0, true, true, true);
                        foreach (Estudiante n in estudiantesTrabajar)
                        {
                            lbEstudiantes.Items.Add(n.NumeroDeControl + " " + n.Nombre);
                        }
                        pnFiltros.Visible = true;
                        lblCantidadResultados.Text = estudiantesTrabajar.Count().ToString();
                        lblCantidadResultados.Visible = true;
                        lbEstudiantes.Visible = true;
                        lblCantidadResultadotxt.Visible = true;
                        pnActividad.Visible = false;
                        pnEstudiante.Visible = false;
                        btnExportar.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("El número de control debe tener mas de 4 digitos", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Carrera":
                    if (!String.IsNullOrEmpty(cbDato.Text))
                    {
                        estudiantesTrabajar = Nucleo.miConexion.BuscarEstudiante("carrera", cbDato.Text, 0, true, true, true);
                        foreach (Estudiante n in estudiantesTrabajar)
                        {
                            lbEstudiantes.Items.Add(n.NumeroDeControl + " | " + n.Nombre);
                        }
                        pnFiltros.Visible = true;
                        lblCantidadResultados.Text = estudiantesTrabajar.Count().ToString();
                        lblCantidadResultados.Visible = true;
                        lbEstudiantes.Visible = true;
                        lblCantidadResultadotxt.Visible = true;
                        pnActividad.Visible = false;
                        pnEstudiante.Visible = false;
                        btnExportar.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("!Falta introducir la carrera correspondiente¡","Datos incompletos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;
            }





        }

        private void cbTipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnFiltros.Visible = true;
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
                    lblDato.Text = "Introduzca el número de control";
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

        private void lbEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnActividad.Visible = false;
            try
            {

                actividadesDeEstudianteSeleccionado.Clear();
                lbActividades.Items.Clear();
                actividadesDeEstudianteSeleccionado = Nucleo.miConexion.BuscarActividades(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString());

                lblNombre.Text = "Nombre completo: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Nombre.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoPaterno.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoMaterno.TrimEnd();
                lblNumeroDeControl.Text = "Numero de control: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl;
                lblCarrera.Text = "Carrera: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Carrera;
                foreach (ActividadComplementaria n in actividadesDeEstudianteSeleccionado)
                {
                    lbActividades.Items.Add(n.ActividadTitulo.ToString());
                }
                lblCreditos.Text = "Creditos otorgados acumulados: " + Nucleo.miConexion.ConsultarCreditosTerminados(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()).ToString();
                lblSemestre.Text = "Semestre: " + Nucleo.miConexion.CalcularSemestre(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()).ToString();
                pnEstudiante.Visible = true;
                if (Nucleo.miConexion.ConsultarCreditosTerminados(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()) < 5)
                {
                    btnAgregarNuevaActividad.Visible = true;
                }
                else
                {
                    btnAgregarNuevaActividad.Visible = false;
                }

            }
            catch
            {
            }
        }

        private void btnEliminarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.PersonalClave == actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ResponsableID || Nucleo.UsuarioLogueado.Rol == "Supervisor")
                {

                    if (MessageBox.Show("¿Estas seguro de eliminar esta actividad ?", "Eliminar actividad", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Nucleo.miConexion.EliminarActividad(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].CreditoID.ToString(), estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString());
                        Nucleo.miConexion.InsertarNuevoLog("ha elimiado la actividad " + actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadTitulo + " de: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Nombre.TrimEnd() + " que tiene el número control: "+ estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl);
                        pnActividad.Visible = false;
                        try
                        {

                            actividadesDeEstudianteSeleccionado.Clear();
                            lbActividades.Items.Clear();
                            actividadesDeEstudianteSeleccionado = Nucleo.miConexion.BuscarActividades(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString());

                            lblNombre.Text = "Nombre completo: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Nombre.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoPaterno.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoMaterno.TrimEnd();
                            lblNumeroDeControl.Text = "Numero de control: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl;
                            lblCarrera.Text = "Carrera: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Carrera;
                            foreach (ActividadComplementaria n in actividadesDeEstudianteSeleccionado)
                            {
                                lbActividades.Items.Add(n.ActividadTitulo.ToString());
                            }
                            lblCreditos.Text = "Creditos otorgados acumulados: " + Nucleo.miConexion.ConsultarCreditosTerminados(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()).ToString();
                            lblSemestre.Text = "Semestre: " + Nucleo.miConexion.CalcularSemestre(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()).ToString();
                            pnEstudiante.Visible = true;
                            if (Nucleo.miConexion.ConsultarCreditosTerminados(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()) < 5)
                            {
                                btnAgregarNuevaActividad.Visible = true;
                            }
                            else
                            {
                                btnAgregarNuevaActividad.Visible = false;
                            }

                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Usted no tiene permisos para eliminar esta actividad", "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }

        private void lbActividades_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].EstadoDeLaActividad.ToString() == "T")
                {
                    lblActividadEstatus.Text = "Estatus de la actividad: Terminada";
                    btnCalificar.Text = "MODIFICAR EVALUACION";
                    btnGenerarConstancia.Visible = true;
                    btnMarcar.Visible = true;
                }
                else
                {
                    lblActividadEstatus.Text = "Estatus de la actividad: Activa";
                    btnCalificar.Text = "TERMINAR ACTIVIDAD";
                    btnGenerarConstancia.Visible = false;
                    btnMarcar.Visible = false;
                }

                if (Nucleo.miConexion.BuscarDisponibilidadDeGrupo(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadID.ToString()))
                {
                    btnGrupo.Visible = true;
                }
                else
                {
                    btnGrupo.Visible = false;

                }
                lblSeccion.Text = "Seccion correspondiente de la actividad: " + actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Seccion.ToString();
                lblActividadSeleccionada.Text = "Nombre de la actividad: " + actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadTitulo.ToString();
                lblFechaDeOficio.Text = "Fecha de oficio: " + actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].FechaDeOficio.ToShortDateString();
                lblActividadEncargado.Text = "Encargado de la actividad: " + actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Responsable.ToString();
                lblActividadJefe.Text = "Jefe de la actividad: " + actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Jefe.ToString();
                lblPeso.Text = "Repeticiones permitidas en esta actividad: " + actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Peso.ToString();
                string periodoNumerico = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Periodo.ToString();
                string periodo = "";

                switch (periodoNumerico[3].ToString())
                {
                    case "1":
                        periodo = "Enero - Junio 20";
                        break;
                    case "2":
                        periodo = "Verano 20";
                        break;
                    case "3":
                        periodo = "Agosto - Diciembre 20";
                        break;
                }

                periodo = periodo + periodoNumerico[1].ToString() + periodoNumerico[2].ToString();
                lblPeriodo.Text = "Periodo: " + periodo;
                if (actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].EstadoDeLaFirma.ToString() == "P")
                {
                    btnMarcar.Text = "MARCAR COMO FIRMADA";
                }
                else
                {
                    btnMarcar.Text = "MARCAR COMO NO FIRMADA";

                }



                pnActividad.Visible = true;
            }
            catch { }
 
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            //VERIFICAR PERMISOS
            if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.PersonalClave == actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ResponsableID || Nucleo.UsuarioLogueado.Rol == "Supervisor")
            {
                Calificar miCalificar = new Calificar(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].CreditoID, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Pregunta1, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Pregunta2, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Pregunta3, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Pregunta4, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Pregunta5, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Pregunta6, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Pregunta7, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Promedio);
                miCalificar.ShowDialog();

                pnActividad.Visible = false;
                try
                {

                    actividadesDeEstudianteSeleccionado.Clear();
                    lbActividades.Items.Clear();
                    actividadesDeEstudianteSeleccionado = Nucleo.miConexion.BuscarActividades(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString());

                    lblNombre.Text = "Nombre completo: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Nombre.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoPaterno.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoMaterno.TrimEnd();
                    lblNumeroDeControl.Text = "Numero de control: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl;
                    lblCarrera.Text = "Carrera: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Carrera;
                    foreach (ActividadComplementaria n in actividadesDeEstudianteSeleccionado)
                    {
                        lbActividades.Items.Add(n.ActividadTitulo.ToString());
                    }
                    lblCreditos.Text = "Creditos otorgados acumulados: " + Nucleo.miConexion.ConsultarCreditosTerminados(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()).ToString();
                    lblSemestre.Text = "Semestre: " + Nucleo.miConexion.CalcularSemestre(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()).ToString();
                    pnEstudiante.Visible = true;
                    if (Nucleo.miConexion.ConsultarCreditosTerminados(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()) < 5)
                    {
                        btnAgregarNuevaActividad.Visible = true;
                    }
                    else
                    {
                        btnAgregarNuevaActividad.Visible = false;
                    }

                    if (actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].EstadoDeLaFirma == 'P')
                    {
                        btnMarcar.Text = "MARCAR COMO FIRMADA";
                    }
                    else
                    {
                        btnMarcar.Text = "MARCAR COMO NO FIRMADA";

                    }
                }
                catch
                {
                }
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para calificar dicho alumno", "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnAgregarNuevaActividad_Click(object sender, EventArgs e)
        {
            NuevaActividad nuevaActividadForm = new NuevaActividad(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl);
            nuevaActividadForm.ShowDialog();

            actividadesDeEstudianteSeleccionado.Clear();
            lbActividades.Items.Clear();
            actividadesDeEstudianteSeleccionado = Nucleo.miConexion.BuscarActividades(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString());
            foreach (ActividadComplementaria n in actividadesDeEstudianteSeleccionado)
            {
                lbActividades.Items.Add(n.ActividadTitulo.ToString());
            }
            pnActividad.Visible = false;

        }

       

        private void cbDato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerarConstancia_Click(object sender, EventArgs e)
        {
            string nombre = estudiantesTrabajar[lbEstudiantes.SelectedIndex].Nombre.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoPaterno.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoMaterno.TrimEnd();
            string noControl = estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString().Trim();
            string carrera = estudiantesTrabajar[lbEstudiantes.SelectedIndex].Carrera.Trim();
            string actividadTitulo = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadTitulo.ToString().ToUpper().Trim();
            string calificacion = "";
            string nivelDeDesempeño = "";
            if(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Promedio >= 3)
            {
                if(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Promedio < 4)
                {
                    calificacion = "3";
                    nivelDeDesempeño = "NOTABLE";
                }
                else
                {
                    calificacion = "4";
                    nivelDeDesempeño = "EXCELENTE";
                }
            }
            string periodoNumerico = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Periodo.ToString();
            string periodo = "";
             
            switch (periodoNumerico[3].ToString())
            {
                case "1":
                    periodo = "Enero - Junio 20";
                    break;
                case "2":
                    periodo = "Verano 20";
                    break;
                case "3":
                    periodo = "Agosto - Diciembre 20";
                    break;
            }

            periodo = periodo + periodoNumerico[1].ToString() + periodoNumerico[2].ToString();
            string peso = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Peso.ToString().Trim()    ; 
            string responsable = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Responsable;
            string responsableID = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ResponsableID.ToString();

            string jefe = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Jefe;
            string jefeID = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].JefeID.ToString();


            string dia = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].FechaDeOficio.Day.ToString();
            string mes = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].FechaDeOficio.Month.ToString();
            switch (mes)
            {
                case "1":
                    mes = "Enero";
                    break;
                case "2":
                    mes = "Febrero";
                    break;
                case "3":
                    mes = "Marzo";
                    break;
                case "4":
                    mes = "Abril";
                    break;
                case "5":
                    mes = "Mayo";
                    break;
                case "6":
                    mes = "Junio";
                    break;
                case "7":
                    mes = "Julio";
                    break;
                case "8":
                    mes = "Agosto";
                    break;
                case "9":
                    mes = "Septiembre";
                    break;
                case "10":
                    mes = "Octubre";
                    break;
                case "11":
                    mes = "Noviembre";
                    break;
                case "12":
                    mes = "Diciembre";
                    break;
            }
            string año = actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].FechaDeOficio.Year.ToString();


            string departamento = Nucleo.miConexion.BuscarNombreDepartamentoPorPersonal(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].JefeID.ToString());


            if ( departamento == "No se encuentra registrado el departamento de dicho personal")
            {
                MessageBox.Show("El jefe de la actividad no tiene un departamento registrado, por lo tanto tendra que colocar el departamento al que pertenece: "+ Nucleo.miConexion.ConsultarNombreCompletoDePersonal(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].JefeID.ToString()) );
                SeleccionDeDepartamento seleccionar = new SeleccionDeDepartamento();
                seleccionar.ShowDialog();
                if (String.IsNullOrEmpty(Nucleo.departamentoJefeGenerado))
                {
                    MessageBox.Show("No se selecciono ningun departamento");
                }
                else
                {
                    pdf.GenerarConstancia(nombre, noControl, carrera, actividadTitulo, nivelDeDesempeño, calificacion, periodo, peso, dia, mes, año, responsable, jefe, Nucleo.departamentoJefeGenerado, responsableID, jefeID);
                    Nucleo.departamentoJefeGenerado = "";
                }
            }
            else
            {
            pdf.GenerarConstancia(nombre, noControl, carrera, actividadTitulo, nivelDeDesempeño, calificacion, periodo, peso, dia,mes, año,   responsable, jefe, departamento, responsableID, jefeID);

            }
            
        }

        private void cbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void ckCreditosTerminados_CheckedChanged(object sender, EventArgs e)
        {
       
        }

        private void ckCreditosPendientes_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void ckSinCreditos_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void tbDato_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tbDato.Text))
                {
                }
                else
                {
                    int.Parse(tbDato.Text);

                }
            }
            catch
            {
                tbDato.Text = "";
            }
        }

      

        private void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbTipoConsulta.Text))
            {
                bool entrar = true;
                if(cbTipoConsulta.Text == "Carrera")
                {
                    if (String.IsNullOrEmpty(cbDato.Text))
                    {
                        MessageBox.Show("Debe escoger una carrera para aplicar los filtros", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        entrar = false;
                    }
                }
                else
                {
                    if(tbDato.Text.Length < 4)
                    {
                        MessageBox.Show("Introduce al menos 4 digitos en el numero de control para aplicar filtros");
                        entrar = false;
                    }
                }
                if(entrar)
                {
                    Boolean _creditosPendientes = false;
                    Boolean _creditosTerminados = false;
                    Boolean _sinCreditos = false;
                    int semestre = 0;

                    if (ckCreditosPendientes.Checked)
                    {
                        _creditosPendientes = true;
                    }
                    if (ckCreditosTerminados.Checked)
                    {
                        _creditosTerminados = true;
                    }
                    if (ckSinCreditos.Checked)
                    {
                        _sinCreditos = true;
                    }
                    if (!(String.IsNullOrEmpty(cbSemestre.Text)))
                    {
                        switch (cbSemestre.SelectedItem.ToString())
                        {
                            case "Primero":
                                semestre = 1;
                                break;
                            case "Segundo":
                                semestre = 2;
                                break;
                            case "Tercero":
                                semestre = 3;
                                break;
                            case "Cuarto":
                                semestre = 4;
                                break;
                            case "Quinto":
                                semestre = 5;
                                break;
                            case "Sexto":
                                semestre = 6;
                                break;
                            case "Septimo":
                                semestre = 7;
                                break;
                            case "Octavo":
                                semestre = 8;
                                break;
                            case "Noveno":
                                semestre = 9;
                                break;
                        }
                    }
                    lbEstudiantes.Items.Clear();
                    estudiantesTrabajar.Clear();


                    switch (cbTipoConsulta.SelectedItem)
                    {
                        case "Numero de control":
                            estudiantesTrabajar = Nucleo.miConexion.BuscarEstudiante("numeroDeControl", tbDato.Text, semestre, _creditosTerminados, _creditosPendientes, _sinCreditos);
                            foreach (Estudiante n in estudiantesTrabajar)
                            {
                                lbEstudiantes.Items.Add(n.NumeroDeControl + " " + n.Nombre);
                            }
                            break;
                        case "Carrera":
                            estudiantesTrabajar = Nucleo.miConexion.BuscarEstudiante("carrera", cbDato.Text, semestre, _creditosTerminados, _creditosPendientes, _sinCreditos);
                            foreach (Estudiante n in estudiantesTrabajar)
                            {
                                lbEstudiantes.Items.Add(n.NumeroDeControl + " | " + n.Nombre);
                            }
                            break;
                    }

                    lblCantidadResultados.Text = estudiantesTrabajar.Count().ToString();
                    lblCantidadResultados.Visible = true;
                    lbEstudiantes.Visible = true;
                    btnExportar.Visible = true;
                    lblCantidadResultadotxt.Visible = true;
                    pnActividad.Visible = false;
                    pnEstudiante.Visible = false;
                }
            }
        }

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.PersonalClave == actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ResponsableID || Nucleo.UsuarioLogueado.Rol == "Supervisor")
            {
               
          

            if (actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].EstadoDeLaFirma.ToString() == "P")
            {
                Nucleo.miConexion.MarcarFirma("F" ,actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].CreditoID.ToString());
                Nucleo.miConexion.InsertarNuevoLog("ha marcado como firmada la actividad: "+ actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadTitulo + " de: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Nombre.TrimEnd() + " que tiene el número control: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl);
                MessageBox.Show("¡Se ha marcado como firmada!", "Correcto", MessageBoxButtons.OK);
            }
            else
            {
                Nucleo.miConexion.MarcarFirma("P", actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].CreditoID.ToString());
                Nucleo.miConexion.InsertarNuevoLog("ha marcado como no firmada la actividad: " + actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadTitulo + " de: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Nombre.TrimEnd() + " que tiene el número control: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl);

                MessageBox.Show("¡Se ha marcado como no firmada!", "Correcto", MessageBoxButtons.OK);
            }
            pnActividad.Visible = false;
            try
            {

                actividadesDeEstudianteSeleccionado.Clear();
                lbActividades.Items.Clear();
                actividadesDeEstudianteSeleccionado = Nucleo.miConexion.BuscarActividades(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString());

                lblNombre.Text = "Nombre completo: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Nombre.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoPaterno.TrimEnd() + " " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].ApellidoMaterno.TrimEnd();
                lblNumeroDeControl.Text = "Numero de control: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl;
                lblCarrera.Text = "Carrera: " + estudiantesTrabajar[lbEstudiantes.SelectedIndex].Carrera;
                foreach (ActividadComplementaria n in actividadesDeEstudianteSeleccionado)
                {
                    lbActividades.Items.Add(n.ActividadTitulo.ToString());
                }
                lblCreditos.Text = "Creditos otorgados acumulados: " + Nucleo.miConexion.ConsultarCreditosTerminados(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()).ToString();
                lblSemestre.Text = "Semestre: " + Nucleo.miConexion.CalcularSemestre(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()).ToString();
                pnEstudiante.Visible = true;
                if (Nucleo.miConexion.ConsultarCreditosTerminados(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString()) < 5)
                {
                    btnAgregarNuevaActividad.Visible = true;
                }
                else
                {
                    btnAgregarNuevaActividad.Visible = false;
                }

                if (actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].EstadoDeLaFirma.ToString() == "P")
                {
                    btnMarcar.Text = "MARCAR COMO FIRMADA";
                }
                else
                {
                    btnMarcar.Text = "MARCAR COMO NO FIRMADA";

                }

            }
            catch
            {
            }
            }
            else
            {
                MessageBox.Show("¡Usted no tiene permisos para marcar como firmado a dicho alumno!", "Error de permisos", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            pdf.ExportarListaDeBusqueda(estudiantesTrabajar);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.PersonalClave == actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ResponsableID || Nucleo.UsuarioLogueado.Rol == "Supervisor") {
                NuevaActividad editarAct = new NuevaActividad(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString(), actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].CreditoID, int.Parse(Nucleo.miConexion.ConsultarSeccionID(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadID.ToString())), actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadID, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ResponsableID, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].JefeID, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].FechaDeOficio, actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].Periodo);
                editarAct.ShowDialog();
                actividadesDeEstudianteSeleccionado.Clear();
                lbActividades.Items.Clear();
                actividadesDeEstudianteSeleccionado = Nucleo.miConexion.BuscarActividades(estudiantesTrabajar[lbEstudiantes.SelectedIndex].NumeroDeControl.ToString());
                foreach (ActividadComplementaria n in actividadesDeEstudianteSeleccionado)
                {
                    lbActividades.Items.Add(n.ActividadTitulo.ToString());
                }
                pnActividad.Visible = false;

            }
            else
            {
                MessageBox.Show("¡Usted no tiene permisos para editar dicho alumno!");
            }

              

        }

     

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            if (Nucleo.UsuarioLogueado.Rol == "Administrador" || Nucleo.UsuarioLogueado.PersonalClave == actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ResponsableID || Nucleo.UsuarioLogueado.Rol == "Supervisor")
            {
                Asignar_grupo asignar = new Asignar_grupo(actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].CreditoID.ToString(), actividadesDeEstudianteSeleccionado[lbActividades.SelectedIndex].ActividadID.ToString());
                asignar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usted no tiene permisos para asignar grupo a dicho alumno");
            }
        }
 

        private void tbDato_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
        }
    }
}
