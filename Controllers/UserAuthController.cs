using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto.User;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IAuthAppService _appService;
        public UserAuthController(IAuthAppService appService)
        {
            _appService = appService;
        }



        [HttpPost]
        [Route(nameof(RequestLogin))]
        public async Task<RequestResponse<UserAuthDto>> RequestLogin(UserParamAuthDto request)
        {
            return await Task.Run(() =>
            {
                return _appService.Login(request);
            });
        }

    }
}


