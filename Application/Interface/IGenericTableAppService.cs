using PetSoft.WebServices.Data.Dto;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IGenericTableAppService
    {
        public IEnumerable<GenericTableDto> GetDocumentType();
        public IEnumerable<GenericTableDto> GetUserType();
        public IEnumerable<GenericTableDto> GetServiceType();
        public IEnumerable<GenericTableDto> GetServiceState();
        public IEnumerable<GenericTableDto> GetSpecies();

    }
}
