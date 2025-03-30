using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Client;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IClientAppService
    {
        public ClientGetDto Get(int id);
        public IEnumerable<ClientGetDto> GetAll();

        public  IEnumerable<ClientGetDto> GetState(int state);
        public string Save(ClientSaveDto parameter);
        public string Update(ClientUpdateDto parameter);
        public string ChangeState(int Id);
      
    }
    
}
