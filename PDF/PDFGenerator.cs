using LaboratorioRamos.Data.DtoImpresionResultados;
using LaboratorioRamos.Data.DtoMedico.DtoResponseMedicoPaciente;
using Microsoft.JSInterop;
using Microsoft.Extensions.Configuration;
using static MudBlazor.CategoryTypes;
using static System.Net.WebRequestMethods;
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
            Http.DefaultRequestHeaders.Remove("branchid");

            if (prinResultadoTrue.Estudios.Count > 0)
            {
                var sesExpediente = await Http.PostAsJsonAsync<DtoImpresionResultados>("LabRamos/services/records/api/ClinicResults/printResultFilePreview", prinResultadoTrue);
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
                var sesExpediente = await Http.PostAsJsonAsync<DtoImpresionResultados>("LabRamos/services/records/api/ClinicResults/printResultFilePreview", prinResultadoFalse);
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
    }
}
