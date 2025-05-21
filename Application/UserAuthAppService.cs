using Microsoft.EntityFrameworkCore;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.User;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application.Interface
{
    public class UserAuthAppService : IAuthAppService
    {
        readonly PetsoftdbContext _context;
        public UserAuthAppService(PetsoftdbContext context)
        {
            _context = context;
        }

        public RequestResponse<UserAuthDto> Login(UserParamAuthDto request)
        {
            RequestResponse<UserAuthDto> response = new();
            try
            {
                var result = _context.User.AsNoTracking()
                    .Where(f => f.Email == request.Email && f.Password == request.Password  && f.State == 1)
                    .Select(s => new UserAuthDto()
                    {   Id  = s.Id,
                        DocumentNumber = s.DocumentNumber,
                        DocumentType = s.DocumentType,
                        Name = s.Name,
                        LastName = s.LastName,
                        Phone = s.Phone,
                        Address = s.Address,
                        Email = s.Email,
                        UserType = s.UserType,
                    }).FirstOrDefault();

                if (result == null)
                    return response.CreateUnsuccessful("No se encontró información en la base de datos");

                return response.CreateSuccessful(result);
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }
    }
}
