using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto.User;

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
        [Route("Login")]
        public UserAuthDto Login(UserParamAuthDto request)
        {
            return _appService.Login(request);
        }
    }

}
