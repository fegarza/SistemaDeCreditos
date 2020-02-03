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

    public partial class Calificar : Form
    {
        public int CreditoID;
        public bool CalificarGrupo = false;
        List<Estudiante> Estudiantes;
        int GrupoID;
        public double FilaA = 0;
        public double FilaB = 0;
        public double FilaC = 0;
        public double FilaD = 0;
        public double FilaE = 0;
        public double FilaF = 0;
        public double FilaG = 0;
        public double Resultado = 0;

        public Calificar(int _creditoID, int _pregunta1, int _pregunta2, int _pregunta3, int _pregunta4, int _pregunta5, int _pregunta6, int _pregunta7, double _promedio)
        {
            InitializeComponent();
            CreditoID = _creditoID;

            switch(_pregunta1)
            {
                case 0:
                    rdA0.Checked = true;
                    ActualizarResultado("A", 0);
                    break;
                case 1:
                    rdA1.Checked = true;
                    ActualizarResultado("A", 1);
                    break;
                case 2:
                    rdA2.Checked = true;
                    ActualizarResultado("A", 2);
                    break;
                case 3:
                    rdA3.Checked = true;
                    ActualizarResultado("A", 3);
                    break;
                case 4:
                    rdA4.Checked = true;
                    ActualizarResultado("A", 4);
                    break;
                default:
                    MessageBox.Show("Error al trasladar el valor obtenido de alguna pregunta");
                    break;
            }
            switch (_pregunta2)
            {
                case 0:
                    rdB0.Checked = true;
                    ActualizarResultado("B", 0);
                    break;
                case 1:
                    rdB1.Checked = true;
                    ActualizarResultado("B", 1);
                    break;
                case 2:
                    rdB2.Checked = true;
                    ActualizarResultado("B", 2);
                    break;
                case 3:
                    rdB3.Checked = true;
                    ActualizarResultado("B", 3);
                    break;
                case 4:
                    rdB4.Checked = true;
                    ActualizarResultado("B", 4);
                    break;
                default:
                    MessageBox.Show("Error al trasladar el valor obtenido de alguna pregunta");
                    break;
            }
            switch (_pregunta3)
            {
                case 0:
                    rdC0.Checked = true;
                    ActualizarResultado("C", 0);
                    break;
                case 1:
                    rdC1.Checked = true;
                    ActualizarResultado("C", 1);
                    break;
                case 2:
                    rdC2.Checked = true;
                    ActualizarResultado("C", 2);
                    break;
                case 3:
                    rdC3.Checked = true;
                    ActualizarResultado("C", 3);
                    break;
                case 4:
                    rdC4.Checked = true;
                    ActualizarResultado("C", 4);
                    break;
                default:
                    MessageBox.Show("Error al trasladar el valor obtenido de alguna pregunta");
                    break;
            }
            switch (_pregunta4)
            {
                case 0:
                    rdD0.Checked = true;
                    ActualizarResultado("D", 0);
                    break;
                case 1:
                    rdD1.Checked = true;
                    ActualizarResultado("D", 1);
                    break;
                case 2:
                    rdD2.Checked = true;
                    ActualizarResultado("D", 2);
                    break;
                case 3:
                    rdD3.Checked = true;
                    ActualizarResultado("D", 3);
                    break;
                case 4:
                    rdD4.Checked = true;
                    ActualizarResultado("D", 4);
                    break;
                default:
                    MessageBox.Show("Error al trasladar el valor obtenido de alguna pregunta");
                    break;
            }
            switch (_pregunta5)
            {
                case 0:
                    rdE0.Checked = true;
                    ActualizarResultado("E", 0);
                    break;
                case 1:
                    rdE1.Checked = true;
                    ActualizarResultado("E", 1);
                    break;
                case 2:
                    rdE2.Checked = true;
                    ActualizarResultado("E", 2);
                    break;
                case 3:
                    rdE3.Checked = true;
                    ActualizarResultado("E", 3);
                    break;
                case 4:
                    rdE4.Checked = true;
                    ActualizarResultado("E", 4);
                    break;
                default:
                    MessageBox.Show("Error al trasladar el valor obtenido de alguna pregunta");
                    break;
            }
            switch (_pregunta6)
            {
                case 0:
                    rdF0.Checked = true;
                    ActualizarResultado("F", 0);
                    break;
                case 1:
                    rdF1.Checked = true;
                    ActualizarResultado("F", 1);
                    break;
                case 2:
                    rdF2.Checked = true;
                    ActualizarResultado("F", 2);
                    break;
                case 3:
                    rdF3.Checked = true;
                    ActualizarResultado("F", 3);
                    break;
                case 4:
                    rdF4.Checked = true;
                    ActualizarResultado("F", 4);
                    break;
                default:
                    MessageBox.Show("Error al trasladar el valor obtenido de alguna pregunta");
                    break;
            }
            switch (_pregunta7)
            {
                case 0:
                    rdG0.Checked = true;
                    ActualizarResultado("G", 0);
                    break;
                case 1:
                    rdG1.Checked = true;
                    ActualizarResultado("G", 1);
                    break;
                case 2:
                    rdG2.Checked = true;
                    ActualizarResultado("G", 2);
                    break;
                case 3:
                    rdG3.Checked = true;
                    ActualizarResultado("G", 3);
                    break;
                case 4:
                    rdG4.Checked = true;
                    ActualizarResultado("G", 4);
                    break;
                default:
                    MessageBox.Show("Error al trasladar el valor obtenido de alguna pregunta");
                    break;
            }
           
          
           
        }


        public Calificar(List<Estudiante> _estudiantes, int _grupoID)
        {
            InitializeComponent();
            Estudiantes = _estudiantes;
            CalificarGrupo = true;
            GrupoID = _grupoID;
        }


        public void ActualizarResultado(string fila, double valor)
        {
            switch (fila)
            {
                case "A":
                    FilaA = valor;
                    break;
                case "B":
                    FilaB = valor;
                    break;
                case "C":
                    FilaC = valor;
                    break;
                case "D":
                    FilaD= valor;
                    break;
                case "E":
                    FilaE = valor;
                    break;
                case "F":
                    FilaF = valor;
                    break;
                case "G":
                    FilaG = valor;
                    break;
                default:
                    MessageBox.Show("No existe esa fila");
                    break;
            }
            Resultado = (FilaA + FilaB + FilaC + FilaD + FilaE + FilaF + FilaG) / 7;
            lblCalificacion.Text = "CALIFICACIÓN: " + String.Format("{0:0.000}", Resultado) ;
            if(Resultado >= 3)
            {
                lblEstado.Text = "ESTADO: ACREDITADO";
            }
            else
            {
                lblEstado.Text = "ESTADO: NO ACREDITADO";
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CalificarGrupo) {
                Nucleo.miConexion.EvaluarGrupo(GrupoID, Estudiantes, int.Parse(FilaA.ToString()), int.Parse(FilaB.ToString()), int.Parse(FilaC.ToString()), int.Parse(FilaD.ToString()), int.Parse(FilaE.ToString()), int.Parse(FilaF.ToString()), int.Parse(FilaG.ToString()), Resultado);
                Nucleo.miConexion.InsertarNuevoLog("ha evaluado al grupo: " + GrupoID);


                MessageBox.Show("¡Se han evaluado a los alumnos correctamente!");
                this.Close();
            }
            else
            {
                Nucleo.miConexion.EvaluarAlumno(CreditoID, int.Parse(FilaA.ToString()), int.Parse(FilaB.ToString()), int.Parse(FilaC.ToString()), int.Parse(FilaD.ToString()), int.Parse(FilaE.ToString()), int.Parse(FilaF.ToString()), int.Parse(FilaG.ToString()), Resultado);
                Nucleo.miConexion.InsertarNuevoLog("ha evaluado el credito: " + CreditoID);


                MessageBox.Show("¡Se ha evaluado al alumno de manera correcta!");
                this.Close();
            }
        }

        private void rdA0_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("A", 0);
        }

        private void rdA1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("A", 1);

        }

        private void rdA2_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("A", 2);

        }

        private void rdA3_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("A", 3);

        }

        private void rdA4_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("A", 4);

        }

        private void rdB0_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("B", 0);

        }

        private void rdB1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("B", 1);

        }

        private void rdB2_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("B", 2);

        }

        private void rdB3_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("B", 3);

        }

        private void rdB4_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("B", 4);

        }

        private void rdC0_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("C", 0);

        }

        private void rdC1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("C", 1);
        }

        private void rdC2_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("C", 2);
        }

        private void rdC3_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("C", 3);
        }

        private void rdC4_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("C", 4);
        }

        private void rdD1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("D", 1);
        }

        private void rdD2_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("D", 2);
        }

        private void rdD3_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("D", 3);
        }

        private void rdD4_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("D", 4);
        }
        //Es cero xd
        private void rdD5_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("D", 0);
        }

        private void rdE0_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("E", 0);
        }

        private void rdE1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("E", 1);
        }

        private void rdE2_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("E", 2);
        }

        private void rdE3_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("E", 3);
        }

        private void rdE4_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("E", 4);
        }

        private void rdF0_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("F", 0);
        }

        private void rdF1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("F", 1);
        }

        private void rdF2_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("F", 2);
        }

        private void rdF3_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("F", 3);
        }

        private void rdF4_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("F", 4);
        }

        private void rdG4_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("G", 4);
        }

        private void rdG3_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("G", 3);
        }

        private void rdG2_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("G", 2);
        }

        private void rdG1_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("G", 1);
        }

        private void rdG0_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarResultado("G", 0);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            rdA2.Checked = true;
            rdB2.Checked = true;
            rdC2.Checked = true;
            rdD2.Checked = true;
            rdE2.Checked = true;
            rdF2.Checked = true;
            rdG2.Checked = true;
        }

        private void lblExcelente_Click(object sender, EventArgs e)
        {
            rdA4.Checked =true;
            rdB4.Checked =true;
            rdC4.Checked =true;
            rdD4.Checked =true;
            rdE4.Checked =true;
            rdF4.Checked =true;
            rdG4.Checked =true;
        }

        private void lblNotable_Click(object sender, EventArgs e)
        {
            rdA3.Checked = true;
            rdB3.Checked = true;
            rdC3.Checked = true;
            rdD3.Checked = true;
            rdE3.Checked = true;
            rdF3.Checked = true;
            rdG3.Checked = true;
        }

        private void lblSuficiente_Click(object sender, EventArgs e)
        {
            rdA1.Checked = true;
            rdB1.Checked = true;
            rdC1.Checked = true;
            rdD1.Checked = true;
            rdE1.Checked = true;
            rdF1.Checked = true;
            rdG1.Checked = true;
        }

        private void lblInsuficiente_Click(object sender, EventArgs e)
        {
            rdA0.Checked = true;
            rdB0.Checked = true;
            rdC0.Checked = true;
            rdD0.Checked = true;
            rdE0.Checked = true;
            rdF0.Checked = true;
            rdG0.Checked = true;
        }
    }
}
