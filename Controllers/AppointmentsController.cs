using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto.ClientService;
using PetSoft.WebServices.Data.Dto.ClientServices;
using PetSoft.WebServices.Helpers;
using System.Threading.Tasks;

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



        [HttpPost]
        [Route(nameof(Get))]
        public async Task<RequestResponse<IEnumerable<AppointmentsGetDto>>> Get(FilterRequestDto param)
        {
            return await Task.Run(() =>
            {
                return _AppointmentsService.getService(param);
            });
        }

        [HttpGet]
        [Route(nameof(GetById))]
        public async Task<RequestResponse<AppointmentsResponseDto>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                return _AppointmentsService.GetById(id);
            });
        }
        [HttpPost]
        [Route(nameof(Save))]
        public async Task<RequestResponse<string>> Save(AppointmentsRequestDto param)
        {
            return await Task.Run(() =>
            {
                return _AppointmentsService.save(param);

            });
        }
        [HttpPut]
        [Route(nameof(update))]
        public async Task<RequestResponse<string>> update(AppointmentsUpdateDto param)
        {
            return await Task.Run(() =>
            {
                return _AppointmentsService.update(param);
            });
        }
        [HttpPut]
        [Route(nameof(ChangeState))]
        public async Task<RequestResponse<string>> ChangeState(AppointmentsChangeStateDto param)
        {
            return await Task.Run(() =>
            {
                return _AppointmentsService.ChangeState(param);
            });
        }
        [HttpGet]
        [Route(nameof(GetByState))]
        public async Task<RequestResponse<IEnumerable<AppointmentsResponseDto>>> GetByState(string state)
        {
            return await Task.Run(() =>
            {
                return _AppointmentsService.GetByState(state);
            });
        }
    }
}
