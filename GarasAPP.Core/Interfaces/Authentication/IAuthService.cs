using GarasAPP.Core.Models;
using GarasAPP.Core.ViewModels;
using GarasAPP.Core.ViewModels.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Interfaces.Authentication
{
    public interface IAuthRepository : IBaseRepository<User, long>
    {
        Task<BaseResponseWithData<AuthModel>> GetTokenAsync(LoginRequestModel model);

        Task<BaseResponseWithData<AuthModel>> GetUserDataAsync(string ApplicationUserId);
    }
}
