using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Models;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericTableController : ControllerBase
    {
        private readonly IGenericTableAppService _genericTableaAppService;

        public GenericTableController(IGenericTableAppService genericTableaAppService) 
        {
            _genericTableaAppService = genericTableaAppService;
        }

        [HttpGet]
        [Route("GetDocumenType")]
        public IEnumerable<GenericTableDto> GetDocumenType() 
        {
            return _genericTableaAppService.GetDocumentType();
        }


        [HttpGet]
        [Route("GetServiceState")]
        public IEnumerable<GenericTableDto> GetServiceState()
        {
            return _genericTableaAppService.GetServiceState();
        }

        [HttpGet]
        [Route("GetServiceType")]
        public IEnumerable<GenericTableDto> GetServiceType()
        {
            return _genericTableaAppService.GetServiceType();
        }

        [HttpGet]
        [Route("GetSpecies")]
        public IEnumerable<GenericTableDto> GetSpecies()
        {
            return _genericTableaAppService.GetSpecies();
        }

        [HttpGet]
        [Route("GetUserType")]
        public IEnumerable<GenericTableDto> GetUserType()
        {
            return _genericTableaAppService.GetUserType();
        }
    }
}
