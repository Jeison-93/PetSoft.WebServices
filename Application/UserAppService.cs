using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;
using System.Xml.Linq;

namespace PetSoft.WebServices.Application
{
    public class UserAppService : IUserAppService
    {
        private readonly PetsoftdbContext _context;

        public UserAppService(PetsoftdbContext context)
        {
            _context = context;
        }
        public RequestResponse<UserGetDto> Get(int id)
        {
            RequestResponse<UserGetDto> response = new();
            try
            {
                var result = _context.User.AsNoTracking()
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
                            Addresss = s.Address,
                            UserType = s.UserType,
                            State = s.State,
                            StateDescription = s.State == 1 ? "Activo" : "Inactivo"
                        }).FirstOrDefault();// instruccion para recuperar el primer dato de la consulta

                if (result == null)
                    return response.CreateUnsuccessful("No se encontró información en la base de datos");

                return response.CreateSuccessful(result);
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }

        public RequestResponse<IEnumerable<UserGetDto>> GetAll()
        {
            RequestResponse<IEnumerable<UserGetDto>> response = new();
            try
            {
                var result = _context.User.AsNoTracking()
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
                     Addresss = s.Address,
                     UserType = s.UserType,
                     State = s.State,
                     StateDescription = s.State == 1 ? "Activo" : "Inactivo"

                 });

                if (!result.Any())
                    return response.CreateUnsuccessful("No se encontró información en la base de datos");

                return response.CreateSuccessful(result);
            }
            catch (Exception ex)
            {

                return response.CreateError(ex.Message);
            }



        }

        public RequestResponse<string> Save(UserSaveDto parameter)
        {
            RequestResponse<string> response = new();
            try
            {
                if (ExistUser(parameter.DocumentNumber))
                    return response.CreateUnsuccessful($"Ya existe un usuario con el número de documento {parameter.DocumentNumber}");



                if (ExistUserByEmail(parameter.Email))
                    return response.CreateUnsuccessful($"El correo {parameter.Email} ya se encutrana registrado");

                var oUser = new User();


                oUser.DocumentType = parameter.DocumentType;
                oUser.DocumentNumber = parameter.DocumentNumber;
                oUser.Name = parameter.Name;
                oUser.LastName = parameter.LastName;
                oUser.Password = parameter.Password;
                oUser.Phone = parameter.Phone;
                oUser.Email = parameter.Email;
                oUser.Address = parameter.Addresss;
                oUser.UserType = parameter.UserType;
                oUser.State = 1;

                _context.User.Add(oUser);
                _context.SaveChanges();

                return response.CreateSuccessful("El usuario se creó exitosamente");
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }
        
        private bool ExistUserByDoc(string documentNumber)
        {
            return _context.User.Any(f => f.DocumentNumber == documentNumber);
        }



        public RequestResponse<string> Update(UserUpdateDto parameter)
        {
            RequestResponse<string> response = new();
            try
            {
                var oUser = _context.User.AsNoTracking().FirstOrDefault(f => f.Id == parameter.Id);

                if (oUser == null)
                {
                    return response.CreateUnsuccessful("No se encontró información para el usuario");
                }

                oUser.Password = parameter.Password;
                oUser.Phone = parameter.Phone;
                oUser.Address = parameter.Address;
                oUser.UserType = parameter.UserType;
                oUser.State = parameter.State;
                oUser.Email = parameter.Email;
                oUser.DocumentType = parameter.DocumentType;
               

                _context.User.Update(oUser);
                _context.Entry(oUser).Property(r => r.Id).IsModified = false;
                _context.SaveChanges();

                return response.CreateSuccessful("La información del usuario se actualizó exitosamente");
            }
            catch (Exception ex)
            {

                return response.CreateError(ex.Message);
            }
            
        }

        public RequestResponse<string> ChangeState(int Id)
        {
            RequestResponse<string> response = new();
            try
            {
                var oUser = _context.User.AsNoTracking().FirstOrDefault(f => f.Id == Id);

                if (oUser == null)
                
                    return response.CreateUnsuccessful("No se encontró información para el usuario");


                oUser.State = (sbyte)(oUser.State == 1 ? 0 : 1);


                _context.User.Update(oUser);
                _context.Entry(oUser).Property(r => r.Id).IsModified = false;
                _context.SaveChanges();

                return response.CreateSuccessful("El cambio de estado se realió exitosamente");
            }
            catch (Exception ex)
            {

                return response.CreateError(ex.Message);
            }
        }

        

            private bool ExistUser(string documentNumber)
            => _context.User.AsNoTracking().Any(f => f.DocumentNumber == documentNumber);

            private bool ExistUserByEmail(string email)
            => _context.User.AsNoTracking().Any(f => f.Email == email);


           
        

        
        
    }
}
