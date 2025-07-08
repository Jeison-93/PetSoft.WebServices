using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Helpers;
using System.Collections;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IUserAppService
    {
        /// <summary>
        /// Mètodo para recuperar un usuario por Id.
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns></returns>
        public RequestResponse<UserGetDto> Get(int id);
        /// <summary>
        /// Mètodo para recuperar una lista lista de usuarios
        /// </summary>
        /// <returns></returns>
        public RequestResponse<IEnumerable<UserGetDto>> GetAll();

        /// <summary>
        /// Mètodo para crear un usuario
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public RequestResponse<string> Save(UserSaveDto parameter);
        /// <summary>
        /// Mètodo para actualizar un usuario.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public RequestResponse<string> Update(UserUpdateDto parameter);

        public RequestResponse<string> ChangeState(int Id);

    }
}
