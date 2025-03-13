using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<UserGetDto> GetAll()
        {
            return _userAppService.GetAll();
        }

        [HttpGet]
        [Route("Get")]
        public UserGetDto Get(int id)
        {
            return _userAppService.Get(id);
        }
    }
}
