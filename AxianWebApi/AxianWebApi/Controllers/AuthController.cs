using Axian.Models.User;
using Axian.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxianWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var basicAuthenticationIdentity = FetchAuthHeader() as string[];

            AxianUserInfo user = new AxianUserInfo()
            {
                Username = basicAuthenticationIdentity[0] ,
                Password = basicAuthenticationIdentity[1],
            };

            var res = _tokenService.TokenGeneration(user,false);

            if (res!=null)
            {
                return Ok(res);
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpPost("Signup")]
        public IActionResult Signup()
        {
            var basicAuthenticationIdentity = FetchAuthHeader() as string[];

            AxianUserInfo user = new AxianUserInfo()
            {
                Username = basicAuthenticationIdentity[0],
                Password = basicAuthenticationIdentity[1],
            };

            var res = _tokenService.TokenGeneration(user,true);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return Unauthorized();
            }
        }

        private object FetchAuthHeader()
        {
            string authHeaderValue = Request.Headers["Authorization"]; ;

            authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeaderValue.Split(' ')[1]));
            var credentials = authHeaderValue.Split(':');
            return credentials.Length < 2 ? null : credentials;
        }
    }
}
