using Axian.Core.Uow;
using Axian.Models.DatabaseModels.Main;
using Axian.Models.User;
using Axian.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Axian.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _config;

        public UserService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public AxianUser AddNewUser(UserModel model)
        {
            try
            {
                AxianUser user = new AxianUser()
                {
                    Email=model.Email,
                    Password=model.Password
                };
                return _unitOfWork.AddNewUser(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<AxianUser> GetAllUsers()
        {
            try
            {
                return _unitOfWork.GetAllUsers();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetTotalUsers()
        {
            try
            {
                return _unitOfWork.GetTotalUsers();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
