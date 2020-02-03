using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SistemaDeCreditos.Clases
{
    class PDF
    {
        public static string ruta = @"C:\Users\Public\";

        public void GenerarConstancia(string _nombreEstudiante, string _noControl, string _carrera, string _actividadTitulo, string _nivelDesempeño, string _calificacion, string _periodoEscolar, string _peso, string _dia, string _mes, string _año, string _responsable, string _jefe, string _departamento, string _responsableID, string _jefeID)
        {

            #region IMPORTACION DE FUENTES
                //CalibriNormal
                BaseFont calibrix = BaseFont.CreateFont("C:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font calibri = new iTextSharp.text.Font(calibrix, 11);
                //CalibriBold
                BaseFont calibriBoldx = BaseFont.CreateFont("C:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font calibriBold = new iTextSharp.text.Font(calibriBoldx, 11);
                //Calibri CursivaBold
                BaseFont calibriBoldCx = BaseFont.CreateFont("C:\\windows\\fonts\\calibriz.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font calibriBoldC = new iTextSharp.text.Font(calibriBoldCx, 11);
            #endregion

            //Especificaciones del documento en general
            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(60, 60, 0, 0);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta + "constancia.pdf", FileMode.Create));
                doc.AddTitle("Constancia");
                doc.AddCreator("Tecnologico De Nuevo Laredo");
                doc.Open();

                
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(calibrix, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                var normalFont = calibri;
                var boldFont = calibriBold;

                #region COMPONENTES ABSOLUTOS

                /*
                    TAMAÑOS
                    -> HEADER & FOOTER 
                        WIDTH: 612
                        HEIGHT: 75
                    -> WATER MARK
                        WIDTH:
                        HEIGHT
                */

                //MARCA DE AGUA
                Image watermark = Image.GetInstance(@".\src\img\bg.png");
                    watermark.SetAbsolutePosition(0, 0);
                     doc.Add(watermark);

                    //HEADER
                    iTextSharp.text.Image header = iTextSharp.text.Image.GetInstance(@".\src\img\header.png");
                    header.ScaleAbsoluteWidth(doc.PageSize.Width);
                    header.ScaleAbsoluteHeight(75);
                    header.SetAbsolutePosition(0, (doc.PageSize.Height - 95));
                    header.Alignment = Image.ALIGN_CENTER;
                    doc.Add(header);

                    //FOOTER
                    iTextSharp.text.Image footer = iTextSharp.text.Image.GetInstance(@".\src\img\footer.png");
                    footer.ScaleAbsoluteWidth(doc.PageSize.Width);
                    footer.ScaleAbsoluteHeight(75);
                    footer.SetAbsolutePosition(0, 0);
                    footer.BackgroundColor = BaseColor.BLUE;
                    doc.Add(footer);




                /*

               #region Datos extraidos de la base de datos
                    //Independientemente de la cantidad de parametros a agregar deberan de ser interpolados dentro de 'footerPhrase'
                    string Num1 = "7119067";
                    string Num2 = "7119050";
                    string Email = "sistemasycomputacion@nlaredo.tecn.mx";
                #endregion
                #region Bloque de texto que se coloca en el pie de pagina
                    Phrase footerPhrase = new Phrase();
                    footerPhrase.Add(new Chunk("Av. Reforma #2007 (Sur), Col. Infonavit Fundadores, C.P. 88275, Nuevo Laredo, Tam. \n "));
                    footerPhrase.Add(new Chunk($"Tels. (867){Num1} Conmut {Num2} Ext. 117. \n"));
                    footerPhrase.Add(new Chunk($"e-mail {Email} \n"));
                    footerPhrase.Add(new Chunk("www.itnuevolaredo.edu.mx"));
                    #region Especificaciones de estilos en el texto
                        Paragraph footerParagrap = new Paragraph(footerPhrase);
                        //Tamaño de fuente
                        footerParagrap.Font.Size = 9;
                        //Espaciado entre lineas  
                        footerParagrap.SetLeading(0, float.Parse("1.2"));
                        //Alineamiento del texto
                        footerParagrap.Alignment = Element.ALIGN_CENTER;
                    #endregion
                #endregion
                #region Colocamiento del footer 
                    ColumnText footerC = new ColumnText(writer.DirectContent);
                    //La variables doc debe ser remplazada por la variable de tipo Document que represente el reporte, en caso de ser mas grande el cuadro de texto cambiar el ultimo parametro al Height adecuado
                    footerC.SetSimpleColumn(new Rectangle(0, 0, doc.PageSize.Width, 60));
                    footerC.AddElement(footerParagrap);
                    footerC.Alignment = Element.ALIGN_CENTER;
                    footerC.Go();
                #endregion
             */


                //ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, footerParagrap, 300, 40, 0);



                #endregion









                //SECCION 1
                var phrase = new Phrase();
                phrase.Add(new Chunk("\n\n\n\n\n\n\n\n\nASUNTO:  ", normalFont));
                phrase.Add(new Chunk("CONSTANCIA DE CUMPLIMIENTO \n DE ACTIVIDAD COMPLEMENTARIA\n", boldFont));
                Paragraph f1 = new Paragraph(phrase);
                f1.Alignment = Element.ALIGN_RIGHT;
                doc.Add(f1);

                //SECCION 2
                Paragraph f2 = new Paragraph(new Phrase("C. HUMBERTO PENA VALLE \nJEFE DEL DEPTO.DE SERVICIOS ESCOLARES \nINSTITUTO TECNOLOGICO DE NUEVO LAREDO \nPresente.- \n" +
                    "", boldFont));
                f2.Alignment = Element.ALIGN_LEFT;
                doc.Add(f2);

                //Seccion 3
                var phrase2 = new Phrase();
                phrase2.Add(new Chunk("               Por medio de la presente, se permite hacer de su conocimiento que el estudiante ", normalFont));
                phrase2.Add(new Chunk((_nombreEstudiante + " "), boldFont));
                phrase2.Add(new Chunk("con número de control ", normalFont));
                phrase2.Add(new Chunk(_noControl, boldFont).SetUnderline(1, -2));
                phrase2.Add(new Chunk(" alumno(a) de la carrera de ", normalFont));
                phrase2.Add(new Chunk(_carrera + "  ", boldFont));
                phrase2.Add(new Chunk("de esta institución de estudios, ha cumplido su actividad complementaria ", normalFont));
                phrase2.Add(new Chunk("“" + _actividadTitulo + "” ", normalFont).SetUnderline(1, -2));
                phrase2.Add(new Chunk(" con el nivel de desempeño ", normalFont));
                phrase2.Add(new Chunk(_nivelDesempeño, normalFont).SetUnderline(1, -2));
                phrase2.Add(new Chunk(" y un valor numérico de ", normalFont));
                phrase2.Add(new Chunk(" " + _calificacion + " ", normalFont).SetUnderline(1, -2));
                phrase2.Add(new Chunk(", durante el período escolar ", normalFont));
                phrase2.Add(new Chunk(" " + _periodoEscolar + " ", normalFont).SetUnderline(1, -2));
                phrase2.Add(new Chunk("con un valor curricular de ", normalFont));
                phrase2.Add(new Chunk(" 1 ", normalFont).SetUnderline(1, -2));
                phrase2.Add(new Chunk(" crédito.\n\n Se extiende la presente en la ciudad de Nuevo Laredo, Tamaulipas a los " + _dia + " días del mes de " + _mes + "  de " + _año + ".", normalFont));

               




                Paragraph f3 = new Paragraph(phrase2);
                f3.Alignment = Element.ALIGN_JUSTIFIED;
                f3.SetLeading(0, 2);
                doc.Add(f3);

                //Seccion 4
                var phrase3 = new Phrase();
                phrase3.Add(new Chunk(" A T E N T A M E N T E. \n ", boldFont));
                phrase3.Add(new Chunk("“Con la ciencia por la humanidad” \n\n", calibriBoldC));
                Paragraph f4 = new Paragraph(phrase3);
                f4.Alignment = Element.ALIGN_CENTER;
                f4.SetLeading(0, 2);
                doc.Add(f4);


                //Seccion 5
                // --> Traer depirt

                PdfPTable table = new PdfPTable(2);

                
                var phrase4 = new Phrase();
                phrase4.Add(new Chunk(Nucleo.miConexion.ConsultarTituloDePersonal(_responsableID) + " " +_responsable + " \n", boldFont));
                phrase4.Add(new Chunk(" RESPONSABLE \n", normalFont));
                Paragraph f5 = new Paragraph(phrase4);
                f5.Alignment = Element.ALIGN_CENTER;
                PdfPCell cell = new PdfPCell(f5);
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                cell.PaddingLeft = 30;
               


                var phrase5 = new Phrase();
                phrase5.Add(new Chunk(Nucleo.miConexion.ConsultarTituloDePersonal(_jefeID)+" " + _jefe + " \n", boldFont));
                phrase5.Add(new Chunk(" JEFE(A) DE " + _departamento + "\n", normalFont));
                Paragraph f6 = new Paragraph(phrase5);
                f6.Alignment = Element.ALIGN_CENTER;
                PdfPCell cell2 = new PdfPCell(f6);
                cell2.HorizontalAlignment = 1;
                cell2.Border = 0;
                cell2.PaddingRight = 30;
                table.AddCell(cell);
                table.AddCell(cell2);
                table.WidthPercentage = 100f;
                doc.Add(table);

                //LEGENDA
                var phrase6 = new Phrase();
                phrase6.Add(new Chunk("\n\n\n\nC.c.p. archivo\n\n\n\n", normalFont));
                doc.Add(phrase6);

               

                doc.Close();
                writer.Close();
                string pdfPath = Path.Combine(Application.StartupPath, ruta + "constancia.pdf");

                Process.Start(pdfPath);
            }
            catch
            {
                MessageBox.Show("Debe cerrar el archivo constancia.pdf para poder actualizarlo");
            }

        }
        public void ExportarListaDeBusqueda(List<Estudiante> _estudiantes) 
        {
            try
            {
                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta + "exportar.pdf", FileMode.Create));

                doc.AddCreator("Tecnologico De Nuevo Laredo");
                doc.Open();
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                doc.Add(new Paragraph("\n\n\n"));
                PdfPTable table = new PdfPTable(3);
                foreach (Estudiante x in _estudiantes)
                {
                    table.AddCell(new PdfPCell(new Paragraph(x.NumeroDeControl)));
                    table.AddCell(new PdfPCell(new Paragraph(x.Nombre.TrimEnd() + " " + x.ApellidoPaterno.TrimEnd())));
                    table.AddCell(new PdfPCell(new Paragraph(x.CreditosTerminados.ToString())));

                }
                doc.Add(table);
                doc.Close();
                writer.Close();
                string pdfPath = Path.Combine(Application.StartupPath, ruta + "exportar.pdf");
                Process.Start(pdfPath);
            }
            catch
            {
                MessageBox.Show("Debe cerrar el archivo exportar.pdf para poder actualizarlo");
            }
        }
        public void ExportarGrupo(List<Estudiante> _estudiantes, string _grupoName, string _tipoActividad, string _responsable)
        {
            try
            {
                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta + "exportar.pdf", FileMode.Create));

                doc.AddCreator("Tecnologico De Nuevo Laredo");
                doc.Open();
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                //MARCA DE AGUA
                Image watermark = Image.GetInstance(@".\src\img\bg.png");
                watermark.SetAbsolutePosition(0, 0);
                doc.Add(watermark);

                //HEADER
                iTextSharp.text.Image header = iTextSharp.text.Image.GetInstance(@".\src\img\header.png");
                header.ScaleAbsoluteWidth(doc.PageSize.Width);
                header.ScaleAbsoluteHeight(75);
                header.SetAbsolutePosition(0, (doc.PageSize.Height - 95));
                header.Alignment = Image.ALIGN_CENTER;
                doc.Add(header);

                


                doc.Add(new Paragraph("\n\n\n\n\n\n               Grupo: " + _grupoName + "\n                Actividad: " + _tipoActividad + "\n                Responsable del grupo: " + _responsable));

                doc.Add(new Paragraph("\n\n\n"));
                PdfPTable table = new PdfPTable(2);
                float[] widths = new float[] { 20f, 80f };
                table.SetWidths(widths);
                foreach (Estudiante x in _estudiantes)
                {
                    table.AddCell(new PdfPCell(new Paragraph(x.NumeroDeControl)));
                    table.AddCell(new PdfPCell(new Paragraph(x.Nombre.TrimEnd() + " " + x.ApellidoPaterno.TrimEnd())));
                }
                doc.Add(table);
                doc.Close();
                writer.Close();
                string pdfPath = Path.Combine(Application.StartupPath, ruta + "exportar.pdf");
                Process.Start(pdfPath);
            }
            catch
            {
                MessageBox.Show("Debe cerrar el archivo exportar.pdf para poder actualizarlo");
            }
        }
        public static void ExportarReporte(Reporte _reporte, string fecha)
        {


            try
            {
                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta + "exportarReporte.pdf", FileMode.Create));

                doc.AddCreator("Tecnologico De Nuevo Laredo");
                doc.Open();
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                //MARCA DE AGUA
                Image watermark = Image.GetInstance(@".\src\img\bg.png");
                watermark.SetAbsolutePosition(0, 0);
                doc.Add(watermark);

                //HEADER
                iTextSharp.text.Image header = iTextSharp.text.Image.GetInstance(@".\src\img\header.png");
                header.ScaleAbsoluteWidth(doc.PageSize.Width);
                header.ScaleAbsoluteHeight(75);
                header.SetAbsolutePosition(0, (doc.PageSize.Height - 95));
                header.Alignment = Image.ALIGN_CENTER;
                doc.Add(header);




                doc.Add(new Paragraph("\n\n\n\n\n\n               " + _reporte.Titulo+ "\n                Fecha: " + fecha + "\n                Carrera: " + _reporte.Carrera));

                doc.Add(new Paragraph("\n\n\n"));
                PdfPTable table = new PdfPTable(2);
                float[] widths = new float[] { 20f, 80f };
                table.SetWidths(widths);
                foreach (Estudiante x in _reporte.Estudiantes)
                {
                    table.AddCell(new PdfPCell(new Paragraph(x.NumeroDeControl)));
                    table.AddCell(new PdfPCell(new Paragraph(x.Nombre.TrimEnd() + " " + x.ApellidoPaterno.TrimEnd())));
                }
                doc.Add(table);
                doc.Close();
                writer.Close();
                string pdfPath = Path.Combine(Application.StartupPath, ruta + "exportarReporte.pdf");
                Process.Start(pdfPath);
            }
            catch
            {
                MessageBox.Show("Debe cerrar el archivo exportarReporte.pdf para poder actualizarlo");
            }


             
        }
        public static void AbrirManual()
        {
            try
            {
                string pdfPath = Path.Combine(Application.StartupPath, "manual.pdf");
                Process.Start(pdfPath);
            }
            catch
            {
                MessageBox.Show($"No se pudo abrir: {Application.StartupPath}manual.pdf");
            }
        }
    }
}
