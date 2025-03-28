using MySqlX.XDevAPI;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Client;
using PetSoft.WebServices.Data.Models;
using System.Xml.Linq;
using Client = PetSoft.WebServices.Data.Models.Client;

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


        public string Save(ClientSaveDto parameter)
        {
            try
            {
                if (ExistClient(parameter.DocumentNumber))
                {
                    return "el número de documento ya existe en otro registro";
                }

                Client client = new();
                client.DocumentType = parameter.DocumentType;
                client.DocumentNumber = parameter.DocumentNumber;
                client.Name = parameter.Name;
                client.LastName = parameter.LastName;
                client.Phone = parameter.Phone;
                client.Email = parameter.Email;
                client.Addresss = parameter.Addresss;
                client.State = 1;

                _context.Client.Add(client);
                _context.SaveChanges();


                return "Registro Exitoso";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            

        }

        private bool ExistClient(string documentNumber)
        {
            return _context.Client.Any(f => f.DocumentNumber == documentNumber);
        }

        public string Update(ClientUpdateDto parameter)
        {
            try
            {
                Client client = _context.Client.FirstOrDefault(f => f.Id == parameter.Id);
                if (client == null)
                {
                    return "El usuario no existe";
                }

                client.Phone = parameter.Phone;
                client.Email = parameter.Email;
                client.Addresss = parameter.Addresss;
                client.State = parameter.State;

                _context.Client.Update(client);
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