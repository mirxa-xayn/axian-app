using Axian.Models.DatabaseModels.Main;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Axian.Core.Uow
{
    public interface IUnitOfWork
    {
        List<AxianEmployee> GetAllEmployees();
        int GetTotalEmployees();
        int GetTotalUsers();
        bool AddNewEmployee(AxianEmployee model);
        AxianUser AddNewUser(AxianUser model);
        bool UpdateEmployee(AxianEmployee model);
        bool DeleteEmployee(AxianEmployee model);
        List<AxianUser> GetAllUsers();
        AxianUser VerifyUser(string email,string password);
    }
}
