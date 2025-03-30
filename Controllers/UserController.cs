using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application;
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

        [HttpPost]
        [Route("Save")]
        public string Save(UserSaveDto parameter)
        {
            return _userAppService.Save(parameter);
        }

        [HttpPut]
        [Route("Update")]
        public string Update(UserUpdateDto parameter)
        {
            return _userAppService.Update(parameter);
        }


        [HttpPut]
        [Route("ChangeState")]
        public string ChangeState(int Id)
        {
            return (_userAppService.ChangeState(Id));
        }
    }
}
