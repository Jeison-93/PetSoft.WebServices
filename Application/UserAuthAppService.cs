using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.User;
using PetSoft.WebServices.Data.Models;

namespace PetSoft.WebServices.Application.Interface
{
    public class UserAuthAppService : IAuthAppService
    {
        readonly PetsoftdbContext _context;
        public UserAuthAppService(PetsoftdbContext context)
        {
            _context = context;
        }
        public UserAuthDto Login(UserParamAuthDto request)
        {
            var result = _context.User
                .Where(f => f.Email == request.Email && f.Password == request.Password && f.State ==1 )
                .Select(s => new UserAuthDto()
                {
                    DocumentType = s.DocumentType,
                    DocumentNumber = s.DocumentNumber,
                    Name = s.Name,
                    LastName = s.LastName,
                    Password = s.Password,
                    Phone = s.Phone,
                    Email = s.Email,
                    Addresss = s.Addresss,
                    UserType = s.UserType,

                }).FirstOrDefault();// instruccion para recuperar el primer dato de la consulta

            return result != null ? result : new UserAuthDto();
        }
    }
}
