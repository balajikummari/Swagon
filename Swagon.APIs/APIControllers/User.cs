using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swagon.Services;

namespace Swagon.APIs.APIControllers
{
    public class AppSettings
    {
        public string Secret = "12b6fb24-adb8-4ce5-aa49-79b265ebf256";
    }

    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AppSettings _appSettings;

        public User(IUserService service, AppSettings appSettings)
        {
            userService = service;
            _appSettings = appSettings;
        }

        [Authorize]
        [HttpGet("getbyid")]
        public DomainModel.User GetUserById(string id)
        {
            return userService.GetUserById(id);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public void Signup(DomainModel.User user)
        {
            userService.AddUser(user);
        }
    }
}