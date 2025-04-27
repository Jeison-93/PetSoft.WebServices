using PetSoft.WebServices.Data.Dto.User;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IAuthAppService
    {
      
        /// <summary>
        /// Inicio de sesión
        /// </summary>
        /// <returns></returns>
        public RequestResponse<UserAuthDto> Login(UserParamAuthDto request);
    }
}
