using LaboratorioRamos.Data.DtoMedico.DtoResponseMedicoPaciente;

namespace LaboratorioRamos.Helper
{
    /// <summary>
    /// Visibilidad de estudios en perfiles: laboratorio solo con estatus 7;
    /// imagenología (departamentos 2 y 7) se muestra sin ese filtro.
    /// </summary>
    public static class EstudioDisplayHelper
    {
        public const int EstatusEnviado = 7;
        public const int DepartamentoImagenologia = 2;
        public const int DepartamentoImagenologiaAlt = 7;

        public static bool EsImagenologia(int? departamentoId) =>
            departamentoId == DepartamentoImagenologia || departamentoId == DepartamentoImagenologiaAlt;

        public static bool DebeMostrarseEnListado(int estatusId, int? departamentoId) =>
            EsImagenologia(departamentoId) || estatusId == EstatusEnviado;

        public static bool DebeMostrarseEnResultadosLaboratorio(int? estatusId, int? departamentoId) =>
            !EsImagenologia(departamentoId) && estatusId == EstatusEnviado;

        public static bool DebeMostrarseEnListado(DtoResponseMedicoPacienteStudios estudio)
        {
            if (estudio == null) return false;
            return DebeMostrarseEnListado(estudio.EstatusId, estudio.DepartamentoId);
        }

        public static List<DtoResponseMedicoPacienteStudios> FiltrarListado(
            IEnumerable<DtoResponseMedicoPacienteStudios> estudios)
        {
            if (estudios == null) return new List<DtoResponseMedicoPacienteStudios>();
            return estudios.Where(DebeMostrarseEnListado).ToList();
        }
    }
}
