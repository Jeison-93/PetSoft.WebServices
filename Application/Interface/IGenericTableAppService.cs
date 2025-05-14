using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IGenericTableAppService
    {
        public RequestResponse<IEnumerable<GenericTableDto>> Get(string table);

    }
}
