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
    public partial class Ajustes : Form
    {
         List<Personal> posiblePersonalAgregar = new List<Personal>();
        List<Usuario> usuariosEditar = new List<Usuario>();
        List<Seccion> seccionesEditar = new List<Seccion>();
        List<Actividad> actividadesEditar = new List<Actividad>();

        public Ajustes()
        {
            InitializeComponent();

            posiblePersonalAgregar = Nucleo.miConexion.MostrarPersonalDisponible();
            usuariosEditar = Nucleo.miConexion.MostrarUsuariosRegistrados();

            seccionesEditar = Nucleo.miConexion.MostrarSecciones();
            actividadesEditar = Nucleo.miConexion.MostrarActividades();

            foreach (Personal x in posiblePersonalAgregar)
            {
                cbUsuarios.Items.Add(x.Nombre + " " + x.Apellidos);
            }
            foreach (Usuario x in usuariosEditar)
            {
                lbUsuarios.Items.Add(x.Nombre);
            }
            foreach (Seccion x in seccionesEditar)
            {
                lbSecciones.Items.Add(x.Nombre);
                cbSeccionActividad.Items.Add(x.Nombre);
                cbESeccionActividad.Items.Add(x.Nombre);
            }
            foreach (Actividad x in actividadesEditar)
            {
                lbActividades.Items.Add(x.Nombre);
            }
        }


        private void lbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblERol.Text = "Rol: " + usuariosEditar[lbUsuarios.SelectedIndex].Rol;
                lblEClave.Text = "Clave: " + usuariosEditar[lbUsuarios.SelectedIndex].Clave;
                lblEGenero.Text = "Genero: " + usuariosEditar[lbUsuarios.SelectedIndex].Genero;
            }
            catch
            {
             }
        }




        #region USUARIOS
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(cbEditarRol.Text) && String.IsNullOrEmpty(cbEGenero.Text) && String.IsNullOrEmpty(tbEditarClave.Text))
                {
                    MessageBox.Show("No se han realizado cambios en el usuario");
                }
                else
                {
                    string genero;

                    if (cbEGenero.Text == "Hombre")
                    {
                        genero = "H";
                    }
                    else
                    {
                        genero = "M";
                    }
                    string rol = cbEditarRol.Text;
                    string clave = tbEditarClave.Text;
                    if (String.IsNullOrEmpty(cbEditarRol.Text))
                    {
                        rol = usuariosEditar[lbUsuarios.SelectedIndex].Rol;
                    }
                    if (String.IsNullOrEmpty(cbEGenero.Text))
                    {
                        genero = usuariosEditar[lbUsuarios.SelectedIndex].Genero;
                    }
                    if (String.IsNullOrEmpty(tbEditarClave.Text))
                    {
                        clave = usuariosEditar[lbUsuarios.SelectedIndex].Clave;
                    }

                    Nucleo.miConexion.ActualizarDatosDeUsuario(rol, clave, genero, usuariosEditar[lbUsuarios.SelectedIndex].UsuarioID);
                    Nucleo.miConexion.InsertarNuevoLog("ha modificado al usuario: " + usuariosEditar[lbUsuarios.SelectedIndex].Nombre + " del sistema");

                    ActualizarTodo("usuarios");


                    MessageBox.Show("Se ha editado correctamente!");
                }
            }
            catch { }
        }
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbUsuarios.Text) || String.IsNullOrEmpty(tbClave.Text) || String.IsNullOrEmpty(cbGenero.Text) || String.IsNullOrEmpty(cbRol.Text))
            {
                MessageBox.Show("Todos los datos deben de estar completos");
            }
            else
            {
                string genero = "x";

                if (cbGenero.Text == "Hombre")
                {
                    genero = "H";
                }
                else
                {
                    genero = "M";
                }
                Nucleo.miConexion.InsertarUsuario(posiblePersonalAgregar[cbUsuarios.SelectedIndex].Clave, tbClave.Text, cbRol.Text, posiblePersonalAgregar[cbUsuarios.SelectedIndex].Nombre, posiblePersonalAgregar[cbUsuarios.SelectedIndex].Apellidos, genero);
                Nucleo.miConexion.InsertarNuevoLog("ha agregado al usuario: " + posiblePersonalAgregar[cbUsuarios.SelectedIndex].Nombre + " al sistema");

                ActualizarTodo("usuarios");
            }
        }
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if(usuariosEditar[lbUsuarios.SelectedIndex].Nombre == "Administrador")
                {
                    MessageBox.Show("No se puede eliminar el usuario por default"); 
                }
                else
                {
                    if (MessageBox.Show("¿Estas seguro de eliminar este usuario ?", "Eliminar usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Nucleo.miConexion.InsertarNuevoLog("ha eliminado al usuario: " + usuariosEditar[lbUsuarios.SelectedIndex].Nombre + " del sistema");
                        Nucleo.miConexion.EliminarUsuario(usuariosEditar[lbUsuarios.SelectedIndex].UsuarioID.ToString());
                        ActualizarTodo("usuarios");
                    }
                }
                
            }
            catch
            {

            }
        }
        #endregion

        #region MENU
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            pnNuevaActividad.Visible = false;
            pnNuevaSeccion.Visible = false;
            pnNuevoUsuario.Visible = true;
            pnModificarUsuario.Visible = true;
            pnEditarActividad.Visible = false;
            pnEditarSeccion.Visible = false;
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            pnNuevaActividad.Visible = true;
            pnNuevaSeccion.Visible = false;
            pnNuevoUsuario.Visible = false;
            pnModificarUsuario.Visible = false;
            pnEditarActividad.Visible = true;
            pnEditarSeccion.Visible = false;
        }

        private void btnSecciones_Click(object sender, EventArgs e)
        {
            pnNuevaActividad.Visible = false;
            pnNuevaSeccion.Visible = true;
            pnNuevoUsuario.Visible = false;
            pnModificarUsuario.Visible = false;
            pnEditarActividad.Visible = false;
            pnEditarSeccion.Visible = true;
        }
        #endregion


        public void ActualizarTodo(string _place)
        {
            switch (_place)
            {
                case "usuarios":
                    /*
                      -->  Actualizar campos de agregar nuevo usuario  <--
                    */
                    posiblePersonalAgregar = Nucleo.miConexion.MostrarPersonalDisponible();
                    usuariosEditar = Nucleo.miConexion.MostrarUsuariosRegistrados();
                    tbClave.Text = "";
                    cbRol.Items.Clear();
                    cbRol.Items.Add("Administrador");
                    cbRol.Items.Add("Supervisor");
                    cbRol.Items.Add("Docente");
                    cbUsuarios.Items.Clear();
                    lbUsuarios.Items.Clear();

                    foreach (Personal x in posiblePersonalAgregar)
                    {
                        cbUsuarios.Items.Add(x.Nombre + " " + x.Apellidos);
                    }
                    cbGenero.Items.Clear();
                    cbGenero.Items.Add("Hombre");
                    cbGenero.Items.Add("Mujer");

                    /*
                     --> Actualizar campos de editar usuario <--
                     */
                    foreach (Usuario x in usuariosEditar)
                    {
                        lbUsuarios.Items.Add(x.Nombre);
                    }

                    lblEClave.Text = "Clave: ";
                    tbEditarClave.Text = "";
                    lblEGenero.Text = "Genero: ";
                    cbEGenero.Items.Clear();
                    cbEGenero.Items.Add("Hombre");
                    cbEGenero.Items.Add("Mujer");
                    lblERol.Text = "Rol: ";
                    cbEditarRol.Items.Clear();
                    cbEditarRol.Items.Add("Administrador");
                    cbEditarRol.Items.Add("Supervisor");
                    cbEditarRol.Items.Add("Docente");
                    break;
                case "actividades":
                    lblETituloActividad.Text = "Titulo de la actividad:";
                    lblEPesoActividad.Text = "Peso de la actividad:";
                    lblESeccionActividad.Text = "Seccion de la actividad: ";
                    actividadesEditar.Clear();
                    cbSeccionActividad.Items.Clear();
                    cbESeccionActividad.Items.Clear();
                    actividadesEditar = Nucleo.miConexion.MostrarActividades();
                    lbActividades.Items.Clear();
                    foreach (Actividad x in actividadesEditar)
                    {
                        lbActividades.Items.Add(x.Nombre);
                    }
                    foreach (Seccion x in seccionesEditar)
                    {
                        cbSeccionActividad.Items.Add(x.Nombre);
                        cbESeccionActividad.Items.Add(x.Nombre);
                    }
                    tbActividadTitulo.Text = "";
                    tbEActividad.Text = "";
                    cbEPesoActividad.Items.Clear();
                    cbEPesoActividad.Items.Add("1");
                    cbEPesoActividad.Items.Add("2");
                    cbEPesoActividad.Items.Add("3");
                    cbPesoActividad.Items.Clear();
                    cbPesoActividad.Items.Add("1");
                    cbPesoActividad.Items.Add("2");
                    cbPesoActividad.Items.Add("3");
                    break;
                case "secciones":
                    lbSecciones.Items.Clear();
                    tbTituloSeccion.Text = "";
                    cbPesoSeccion.Items.Clear();
                    cbPesoSeccion.Items.Add("1");
                    cbPesoSeccion.Items.Add("2");
                    cbPesoSeccion.Items.Add("3");
                    seccionesEditar.Clear();
                    seccionesEditar = Nucleo.miConexion.MostrarSecciones();
                    cbSeccionActividad.Items.Clear();
                    cbESeccionActividad.Items.Clear();
                    foreach (Seccion x in seccionesEditar)
                    {
                        cbSeccionActividad.Items.Add(x.Nombre);
                        cbESeccionActividad.Items.Add(x.Nombre);
                        lbSecciones.Items.Add(x.Nombre);
                    }
                    tbETituloSeccion.Text = "";
                    cbEPesoSeccion.Items.Clear();
                    cbEPesoSeccion.Items.Add("1");
                    cbEPesoSeccion.Items.Add("2");
                    cbEPesoSeccion.Items.Add("3");
                    lblTituloSeccion.Text = "Titulo de la seccion";
                    lblPesoSeccion.Text = "Peso maximo de la seccion";
                    break;
                case "sistema":
                    break;
            }

        }

        private void btnAgregarSeccion_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(tbTituloSeccion.Text) || String.IsNullOrEmpty(cbPesoSeccion.Text))
            {
                MessageBox.Show("Complete todos los datos correspondientes");
            }
            else
            {
                Nucleo.miConexion.InsertarNuevaSeccion(tbTituloSeccion.Text, int.Parse(cbPesoSeccion.Text));
                Nucleo.miConexion.InsertarNuevoLog("ha agregado la seccion: " + tbTituloSeccion.Text);
            }
            ActualizarTodo("secciones");
        }

        private void lbSecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblTituloSeccion.Text = "Titulo de la seccion: " + seccionesEditar[lbSecciones.SelectedIndex].Nombre;
                lblPesoSeccion.Text = "Peso máximo de créditos de la sección: " + seccionesEditar[lbSecciones.SelectedIndex].Peso.ToString();
            }
            catch { }
        }

        private void btnEditarSeccion_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = tbETituloSeccion.Text;
                int peso = 0;
                if (String.IsNullOrEmpty(tbETituloSeccion.Text) && String.IsNullOrEmpty(cbEPesoSeccion.Text))
                {
                    MessageBox.Show("Debe aplicar algun cambio");
                }
                else
                {
                    if (String.IsNullOrEmpty(tbETituloSeccion.Text))
                    {
                        titulo = seccionesEditar[lbSecciones.SelectedIndex].Nombre;
                    }
                    if (String.IsNullOrEmpty(cbEPesoSeccion.Text))
                    {
                        peso = seccionesEditar[lbSecciones.SelectedIndex].Peso;

                    }
                    else
                    {
                        peso = int.Parse(cbEPesoSeccion.Text);
                    }
                    Nucleo.miConexion.InsertarNuevoLog("ha editado la seccion: " + seccionesEditar[lbSecciones.SelectedIndex].Nombre);

                    Nucleo.miConexion.ActualizarSeccion(titulo, peso, seccionesEditar[lbSecciones.SelectedIndex].ID);
                    ActualizarTodo("secciones");
                }
            }
            catch
            {
                MessageBox.Show("Seleccione una seccion para poder editarla");
            }
        }

        private void btnEliminarSeccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Estas seguro de eliminar esta seccion ?", "Eliminar seccion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Nucleo.miConexion.InsertarNuevoLog("ha eliminado la seccion: " + seccionesEditar[lbSecciones.SelectedIndex].Nombre);

                    Nucleo.miConexion.EliminarSeccion(seccionesEditar[lbSecciones.SelectedIndex].ID);
                    ActualizarTodo("secciones");
                }
            }
            catch
            {

            }
        }

        private void lbActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblETituloActividad.Text = "Titulo de la actividad: " + actividadesEditar[lbActividades.SelectedIndex].Nombre;
                lblESeccionActividad.Text = "Seccion de la actividad: " + actividadesEditar[lbActividades.SelectedIndex].SeccionNombre;
                lblEPesoActividad.Text = "Cantidad de veces que se puede repetir la actividad: " + actividadesEditar[lbActividades.SelectedIndex].Peso.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
                if (String.IsNullOrEmpty(cbPesoActividad.Text) || String.IsNullOrEmpty(cbSeccionActividad.Text) || String.IsNullOrEmpty(tbActividadTitulo.Text))
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    Nucleo.miConexion.InsertarNuevoLog("ha agregado la actividad: " + tbActividadTitulo.Text);
                    Nucleo.miConexion.InsertarNuevaActividad(tbActividadTitulo.Text, int.Parse(cbPesoActividad.Text), seccionesEditar[cbSeccionActividad.SelectedIndex].ID);
                    ActualizarTodo("actividades");
                }
            }
    

        private void btnEditarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = "";
                int seccionID = 0;
                int pesoActividad = 0;
                if (!(String.IsNullOrEmpty(tbEActividad.Text) && String.IsNullOrEmpty(cbEPesoActividad.Text) && String.IsNullOrEmpty(cbESeccionActividad.Text)))
                {
                    if (String.IsNullOrEmpty(tbEActividad.Text))
                    {
                        titulo = actividadesEditar[lbActividades.SelectedIndex].Nombre;
                    }
                    else
                    {
                        titulo = tbEActividad.Text;
                    }
                    if (String.IsNullOrEmpty(cbEPesoActividad.Text))
                    {
                        pesoActividad = actividadesEditar[lbActividades.SelectedIndex].Peso;
                    }
                    else
                    {
                        pesoActividad = int.Parse(cbEPesoActividad.Text);
                    }
                    if (String.IsNullOrEmpty(cbESeccionActividad.Text))
                    {
                        seccionID = actividadesEditar[lbActividades.SelectedIndex].SeccionID;
                    }
                    else
                    {
                        seccionID = seccionesEditar[cbESeccionActividad.SelectedIndex].ID;
                    }
                    Nucleo.miConexion.InsertarNuevoLog("ha editado la actividad: " + titulo);
                    Nucleo.miConexion.ActualizarActividad(titulo, pesoActividad, seccionID, actividadesEditar[lbActividades.SelectedIndex].ID);
                    ActualizarTodo("actividades");
                }
                else
                {
                    MessageBox.Show("No se han aplicado cambios");
                }
            }
            catch { }
        }



        private void btnEliminarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Estas seguro de eliminar esta actividad ?", "Eliminar actividad", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Nucleo.miConexion.InsertarNuevoLog("ha eliminado la actividad: " + actividadesEditar[lbActividades.SelectedIndex].Nombre);
                    Nucleo.miConexion.EliminarActividad(actividadesEditar[lbActividades.SelectedIndex].ID.ToString());
                    ActualizarTodo("actividades");
                }
                   
            }
            catch
            {

            }
        }
    }
}
