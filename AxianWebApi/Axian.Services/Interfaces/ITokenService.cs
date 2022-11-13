using Axian.Models.Generic;
using Axian.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Axian.Services.Interfaces
{
    public interface ITokenService
    {
        ReturnModel TokenGeneration(AxianUserInfo userData,bool isNewUser);
    }
}
