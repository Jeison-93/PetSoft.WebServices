using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Client;
using PetSoft.WebServices.Helpers;

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
        [Route(nameof(Get))]
        public async Task<RequestResponse<ClientGetDto>> Get(int Id)
        {
            return await Task.Run(() =>
            {
                return _ClientAppService.Get(Id);
            });
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<RequestResponse<IEnumerable<ClientGetDto>>> GetAll()
        {
            return _ClientAppService.GetAll();
        }

        [HttpGet]
        [Route(nameof(GetState))]
        public async Task<RequestResponse<IEnumerable<GenericTableDto>>> GetState()
        {
            return await Task.Run(() =>
            {
                return _ClientAppService.GetState();
            });
        }

        [HttpPost]
        [Route(nameof(Save))]
        public async Task<RequestResponse<string>> Save(ClientSaveDto parameter)
        {
            return await Task.Run(() =>
            {
                return _ClientAppService.Save(parameter);
            });
                
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<RequestResponse<string>> Update(ClientUpdateDto parameter)
        {
            return await Task.Run(() =>
            {
                return _ClientAppService.Update(parameter);
            });
        }

        [HttpPut]
        [Route(nameof(ChangeState))]
        public async Task<RequestResponse<string>> ChangeState(int Id)
        {   
            return await Task.Run(()=>
            { 
            return _ClientAppService.ChangeState(Id);
            });
        }

    }
}