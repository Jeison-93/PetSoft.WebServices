using MySqlX.XDevAPI;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Models;
using System.Xml.Linq;

namespace PetSoft.WebServices.Application
{
    public class ClientAppService : IClientAppService
    {
        readonly PetsoftdbContext _context;

        public ClientAppService(PetsoftdbContext context)
        {
            _context = context;
        }
        public ClientGetDto Get(int id)
        {
            var result = _context.Client
             .Where(f => f.Id == id)
                 .Select(s => new ClientGetDto()
                 {
                     Id = s.Id,
                     DocumentType = s.DocumentType,
                     DocumentNumber = s.DocumentNumber,
                     Name = s.Name,
                     LastName = s.LastName,
                     Phone = s.Phone,
                     Email = s.Email,
                     Addresss = s.Addresss,
                     State = s.State,
                     StateDescription = s.State == 1 ? "activo" : "inactivo"
                 }).FirstOrDefault();

            return result != null ? result : new ClientGetDto();
        }

        public IEnumerable<ClientGetDto> GetAll()
        {
            var result = _context.Client
                 .Select(s => new ClientGetDto()
                 {
                     Id = s.Id,
                     DocumentType = s.DocumentType,
                     DocumentNumber = s.DocumentNumber,
                     Name = s.Name,
                     LastName = s.LastName,
                     Phone = s.Phone,
                     Email = s.Email,
                     Addresss = s.Addresss,
                     State = s.State,
                     StateDescription = s.State == 1 ? "activo" : "inactivo"
                 });

            return result;
        }

        public IEnumerable<ClientGetDto> GetState(int state)
        {
            var result = _context.Client
             .Where(f => f.State == state)
                 .Select(s => new ClientGetDto()
                 {
                     Id = s.Id,
                     DocumentType = s.DocumentType,
                     DocumentNumber = s.DocumentNumber,
                     Name = s.Name,
                     LastName = s.LastName,
                     Phone = s.Phone,
                     Email = s.Email,
                     Addresss = s.Addresss,
                     State = s.State,
                     StateDescription = s.State == 1 ? "activo" : "inactivo"
                 });

            return result;

        }

        
    }
}