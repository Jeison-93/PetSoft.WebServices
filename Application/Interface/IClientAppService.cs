using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Client;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IClientAppService
    {
        /// <summary>
        /// recupera un cliente por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RequestResponse<ClientGetDto> Get(int id);
        /// <summary>
        /// recupera todos los clientes
        /// </summary>
        /// <returns></returns>
        public RequestResponse<IEnumerable<ClientGetDto>> GetAll();
        /// <summary>
        /// recupera los clientes  por estado(activo-inactivo)
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>

        public RequestResponse<IEnumerable<GenericTableDto>> GetState();
        /// <summary>
        /// graba un cliente en la base de datos
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public RequestResponse <string> Save(ClientSaveDto parameter);
        /// <summary>
        /// actualiza un cliente en la bd
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public RequestResponse<string> Update(ClientUpdateDto parameter);
        /// <summary>
        /// cambia el estado de un cliente(activo>inactivo)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RequestResponse<string> ChangeState(int Id);
      
    }
    
}
