using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Models;
using System.Xml.Linq;

namespace PetSoft.WebServices.Application
{
    public class UserAppService : IUserAppService
    {
        readonly PetsoftdbContext _context;

        public UserAppService(PetsoftdbContext context)
        {
            _context = context;
        }
        public UserGetDto Get(int id)
        {
            var result = _context.User
                .Where(f => f.Id == id)
                .Select(s => new UserGetDto()
                {
                    Id = s.Id,
                    DocumentType = s.DocumentType,
                    DocumentNumber = s.DocumentNumber,
                    Name = s.Name,
                    LastName = s.LastName,
                    Password = s.Password,
                    Phone = s.Phone,
                    Email = s.Email,
                    Addresss = s.Addresss,
                    UserType = s.UserType,
                    State = s.State,
                    StateDescription = s.State == 1 ? "Activo" : "Inactivo"
                }).FirstOrDefault();// instruccion para recuperar el primer dato de la consulta

            return result != null ? result : new UserGetDto();
        }

        public IEnumerable<UserGetDto> GetAll()
        {
            var result = _context.User
                 .Select(s => new UserGetDto()
                 {
                     Id = s.Id,
                     DocumentType = s.DocumentType,
                     DocumentNumber = s.DocumentNumber,
                     Name = s.Name, 
                     LastName = s.LastName,
                     Password = s.Password,
                     Phone = s.Phone,
                     Email = s.Email,
                     Addresss = s.Addresss, 
                     UserType = s.UserType,
                     State = s.State,
                     StateDescription = s.State == 1 ? "Activo" : "Inactivo"

                 });

            return result;

        }

        public string Save(UserSaveDto parameter)
        {
            throw new NotImplementedException();
        }

        public string Update(UserUpdateDto parameter)
        {
            throw new NotImplementedException();
        }
    }
}
