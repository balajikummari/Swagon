using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Swagon.ClientApi.Controller
{
    [Route("client")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("GetMyTocken")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //retrieve access token
            var HttpClient = _httpClientFactory.CreateClient();

            var discoveryDocument = await HttpClient.GetDiscoveryDocumentAsync("https://localhost:44376/");

            var tokenResponse = await HttpClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "ResAPiclient_id",
                    ClientSecret = "ResApiclient_secret",
                });

            //retrieve secret data
            var apiClient = _httpClientFactory.CreateClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:44374/api/citys");

            var content = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
                access_token = tokenResponse.AccessToken,
                message = content,
            });
        }
    }
}