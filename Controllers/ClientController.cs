using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Client;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientAppService _ClientAppService;
        public ClientController(IClientAppService ClientAppService)
        {
            _ClientAppService = ClientAppService;
        }
        [HttpGet]
        [Route("Get")]
        public ClientGetDto Get(int id)
        {
            return _ClientAppService.Get(id);
        }


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ClientGetDto>  GetAll()
        {
            return _ClientAppService.GetAll();
        }

        [HttpGet]
        [Route("GetState")]
        public IEnumerable<ClientGetDto> GetState(int state)
        {
            return _ClientAppService.GetState(state);
        }

        [HttpPost]
        [Route("Save")]
        public string Save(ClientSaveDto parameter)
        {
            return _ClientAppService.Save(parameter);
        }

        [HttpPut]
        [Route("Update")]
        public string Update(ClientUpdateDto parameter)
        {
            return _ClientAppService.Update(parameter);
        }

    }
}