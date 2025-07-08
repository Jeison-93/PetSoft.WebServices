using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Client;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;
using System.Linq.Expressions;
using System.Xml.Linq;
using Client = PetSoft.WebServices.Data.Models.Client;

namespace PetSoft.WebServices.Application
{
    public class ClientAppService : IClientAppService
    {
        private readonly PetsoftdbContext _context;

        public ClientAppService(PetsoftdbContext context)
        {
            _context = context;
        }

        public RequestResponse<ClientGetDto> Get(int id)
        {

            RequestResponse<ClientGetDto> response = new();
            try
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
                         Address = s.Address,
                         State = s.State,
                         StateDescription = s.State == 1 ? "activo" : "inactivo"
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

        public RequestResponse<IEnumerable<ClientGetDto>> GetAll()
        {
            RequestResponse<IEnumerable<ClientGetDto>> response = new();
            try
            {
                var result = _context.Client.AsNoTracking()
                    .Select(s => new ClientGetDto()
                    {
                        Id = s.Id,
                        DocumentNumber = s.DocumentNumber,
                        DocumentType = s.DocumentType,
                        Name = s.Name,
                        LastName = s.LastName,
                        Phone = s.Phone,
                        Address = s.Address,
                        Email = s.Email,
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





        public RequestResponse<string> Save(ClientSaveDto request)
        {
            RequestResponse<string> response = new();
            try
            {
                if (ExistClient(request.DocumentNumber))
                    return response.CreateUnsuccessful($"Ya existe un cliente con el número de documento {request.DocumentNumber}");

                var oClient = new Client();

                oClient.DocumentType = request.DocumentType;
                oClient.DocumentNumber = request.DocumentNumber;
                oClient.Name = request.Name;
                oClient.LastName = request.LastName;
                oClient.Email = request.Email;
                oClient.Address = request.Address;
                oClient.Phone = request.Phone;
                oClient.State = 1;
                _context.Client.Add(oClient);
                _context.SaveChanges();

                return response.CreateSuccessful("El cliente se creó exitosamente");
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }

        private bool ExistClient(string documentNumber)
        
            => _context.Client.AsNoTracking().Any(f => f.DocumentNumber == documentNumber);
        

        public RequestResponse<string> Update(ClientUpdateDto request)
        {
            RequestResponse<string> response = new();
            try
            {
                var oClient = _context.Client.AsNoTracking().FirstOrDefault(f => f.Id == request.Id);

                if (oClient == null)
                    return response.CreateUnsuccessful("No se encontró información para el Cliente");

                oClient.Name = request.Name;
                oClient.LastName = request.LastName;
                oClient.Email = request.Email;
                oClient.Address = request.Address;
                oClient.Phone = request.Phone;
                _context.Client.Update(oClient);
                _context.Entry(oClient).Property(r => r.Id).IsModified = false;
                _context.SaveChanges();

                return response.CreateSuccessful("La información del cliente se actualizó exitosamente");
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
                var oClient = _context.Client.AsNoTracking().FirstOrDefault(f => f.Id == Id);
                if (oClient == null)
                {
                    return response.CreateUnsuccessful("No se encontró información para el cliente");
                }

                oClient.State = (sbyte)(oClient.State == 1 ? 0 : 1);
                _context.Client.Update(oClient);
                _context.Entry(oClient).Property(response => response.Id).IsModified = false;
                _context.SaveChanges();

                return response.CreateSuccessful("El cambio de estado se realizó correctamente");
            }
            catch (Exception ex)
            {

                return response.CreateError(ex.Message);
            }
        }
       

        public RequestResponse<IEnumerable<GenericTableDto>> GetState()
        {
            RequestResponse<IEnumerable<GenericTableDto>> response = new();

            try
            {
                var result = _context.Client.AsNoTracking()
                    .Where(f => f.State == 1)
                    .Select(s => new GenericTableDto()
                    {
                        Code = s.Id.ToString(),
                        Description = $"{s.Name} {s.LastName}"
                    });

                return response.CreateSuccessful(result);
            }
            catch (Exception ex)
            {

                return response.CreateError(ex.Message);
            }
        }

       
    }
    
}
