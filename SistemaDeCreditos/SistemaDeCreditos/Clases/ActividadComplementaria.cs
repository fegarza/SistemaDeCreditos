using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCreditos.Clases
{
    public class ActividadComplementaria
    {


        #region PROPIEDADES
        public char EstadoDeLaFirma;
        public string Departamento;
        public string ActividadTitulo;
        public int Peso;
        public string Responsable;
        public char EstadoDeLaActividad;
        public DateTime FechaDeOficio;
        public string Seccion;
        public int Periodo;
        public string Jefe;
        public int Pregunta1;
        public int Pregunta2;
        public int Pregunta3;
        public int Pregunta4;
        public int Pregunta5;
        public int Pregunta6;
        public int Pregunta7;
        public double Promedio;


        //SE REMPLAZARA
        public int ActividadID;
        //POR:
        public Actividad ActividadInstancia;

        public int JefeID;
        public int ResponsableID;
        public int CreditoID;
        #endregion
        
        public ActividadComplementaria(int _peso,int _creditoID,string _nombreActividad,int _actividadID,int _jefeID,string _jefe,int _responsableID,string _responsable,char _estado,DateTime _fechaDeOficio,int _periodo,int _pregunta1,int _pregunta2,int _pregunta3,int _pregunta4,int _pregunta5,int _pregunta6,int _pregunta7,double _promedio,char _charEstadoDeLaFirma,string _seccion)
        {
            Peso = _peso;
            Jefe = _jefe;
            Responsable = _responsable;
            CreditoID = _creditoID;
            ActividadTitulo = _nombreActividad;
            ActividadID = _actividadID;
            JefeID = _jefeID;
            ResponsableID = _responsableID;
            EstadoDeLaActividad = _estado;
            FechaDeOficio = _fechaDeOficio;
            Periodo = _periodo;
            Pregunta1 = _pregunta1;
            Pregunta2 = _pregunta2;
            Pregunta3 = _pregunta3;
            Pregunta4 = _pregunta4;
            Pregunta5 = _pregunta5;
            Pregunta6 = _pregunta6;
            Pregunta7 = _pregunta7;
            Promedio = _promedio;
            EstadoDeLaFirma = _charEstadoDeLaFirma;
            Seccion = _seccion;
        }



    }
}
