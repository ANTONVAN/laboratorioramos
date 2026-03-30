using LaboratorioRamos.Helper;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LaboratorioRamos.Services
{
    /// <summary>
    /// Guarda la ruta de destino tras login (sin query en la URL), asociada al flujo (tipo de usuario).
    /// Evita que un destino guardado para paciente se aplique al iniciar sesión como empresa, etc.
    /// </summary>
    public class LoginReturnUrlStore
    {
        private const string StorageKeyV2 = "LrPostLoginPendingV2";
        /// <summary>Formato antiguo (solo string); se elimina al leer.</summary>
        private const string LegacyStorageKey = "LrPostLoginReturnPath";

        private readonly ProtectedSessionStorage _sessionStorage;

        public LoginReturnUrlStore(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task SavePendingReturnFromFullUriAsync(string? fullUri)
        {
            if (string.IsNullOrEmpty(fullUri))
                return;

            try
            {
                var u = new Uri(fullUri);
                var pq = u.PathAndQuery;
                if (string.IsNullOrEmpty(pq) || pq == "/")
                    return;

                var expectedUserType = LoginRedirectHelper.GetExpectedUserTypeForFullUri(fullUri);
                await _sessionStorage.SetAsync(StorageKeyV2, new PendingLoginReturn
                {
                    PathAndQuery = pq,
                    ExpectedUserType = expectedUserType
                });
            }
            catch
            {
                // Prerender o almacenamiento no disponible
            }
        }

        /// <summary>
        /// Obtiene la ruta pendiente solo si coincide con el tipo de usuario que acaba de autenticarse; borra el valor almacenado.
        /// </summary>
        public async Task<string?> GetAndClearPendingReturnPathAsync(int actualUserType)
        {
            try
            {
                await _sessionStorage.DeleteAsync(LegacyStorageKey);

                var result = await _sessionStorage.GetAsync<PendingLoginReturn>(StorageKeyV2);
                await _sessionStorage.DeleteAsync(StorageKeyV2);

                if (!result.Success || result.Value == null)
                    return null;

                if (result.Value.ExpectedUserType != actualUserType)
                    return null;

                return result.Value.PathAndQuery;
            }
            catch
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Destino post-login pendiente con el flujo de login esperado.
    /// </summary>
    public sealed class PendingLoginReturn
    {
        public string PathAndQuery { get; set; } = "";
        public int ExpectedUserType { get; set; }
    }
}
