using Axian.Core.Uow;
using Axian.Models.DatabaseModels.Main;
using Axian.Models.Generic;
using Axian.Models.User;
using Axian.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Axian.Services.Token
{
    public class TokenService : ITokenService
    {

        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IConfiguration config,IUnitOfWork unitOfWork)
        {
            _config = config;
            _unitOfWork = unitOfWork;
        }

        public  ReturnModel TokenGeneration(AxianUserInfo userData,bool isNewUser)
        {
            if (userData != null && userData.Username != null && userData.Password != null)
            {
                var user = VerifyUserCredentials(userData.Username, userData.Password);

                if (user != null || isNewUser)
                {
                    if (isNewUser && user ==null)
                    {
                         user= AddNewUser(userData.Username, userData.Password);
                    }
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("Email", user.Email),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return new ReturnModel()
                    {
                        data= new JwtSecurityTokenHandler().WriteToken(token),
                        Message="Logged In",
                        StatusCode=200
                    };
                }
                else
                {
                    return new ReturnModel()
                    {
                        data = null,
                        Message = "Username or Password incorrect!",
                        StatusCode = 401
                    };
                }
            }
            else
            {
                return new ReturnModel()
                {
                    data = null,
                    Message = "Username or Password incorrect!",
                    StatusCode = 500
                };
            }
        }

        public AxianUser VerifyUserCredentials(string email, string password)
        {
            return _unitOfWork.VerifyUser(email, password);
        }

        public AxianUser AddNewUser(string email, string password)
        {
            AxianUser model = new AxianUser()
            {
                Email = email,
                Password = password
            };
            return _unitOfWork.AddNewUser(model);
        }

    }
}
