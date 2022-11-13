using Axian.Models.User;
using Axian.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxianWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public  IActionResult GetAllUsers()
            => Ok( _userService.GetAllUsers());

        [HttpGet("GetTotalUsers")]
        public IActionResult GetTotalUsers()
            => Ok(_userService.GetTotalUsers());

        [HttpPost("AddNewUser")]
        public IActionResult AddNewUser(UserModel model)
            => Ok(_userService.AddNewUser(model));

    }
}
