using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {
        Task<UserInfoResponseModel> ValidateUser(UserLoginModel Model);

        Task<UserLoginSuccessModel> RegisterUser(UserRegisterModel Model);
    }
}
