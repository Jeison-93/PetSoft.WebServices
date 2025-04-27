using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto.ClientService;
using PetSoft.WebServices.Data.Dto.ClientServices;
using PetSoft.WebServices.Data.Models;

namespace PetSoft.WebServices.Application
{
    public class AppointmentsAppService: IAppointmentsAppService
    {
        readonly PetsoftdbContext _context;
        public AppointmentsAppService(PetsoftdbContext context)
        {
            _context = context;
        }

        public AppointmentsGetDto get(FilterRequestDto param)
        {
            throw new NotImplementedException();
        }
    }
}
