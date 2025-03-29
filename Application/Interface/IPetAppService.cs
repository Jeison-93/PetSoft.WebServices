using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Pet;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IPetAppService
    {
        public PetGetDto Get(int id);
        public string Save(PetSaveDto parameter);

        public IEnumerable <PetGetDto> GetAll(int Client);
        public string Update(PetUpdateDto parameter);

    }
}
