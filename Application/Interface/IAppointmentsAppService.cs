using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Client;
using PetSoft.WebServices.Data.Dto.ClientService;
using PetSoft.WebServices.Data.Dto.ClientServices;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IAppointmentsAppService
    {
        /// <summary>
        /// recupera todos los servicios de un cliente
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RequestResponse<IEnumerable<AppointmentsGetDto>> getService(FilterRequestDto param);
        /// <summary>
        /// actualiza un servicio para la mascota en la bd
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RequestResponse<string> update(AppointmentsUpdateDto param);
        /// <summary>
        /// recupera una mascota por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RequestResponse<AppointmentsResponseDto> GetById(int id);
        /// <summary>
        /// graba un servicio para la mascota en la bd
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RequestResponse<string> save(AppointmentsRequestDto param);
        /// <summary>
        /// cambia el estado de un servicio
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RequestResponse<string> ChangeState(AppointmentsChangeStateDto param);
        /// <summary>
        /// recupera todos los servicios por estado
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RequestResponse<IEnumerable<AppointmentsResponseDto>> GetByState(string param);
    }
}
