using LaboratorioRamos.Data.DtoStateProvider;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace LaboratorioRamos.Helper
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly LaboratorioRamos.Configuration.SessionSettings _sessionSettings;

        public AuthStateProvider(ProtectedSessionStorage sessionStorage, IOptions<LaboratorioRamos.Configuration.SessionSettings> sessionOptions)
        {
            _sessionStorage = sessionStorage;
            _sessionSettings = sessionOptions.Value;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<DtoUserProvider>("TerSession");
                var userSes = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSes == null)
                {
                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }

                // Merge defaults from configuration if storage doesn't have them set (backward compatibility)
                if (userSes.TimeoutMinutes <= 0) userSes.TimeoutMinutes = _sessionSettings.TimeoutMinutes;
                if (userSes.AbsoluteExpirationMinutes <= 0) userSes.AbsoluteExpirationMinutes = _sessionSettings.AbsoluteExpirationMinutes;
                userSes.SlidingExpiration = _sessionSettings.SlidingExpiration;

                // Absolute expiration check
                var absoluteLifetime = DateTime.UtcNow - userSes.CreatedAtUtc;
                if (absoluteLifetime.TotalMinutes > userSes.AbsoluteExpirationMinutes)
                {
                    await _sessionStorage.DeleteAsync("TerSession");
                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }

                // Inactivity timeout check
                var inactivity = DateTime.UtcNow - userSes.LastActivityUtc;
                if (inactivity.TotalMinutes > userSes.TimeoutMinutes)
                {
                    await _sessionStorage.DeleteAsync("TerSession");
                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }

                // Sliding expiration: refresh last activity on access
                if (userSes.SlidingExpiration)
                {
                    userSes.LastActivityUtc = DateTime.UtcNow;
                    await _sessionStorage.SetAsync("TerSession", userSes);
                }

                //var sucursalesUser = "";
                //foreach (var userSuc in userSes.Sucursales) {
                //    sucursalesUser += $"{userSuc},";
                //}
                //sucursalesUser = sucursalesUser[..^1];

                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim("testsuncretr", userSes.testsuncretr.ToString()),
                    new Claim("testsunfltr", userSes.filtros.ToString()),
                    new Claim("type", userSes.Type.ToString()),

                }, "CustAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
        }

        public async Task UpdAuthenticationState(DtoUserProvider userSession)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null)
            {
                // Initialize timestamps on sign-in
                if (userSession.CreatedAtUtc == default)
                {
                    userSession.CreatedAtUtc = DateTime.UtcNow;
                }
                userSession.LastActivityUtc = DateTime.UtcNow;

                await _sessionStorage.SetAsync("TerSession", userSession);

                //var sucursalesUser = "";
                //foreach (var userSuc in userSession.Sucursales)
                //{
                //    sucursalesUser += $"{userSuc},";
                //}
                //sucursalesUser = sucursalesUser[..^1];

                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim("testsuncretr", userSession.testsuncretr.ToString()),
                    new Claim("testsunfltr", userSession.filtros.ToString()),
                    new Claim("type", userSession.Type.ToString()),
                }, "CustAuth"));
            }
            else
            {
                await _sessionStorage.DeleteAsync("TerSession");
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

    }
}
