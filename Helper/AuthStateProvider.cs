using LaboratorioRamos.Data.DtoStateProvider;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace LaboratorioRamos.Helper
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        public AuthStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
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
                }));
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
