using Axian.Models.Employee;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _empService;

        public EmployeeController(IEmployeeService empService)
        {
            _empService = empService;
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
            => Ok( _empService.GetAllEmployees());

        [HttpGet("GetTotalEmployees")]
        public IActionResult GetTotalEmployees()
            => Ok(_empService.GetTotalEmployees());

        [HttpPost("AddNewEmployee")]
        public IActionResult AddNewEmployee(EmployeeModel model)
            => Ok(_empService.AddNewEmployee(model));

        [HttpPost("UpdateEmployee")]
        public IActionResult UpdateEmployee(EmployeeModel model)
            => Ok(_empService.UpdateEmployee(model));

        [HttpPost("DeleteEmployee")]
        public IActionResult DeleteEmployee(EmployeeModel model)
            => Ok(_empService.DeleteEmployee(model));

    }
}
