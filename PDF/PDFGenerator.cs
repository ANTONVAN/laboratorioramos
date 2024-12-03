using LaboratorioRamos.Data.DtoImpresionResultados;
using LaboratorioRamos.Data.DtoMedico.DtoResponseMedicoPaciente;
using Microsoft.JSInterop;
using Microsoft.Extensions.Configuration;
using static MudBlazor.CategoryTypes;
using static System.Net.WebRequestMethods;
using System.IO;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Reflection.Metadata;
using MigraDoc.DocumentObjectModel;
using Document = MigraDoc.DocumentObjectModel.Document;
using MigraDoc.DocumentObjectModel.Shapes;
using Image = MigraDoc.DocumentObjectModel.Shapes.Image;
using MigraDoc.Rendering;
using MudBlazor.Charts;
using MigraDoc.DocumentObjectModel.Tables;
using PdfSharp;
using PdfSharp.Charting;
using LaboratorioRamos.Data.DtoCotizacion;
using LaboratorioRamos.Data.DtoEstudio;
using LaboratorioRamos.Data.DtoPaciente;
using System.Collections.Generic;
using MigraDoc.DocumentObjectModel.Visitors;
namespace LaboratorioRamos.PDF
{
    public class PDFGenerator
    {
        public void DownloadPDF(IJSRuntime js, MemoryStream archivo) {
            js.InvokeVoidAsync("DownloadPDF", "Estudio.pdf", Convert.ToBase64String(archivo.ToArray()));
        }
        public void ViewPDF(IJSRuntime js, string idIFrame, MemoryStream archivo) {
            js.InvokeVoidAsync("ViewPDF", idIFrame, Convert.ToBase64String(archivo.ToArray()));
        }
        public async Task ViewPDFOrder(IJSRuntime js, string idIFrame, MemoryStream archivo) {
            js.InvokeVoidAsync("ViewPDFOrder", idIFrame, Convert.ToBase64String(archivo.ToArray()));
        }
        public async Task<MemoryStream> CreatePDF(IConfiguration _config,IJSRuntime js,HttpClient Http, List<DtoResponseMedicoPacienteStudios> StudioSelect)
        {
            MemoryStream _ms = new();
            DtoImpresionResultados prinResultadoTrue = new()
            {
                Estudios = new(),
                MediosEnvio = new() { "Fisico", "Logos" },

            };
            DtoImpresionResultados prinResultadoFalse = new()
            {
                Estudios = new(),
                MediosEnvio = new() { "Fisico", "Logos" },
            };

            foreach (var item in StudioSelect)
            {
                var rowExiste = item.IsPathological == true ? prinResultadoTrue.Estudios.FirstOrDefault(op => op.SolicitudId == item.SolicitudId) : prinResultadoFalse.Estudios.FirstOrDefault(op => op.SolicitudId == item.SolicitudId);

                if (rowExiste == null)
                {
                    DtoSolicitudPDF solpdf = new()
                    {
                        SolicitudId = item.SolicitudId,
                        EstudiosId = new()
                    };
                    DtoEstudiosPDF estPdf = new()
                    {
                        EstudioId = item.EstudioId,
                        Tipo = 0
                    };
                    solpdf.EstudiosId.Add(estPdf);

                    if (item.IsPathological)
                    {
                        prinResultadoTrue.Estudios.Add(solpdf);
                    }
                    else
                    {
                        prinResultadoFalse.Estudios.Add(solpdf);
                    }


                }
                else
                {
                    DtoEstudiosPDF estPdf = new()
                    {
                        EstudioId = item.EstudioId,
                        Tipo = 0
                    };
                    rowExiste.EstudiosId.Add(estPdf);
                }
            }
            //Http.DefaultRequestHeaders.Remove("branchid");

            if (prinResultadoTrue.Estudios.Count > 0)
            {
                var sesExpediente = await Http.PostAsJsonAsync<DtoImpresionResultados>("services/records/api/ClinicResults/printResultFilePreview", prinResultadoTrue);
                switch (sesExpediente.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        byte[] buffer;
                        
                        using (Stream stream = sesExpediente.Content.ReadAsStream())
                        {
                            
                            buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, buffer.Length);
                            _ms = new MemoryStream(buffer);
                            //System.IO.File.WriteAllBytes($"wwwroot/ArchivosPDF/Estudios{DateTime.Now.Ticks}.pdf", buffer);
                        }
                        //await js.InvokeVoidAsync("open", $"{_config.GetSection("UrlArchivos").Value.Trim()}Estudios{DateTime.Now.Ticks}.pdf", "_blank");
                        return _ms;
                        



                        break;
                    case System.Net.HttpStatusCode.FailedDependency:
                        
                        return _ms;
                        break;
                    case System.Net.HttpStatusCode.BadRequest:
                        return _ms;
                        break;

                }
            }
            if (prinResultadoFalse.Estudios.Count > 0)
            {
                var sesExpediente = await Http.PostAsJsonAsync<DtoImpresionResultados>("services/records/api/ClinicResults/printResultFilePreview", prinResultadoFalse);
                switch (sesExpediente.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        byte[] buffer;
                        using (Stream stream = sesExpediente.Content.ReadAsStream())
                        {
                            
                            buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, buffer.Length);
                            _ms = new MemoryStream(buffer);
                            //System.IO.File.WriteAllBytes($"wwwroot/ArchivosPDF/Estudios{DateTime.Now.Ticks}.pdf", buffer);
                        }
                        //await js.InvokeVoidAsync("open", $"{_config.GetSection("UrlArchivos").Value.Trim()}Estudios{DateTime.Now.Ticks}.pdf", "_blank");
                        return _ms;
                        


                        break;
                    case System.Net.HttpStatusCode.FailedDependency:
                        return _ms;
                        break;
                    case System.Net.HttpStatusCode.BadRequest:
                        return _ms;
                        break;

                }
            }

