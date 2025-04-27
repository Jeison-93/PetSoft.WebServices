using PetSoft.WebServices.Data.Dto.ClientService;
using PetSoft.WebServices.Data.Dto.ClientServices;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IAppointmentsAppService
    {
        public AppointmentsGetDto get(FilterRequestDto param);
    }
}
