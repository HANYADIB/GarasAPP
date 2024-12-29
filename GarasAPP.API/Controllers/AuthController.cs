using GarasAPP.Core.Interfaces.Authentication;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models;
using GarasAPP.Core.ViewModels;
using GarasAPP.Core.ViewModels.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IRoleRepository _roleRepository;
        //private readonly IUserRoleRepository _userRoleRepository;



        public AuthController(IAuthRepository authRepository, IRoleRepository roleRepository)
        {
            _authRepository = authRepository;
            _roleRepository = roleRepository;
        }


        private string ApplicationUserId
        {
            get
            {
                string UserId = User.FindFirstValue("uid");
                return UserId;
            }
        }

        
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] LoginRequestModel model)
        {
            BaseResponseWithData<AuthModel> Response = new BaseResponseWithData<AuthModel>();

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Response = await _authRepository.GetTokenAsync(model);
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }



        [Authorize]
        //Role ==> GetUserData
        [HttpGet("UserData")]
        public async Task<IActionResult> GetUserDataAsync()
        {
            BaseResponseWithData<AuthModel> Response = new BaseResponseWithData<AuthModel>();
            //bool hasRole = _roleRepository.HasRole("GetUserData", ApplicationUserId);
            try
            {

                var tempResponse = await _authRepository.GetUserDataAsync(ApplicationUserId);
                if (!_roleRepository.HasRole("GetUserData", ApplicationUserId))
                {
                    return BadRequest(Response); 
                }
                Response = tempResponse;
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }

    }
}
