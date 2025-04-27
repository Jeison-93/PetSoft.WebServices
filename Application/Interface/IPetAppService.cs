using PetSoft.WebServices.Data.DTO;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IPetAppService
    {
        /// <summary>
        /// Recupera todas las Mascotas de un cliente
        /// </summary>
        /// <returns></returns>
        public RequestResponse<IEnumerable<PetResponseDTO>> GetAll(int client);
        /// <summary>
        /// Recupera una mascota por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RequestResponse<PetResponseDTO> GetById(int id);

        /// <summary>
        /// Graba las mascotas la bd
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestResponse<string> Save(PetRequestDTO request);

        /// <summary>
        /// Actualiza una mascota  en la bd
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestResponse<string> Update(PetRequestUpdateDTO request);

        /// <summary>
        /// Cambia el estado de una mascota 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestResponse<string> ChangeState(int id);
    }
}