            return _ms;
        }

        public async Task<MemoryStream> CreatePDFOrder(DtoGeneralesCotizacion _dtoGeneralesCotizacion, DtoPaciente _dtoPaciente, HashSet<DtoEstudioResponsePrice> _dtoEstudioResponsePrices, DtoCotizacion _cotizacionDraft)
        {
            MemoryStream _ms = new();

            Document doc = new();

            CrearDoctoOrder(doc, _dtoGeneralesCotizacion, _dtoPaciente, _dtoEstudioResponsePrices, _cotizacionDraft);

            PdfDocumentRenderer document = new PdfDocumentRenderer();
            document.Document = doc;
            document.RenderDocument();
            var ter = document.PdfDocument;

            ter.Save(_ms);
            return _ms;
        }

        private void CrearDoctoOrder(Document doc, DtoGeneralesCotizacion _dtoGeneralesCotizacion, DtoPaciente _dtoPaciente, HashSet<DtoEstudioResponsePrice> _dtoEstudioResponsePrices, DtoCotizacion _cotizacionDraft)
        {
            Section Sec1 = doc.AddSection();
            Image imgLabRamos = Sec1.Headers.Primary.AddImage(@"wwwroot/Images/logo.png");
            imgLabRamos.Height = "2.5cm";
            //imgLabRamos.Width = "5cm";
            imgLabRamos.LockAspectRatio = true;
            imgLabRamos.RelativeHorizontal = RelativeHorizontal.Margin;
            //imgLabRamos.RelativeVertical = RelativeVertical.Margin;
            imgLabRamos.Top = ShapePosition.Top;
            imgLabRamos.Left = ShapePosition.Right;
            imgLabRamos.WrapFormat.Style = WrapStyle.Through;

            var paragra = Sec1.Headers.Primary.AddParagraph();
            paragra.Format.Font.Size = 15;
            paragra.Format.Alignment = ParagraphAlignment.Left;
            paragra.Format.Font.Bold = true;
            paragra.AddText("Laboratorio Alfonso Ramos S.A. de C.V.");
            paragra.AddLineBreak();
            //paragra.Format.Font.Size = 15;
            paragra.AddText($"Orden de estudios: {_cotizacionDraft.clave}");
            paragra.AddLineBreak();
            paragra.Format.SpaceAfter = 20;


            paragra = Sec1.AddParagraph();
            paragra.AddText(" ");
            paragra.AddLineBreak();
            paragra.AddLineBreak();
            paragra.AddLineBreak();
            paragra.AddLineBreak();
            paragra.Format.Alignment = ParagraphAlignment.Left;
            paragra.Format.Font.Bold = true;
            paragra.Format.Font.Size = 12;
            paragra.AddText($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}");
            paragra.AddLineBreak();
            paragra.AddText($"Paciente: {(_dtoPaciente==null ? "" :_dtoPaciente.NombrePaciente)}");
            paragra.AddLineBreak();
            paragra.Format.SpaceAfter = 10;


            var table1 = doc.LastSection.AddTable();
            table1.Borders.Width = 0.5;

            table1.AddColumn("4cm");
            table1.AddColumn("12cm");

            
            foreach (var item in _dtoEstudioResponsePrices)
            {
                Row rowt = table1.AddRow();
                rowt.BottomPadding = 0;
                rowt.Format.LineSpacing = 1;
                //rowt.Format.Font.Size = 12;
                rowt.Format.Font.Bold = true;
                rowt.Cells[0].AddParagraph($"Clave: {item.Clave}");
                //rowt.Format.Font.Size = 15;
                rowt.Cells[1].AddParagraph(item.Nombre);
                //rowt = table1.AddRow();
                //rowt.Format.Font.Bold = false;
                rowt.Cells[0].AddParagraph($"Indicaciones");
                foreach (var itemindi in item.Indicaciones)
                {
                    rowt.Cells[1].AddParagraph(itemindi.Descripcion);
                }
                
            }
            table1.Format.SpaceAfter = 10;

            paragra = Sec1.AddParagraph();
            paragra.AddLineBreak();
            paragra.AddLineBreak();
            paragra.Format.Alignment = ParagraphAlignment.Left;
            paragra.Format.Font.Bold = true;
            //paragra.Format.Font.Size = 12;
            paragra.AddText($"OBSERVACIONES:");
            paragra.AddLineBreak();
            paragra.AddText(_dtoGeneralesCotizacion==null?"": String.IsNullOrEmpty(_dtoGeneralesCotizacion.Observaciones)?"": _dtoGeneralesCotizacion.Observaciones);
            paragra.AddLineBreak();
            paragra.Format.SpaceAfter = 10;

            //pie de pagina
            paragra = Sec1.Footers.Primary.AddParagraph();
            paragra.Format.Alignment = ParagraphAlignment.Right;
            paragra.AddText("Página: ");
            paragra.AddPageField();



        }
    }
}
