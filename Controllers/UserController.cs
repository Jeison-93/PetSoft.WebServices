using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Helpers;

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


        /// <summary>
        /// recupera todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<RequestResponse<IEnumerable<UserGetDto>>> GetAll()
        {
            return await Task.Run(() =>
            {
                return _userAppService.GetAll();
            });
        }

        /// <summary>
        /// recupera un usuario por el ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(Get))]
        public async Task<RequestResponse<UserGetDto>> Get(int Id)
        {
            return await Task.Run(() =>
            {
                return _userAppService.Get(Id);
            });
        }

        /// <summary>
        /// graba un usuario en la bd.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(Save))]
        public async Task<RequestResponse<string>> Save(UserSaveDto parameter)
        {
            return _userAppService.Save(parameter);
        }
        /// <summary>
        /// actualiza un usuario en la bd.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(nameof(Update))]
        public async Task<RequestResponse<string>> Update(UserUpdateDto parameter)
        {
            return _userAppService.Update(parameter);
        }

        /// <summary>
        /// cambia el estado de un usuario en la bd.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(nameof(ChangeState))]
        public async Task<RequestResponse<string>> ChangeState(int Id)
        {
            return await Task.Run(() =>
            {
                return _userAppService.ChangeState(Id);
            });
        }
    }
}
