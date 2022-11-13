using Axian.Models.DatabaseModels.Main;
using Axian.Models.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Axian.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<AxianEmployee> GetAllEmployees();
        int GetTotalEmployees();
        bool AddNewEmployee(EmployeeModel model);
        bool UpdateEmployee(EmployeeModel model);
        bool DeleteEmployee(EmployeeModel model);
    }
}
