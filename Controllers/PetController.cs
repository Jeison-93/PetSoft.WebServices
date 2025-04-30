using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.DTO;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetAppService _petAppService;

        public PetController(IPetAppService petAppService)
        {
            _petAppService = petAppService;
        }

        /// <summary>
        /// Recupera todas las mascotas de un cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(GetAllPets))]
        public async Task<RequestResponse<IEnumerable<PetResponseDTO>>> GetAllPets(int client)
        {
            return await Task.Run(() =>
            {
                return _petAppService.GetAll(client);
            });
        }

        /// <summary>
        /// Recupera una Mascota por Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(GetById))]
        public async Task<RequestResponse<PetResponseDTO>> GetById(int Id)
        {
            return await Task.Run(() =>
            {
                return _petAppService.GetById(Id);
            });
        }

        /// <summary>
        /// Graba las mascotas de un cliente en la DB
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(Save))]
        public async Task<RequestResponse<string>> Save(PetRequestDTO request)
        {
            return await Task.Run(() =>
            {
                return _petAppService.Save(request);
            });
        }

        /// <summary>
        /// Actualiza una Mascota en la DB
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route(nameof(Update))]
        public async Task<RequestResponse<string>> Update(PetRequestUpdateDTO request)
        {
            return await Task.Run(() =>
            {
                return _petAppService.Update(request);
            });
        }

        /// <summary>
        /// Cambia el estado de una Mascota en la DB
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route(nameof(ChangeState))]
        public async Task<RequestResponse<string>> ChangeState(int Id)
        {
            return await Task.Run(() =>
            {
                return _petAppService.ChangeState(Id);
            });
        }
    }
}
