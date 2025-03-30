using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto.Client;
using PetSoft.WebServices.Data.Dto.Pet;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetAppService _PetAppService;
        public PetController(IPetAppService PetAppService)
        {
            _PetAppService = PetAppService;
        }
        [HttpGet]
        [Route("Get")]

        public PetGetDto Get(int id)
        {
            return _PetAppService.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]

        public IEnumerable<PetGetDto> GetAll(int Client)
        {
            return _PetAppService.GetAll(Client);
        }


        [HttpPost]
        [Route("save")]

        public string save(PetSaveDto parameter)
        {
            return _PetAppService.Save(parameter);
        }

        [HttpPut]
        [Route("Update")]
        public string Update(PetUpdateDto parameter)
        {
            return _PetAppService.Update(parameter);
        }

        [HttpPut]
        [Route("ChangeState")]
         public string ChangeState(int Id )
        { 
            return (_PetAppService.ChangeState(Id));
        }
    }
}
