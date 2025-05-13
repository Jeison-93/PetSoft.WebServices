using Microsoft.EntityFrameworkCore;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Client;
using PetSoft.WebServices.Data.Dto.ClientService;
using PetSoft.WebServices.Data.Dto.ClientServices;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application
{
    public class AppointmentsAppService : IAppointmentsAppService
    {
        readonly PetsoftdbContext _context;
        public AppointmentsAppService(PetsoftdbContext context)
        {
            _context = context;
        }

        public RequestResponse<string> ChangeState(AppointmentsChangeStateDto param)
        {
            throw new NotImplementedException();
        }

        public RequestResponse<AppointmentsResponseDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RequestResponse<IEnumerable<AppointmentsResponseDto>> GetByState(string param)
        {
            throw new NotImplementedException();
        }

        public RequestResponse<IEnumerable<AppointmentsGetDto>> getService(FilterRequestDto param)
        {
            throw new NotImplementedException();
        }

        public RequestResponse<string> save(AppointmentsRequestDto param)
        {
            throw new NotImplementedException();
        }

        public RequestResponse<string> update(AppointmentsUpdateDto param)
        {
            throw new NotImplementedException();
        }
    }
}