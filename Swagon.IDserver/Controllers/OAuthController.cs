using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Swagon.IDserver.Controllers
{
    [Route("myHome")]
    public class HomeController : Controller
    {
        [Route("myindex")]
        public IActionResult myIndex()
        {
            return Ok("yes im here im Home");
        }

        [Route("mySecret")]
        [Authorize]
        public IActionResult Secret()
        {
            return Ok("yes im here im secret");
        }

        //[Route("myAuth")]
        //public IActionResult myAuthenticate()
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes("aaaaaa_aaaa_aaaa_aaa_aaa");
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier,"corrrectUserID")
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //   // HttpContext.SignInAsync(userprincipal);

        //    return Ok($"yes just Autherised : {tokenString} ");
        //}

        [Route("myAuth")]
        [HttpGet]
        public IActionResult CheckAuthToekn()
        {
            //check the Auth token here
            
            return Ok($"checking the access token [GET] ");
        }

        [Route("myAuth")]
        [HttpPost]
        public IActionResult GetAuthToken(string UserName, string Password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("aaaaaa_aaaa_aaaa_aaa_aaa");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,"corrrectUserID")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // HttpContext.SignInAsync(userprincipal);
            return Ok($" Generating Auth Token [Put] {tokenString}");
        }

        [Route("myTocken")]
        [HttpPost]
        public IActionResult PostToken()
        {
            return Ok("this is your post tocken");
        }

        [Route("myTocken")]
        [HttpGet]
        public IActionResult GetToken()
        {
            return Ok("this is your get tocken");

        }
    }
}