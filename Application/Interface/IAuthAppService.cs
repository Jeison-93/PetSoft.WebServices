using PetSoft.WebServices.Data.Dto.User;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IAuthAppService
    {
        public UserAuthDto Login(UserParamAuthDto  request);
    }
}
