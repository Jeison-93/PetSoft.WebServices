using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericTableController : ControllerBase
    {
        private readonly IGenericTableAppService _genericTableAppService;

        public GenericTableController(IGenericTableAppService genericTableAppService)
        {
            _genericTableAppService = genericTableAppService;
        }

        [HttpGet]
        [Route(nameof(GetTable))]
        public async Task<RequestResponse<IEnumerable<GenericTableDto>>> GetTable(string table)
        {
            return await Task.Run(() =>
            {
                return _genericTableAppService.Get(table);
            });
        }
    }
}
