using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto.ClientService;
using PetSoft.WebServices.Data.Dto.ClientServices;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsAppService _AppointmentsService;
  
        public AppointmentsController(IAppointmentsAppService appointmentsAppService)
        {
            _AppointmentsService = appointmentsAppService;
        }



        [HttpGet]
        [Route("Get")]
        public AppointmentsGetDto Get(FilterRequestDto param)
        {
            return _AppointmentsService.get(param);    
        }
    }
}
