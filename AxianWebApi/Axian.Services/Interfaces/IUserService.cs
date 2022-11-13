using Axian.Models.DatabaseModels.Main;
using Axian.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Axian.Services.Interfaces
{
    public interface IUserService
    {
      
        List<AxianUser> GetAllUsers();
        int GetTotalUsers();
        AxianUser AddNewUser(UserModel model);
    }
}
