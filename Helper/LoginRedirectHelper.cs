using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace LaboratorioRamos.Helper
{
    /// <summary>
    /// Selecciona la pantalla de login según la ruta solicitada y valida returnUrl (mismo origen).
    /// El destino post-login se persiste en sesión del navegador; <see cref="GetSafeReturnPathFromNavigation"/> cubre enlaces antiguos con query.
    /// </summary>
    public static class LoginRedirectHelper
    {
        /// <summary>
        /// Ruta de login (relativa a la app) según el primer segmento de ruta y el tipo de flujo (1/2/3).
        /// </summary>
        public static string GetLoginPathForRelativeUrl(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return "/";

            var p = relativePath.TrimStart('/').ToLowerInvariant();

            if (IsMedicoPath(p))
                return "/Medico";

            if (IsEmpresaPath(p))
                return "/Empresa";

            if (p.StartsWith("impresionresultados", StringComparison.Ordinal))
                return "/Consulta";

            return "/";
        }

        private static bool IsMedicoPath(string p)
        {
            return p.StartsWith("consultaresultadospaciente/2/", StringComparison.Ordinal)
                   || p.StartsWith("consultaresultadospacientes/2/", StringComparison.Ordinal)
                   || p.StartsWith("consultagraficapaciente/2/", StringComparison.Ordinal)
                   || p.StartsWith("consultaexpedientesmedico", StringComparison.Ordinal)
                   || p.StartsWith("consultasolicitudes/2", StringComparison.Ordinal)
                   || p.StartsWith("creaorden/2", StringComparison.Ordinal)
                   || p.StartsWith("resultadoestudios/2/", StringComparison.Ordinal);
        }

        private static bool IsEmpresaPath(string p)
        {
            return p.StartsWith("consultaresultadospaciente/3/", StringComparison.Ordinal)
                   || p.StartsWith("consultaresultadospacientes/3/", StringComparison.Ordinal)
                   || p.StartsWith("consultagraficapaciente/3/", StringComparison.Ordinal)
                   || p.StartsWith("consultaexpedientesempresa", StringComparison.Ordinal)
                   || p.StartsWith("consultasolicitudes/3", StringComparison.Ordinal)
                   || p.StartsWith("creaorden/3", StringComparison.Ordinal)
                   || p.StartsWith("resultadoestudios/3/", StringComparison.Ordinal);
        }

        /// <summary>
        /// Solo la ruta de login (p. ej. <c>/Medico</c>). El destino tras autenticarse se guarda con <see cref="LaboratorioRamos.Services.LoginReturnUrlStore"/>.
        /// </summary>
        public static string GetLoginPathFromFullUri(string? fullUri)
        {
            if (string.IsNullOrEmpty(fullUri))
                return "/";

            try
            {
                var u = new Uri(fullUri);
                return GetLoginPathForRelativeUrl(u.PathAndQuery.TrimStart('/'));
            }
            catch
            {
                return "/";
            }
        }

        /// <summary>
        /// Tipo de usuario esperado para la pantalla de login a la que se redirige (coincide con <c>DtoUserProvider.Type</c>).
        /// </summary>
        public static int GetExpectedUserTypeForFullUri(string? fullUri)
        {
            return GetLoginPathFromFullUri(fullUri) switch
            {
                "/Medico" => 2,
                "/Empresa" => 3,
                "/Consulta" => 4,
                _ => 1
            };
        }

        /// <summary>
        /// Tipo de usuario al que pertenece la ruta de retorno (para validar query <c>returnUrl</c> y evitar cruces de rol).
        /// </summary>
        public static int GetExpectedUserTypeForReturnPath(string? pathAndQuery)
        {
            if (string.IsNullOrWhiteSpace(pathAndQuery))
                return 1;

            var p = pathAndQuery.TrimStart('/').ToLowerInvariant();
            var pathOnly = p.Split('?')[0];

            if (IsMedicoPath(pathOnly))
                return 2;
            if (IsEmpresaPath(pathOnly))
                return 3;
            if (pathOnly.StartsWith("impresionresultados", StringComparison.Ordinal))
                return 4;

            return 1;
        }

        /// <summary>
        /// Devuelve path+query seguro para redirigir tras login (solo misma app), o null.
        /// Acepta <c>returnUrl</c> relativo (recomendado) o absoluto mismo origen (compatibilidad).
        /// </summary>
        public static string? GetSafeReturnPathFromNavigation(NavigationManager navigationManager)
        {
            try
            {
                var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);
                var parsed = QueryHelpers.ParseQuery(uri.Query);
                if (!parsed.TryGetValue("returnUrl", out var values))
                    return null;

                var raw = values.FirstOrDefault().ToString();
                if (string.IsNullOrEmpty(raw))
                    return null;

                var decoded = Uri.UnescapeDataString(raw).Trim();
                if (string.IsNullOrEmpty(decoded))
                    return null;

                var baseAbs = navigationManager.ToAbsoluteUri(navigationManager.BaseUri);
                var origin = baseAbs.GetLeftPart(UriPartial.Authority);

                // Formato preferido: solo ruta (y query) de la app, ej. /ConsultaExpedientesMedico/
                if (decoded.StartsWith('/') && !decoded.StartsWith("//", StringComparison.Ordinal))
                {
                    if (Uri.TryCreate(baseAbs, decoded, out var resolved))
                    {
                        if (string.Equals(resolved.GetLeftPart(UriPartial.Authority), origin, StringComparison.OrdinalIgnoreCase))
                        {
                            var pq = resolved.PathAndQuery;
                            if (!string.IsNullOrEmpty(pq) && pq != "/")
                                return pq;
                        }
                    }
                    return null;
                }

                // Compatibilidad: returnUrl absoluto antiguo (mismo origen)
                if (Uri.TryCreate(decoded, UriKind.Absolute, out var abs))
                {
                    if (!string.Equals(abs.GetLeftPart(UriPartial.Authority), origin, StringComparison.OrdinalIgnoreCase))
                        return null;

                    var pathAndQuery = abs.PathAndQuery;
                    if (!string.IsNullOrEmpty(pathAndQuery) && pathAndQuery != "/")
                        return pathAndQuery;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Como <see cref="GetSafeReturnPathFromNavigation"/> pero solo si la ruta corresponde al tipo de usuario que inicia sesión.
        /// </summary>
        public static string? GetSafeReturnPathForUserType(NavigationManager navigationManager, int userType)
        {
            var candidate = GetSafeReturnPathFromNavigation(navigationManager);
            if (string.IsNullOrEmpty(candidate))
                return null;
            return GetExpectedUserTypeForReturnPath(candidate) == userType ? candidate : null;
        }
    }
}
