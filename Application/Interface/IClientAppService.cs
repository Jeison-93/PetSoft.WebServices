using PetSoft.WebServices.Data.Dto;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IClientAppService
    {
        public ClientGetDto Get(int id);
        public IEnumerable<ClientGetDto> GetAll();

        public  IEnumerable<ClientGetDto> GetState(int state);
      
    }
    
}
