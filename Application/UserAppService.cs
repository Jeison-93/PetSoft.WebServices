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
            if (ExistUser(parameter.Email))
            {
                return "El correo ya está registrado";
            }

            if (ExistUserByDoc(parameter.DocumentNumber))
            {
                return "el numero de documento ya existe en otro registro";
            }


            User user =new();
            user.DocumentType = parameter.DocumentType;
            user.DocumentNumber = parameter.DocumentNumber;
            user.Name = parameter.Name;
            user.LastName = parameter.LastName;
            user.Password = parameter.Password;
            user.Phone = parameter.Phone;
            user.Email = parameter.Email;
            user.Addresss = parameter.Addresss;
            user.UserType = parameter.UserType;
            user.State = 1;

            _context.User.Add(user);
            _context.SaveChanges();


            return "Registro Exitoso";
        }
        
        private bool ExistUserByDoc(string documentNumber)
        {
            return _context.User.Any(f => f.DocumentNumber == documentNumber);
        }

        private bool ExistUser(string email)
        {
            return _context.User.Any(f => f.Email == email);
        }

        public string Update(UserUpdateDto parameter)
        {
            try
            {
                User user = _context.User.FirstOrDefault(f => f.Id == parameter.Id);
                if (user == null)
                {
                    return "El usuario no existe";
                }

                user.Password = parameter.Password;
                user.Phone = parameter.Phone;
                user.Addresss = parameter.Addresss;
                user.UserType = parameter.UserType;
                user.State = parameter.State;

                _context.User.Update(user);
                _context.SaveChanges();

                return "Se actualizó correctamente";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }

        public string ChangeState(int Id)
        {
            try
            {
                User user = _context.User.FirstOrDefault(f => f.Id == Id);
                if (user == null)
                {
                    return "El usuario no existe";
                }

                user.State = (sbyte)(user.State == 1 ? 0 : 1);


                _context.User.Update(user);
                _context.SaveChanges();

                return "Se actualizó correctamente";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
