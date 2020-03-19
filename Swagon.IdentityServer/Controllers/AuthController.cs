using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleInjector;
using Swagon.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Swagon.IdentityServer.Controllers
{
    public class AuthController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserService DbUserManager;


        public AuthController(
           UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

            var container = new Container();
            container.Register<IUserService, UserService>(Lifestyle.Transient);
            ServiceDependencies.AddServiceDeps(container);
            container.Verify();
            DbUserManager = container.GetInstance<IUserService>();

        }

        [HttpGet]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            var externalProviders = await _signInManager.GetExternalAuthenticationSchemesAsync();

            return View(new LoginViewModel()
            {
                ReturnUrl = ReturnUrl,
                ExternalProviders = externalProviders
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {

            var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);
            var user = _userManager.Users.Where(e => e.UserName == vm.Username && e.PasswordHash == vm.Password);
            if (result.Succeeded)
            {
                return Redirect(vm.ReturnUrl);
            }
            else if (result.IsLockedOut)
            {

            }
            return View();
        }

        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUri = Url.Action(nameof(ExteranlLoginCallback), "Auth", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUri);
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExteranlLoginCallback(string returnUrl)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }

            var result = await _signInManager
                .ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }

            var username = info.Principal.FindFirst(ClaimTypes.Name.Replace(" ", "_")).Value;
            return View("ExternalRegister", new ExternalRegisterViewModel
            {
                Username = username,
                ReturnUrl = returnUrl
            });
        }



        public async Task<IActionResult> ExternalRegister(ExternalRegisterViewModel vm)
        {

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }

            var user = new IdentityUser(vm.Username);
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                return View(vm);
            }

            result = await _userManager.AddLoginAsync(user, info);

            if (!result.Succeeded)
            {
                return View(vm);
            }

            await _signInManager.SignInAsync(user, false);


            return Redirect(vm.ReturnUrl);
        }

        [HttpGet]
        public IActionResult Register(string ReturnUrl)
        {
            return View(new RegisterViewModel() { returnUrl = ReturnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid) { return View(vm); }
            var user = new IdentityUser(vm.Username);
            var result = await _userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                DbUserManager.AddUser(new DomainModel.User()
                {
                    Username = user.UserName,
                    Password = user.PasswordHash,
                    Id = user.Id
                });
                return Redirect(vm.returnUrl);
            }
            return View();
        }

        [HttpGet]
        public async void Logout(string LogoutId)
        {
            await _signInManager.SignOutAsync();
        }
    }
}