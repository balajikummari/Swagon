using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Swagon.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            { //var idToken = await HttpContext.GetTokenAsync("id_token");
              //var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
              //var claims = User.Claims.ToList();
              //var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
              //var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken); 
            } // just cheking

            var result = await GetSecureCityData(accessToken);
            //await RefreshAccessToken();
            return Ok(result.ToString());

        }

        public async Task<string> GetSecureCityData(string accessToken)
        {
            var apiClient = _httpClientFactory.CreateClient();
            apiClient.SetBearerToken(accessToken);
            var response = await apiClient.GetAsync("https://localhost:44374/api/citys");
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        private async Task RefreshAccessToken()
        {
            var serverClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44376/");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var refreshTokenClient = _httpClientFactory.CreateClient();

            var tokenResponse = await refreshTokenClient.RequestRefreshTokenAsync(
                new RefreshTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    RefreshToken = refreshToken,
                    ClientId = "MVCclient_id",
                    ClientSecret = "MVCclient_Secret"
                });

            var authInfo = await HttpContext.AuthenticateAsync("Cookie");

            authInfo.Properties.UpdateTokenValue("access_token", tokenResponse.AccessToken);
            authInfo.Properties.UpdateTokenValue("id_token", tokenResponse.IdentityToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", tokenResponse.RefreshToken);

            await HttpContext.SignInAsync("Cookie", authInfo.Principal, authInfo.Properties);
        }

        [HttpGet]
        public IActionResult Logout(string LogoutId)
        {
            return SignOut("Cookie", "oidc");
        }
    }
}