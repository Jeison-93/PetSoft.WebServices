using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Client;
using PetSoft.WebServices.Data.Dto.ClientService;
using PetSoft.WebServices.Data.Dto.ClientServices;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;
using System.Net.Sockets;

namespace PetSoft.WebServices.Application
{
    public class AppointmentsAppService : IAppointmentsAppService
    {
        readonly PetsoftdbContext _context;
        public AppointmentsAppService(PetsoftdbContext context)
        {
            _context = context;
        }

        public RequestResponse<string> ChangeState(AppointmentsChangeStateDto param)
        {
            RequestResponse<string> response = new();
            try
            {
                var oClient = _context.Clientservice.AsNoTracking().FirstOrDefault(f => f.Id == param.Id);

                if (oClient == null)
                    return response.CreateUnsuccessful("No se encontró información para el servicio");

                if (param.ServiceState == "CAN")
                {
                    _context.Clientservice.Remove(oClient);
                    _context.SaveChanges();

                    return response.CreateSuccessful("El servicio se canceló exitosamente");
                }
                else
                {
                    oClient.ServiceState = param.ServiceState;
                    oClient.UserUpdate = param.UserUpdate;
                    oClient.UpdateDate = DateTime.Now;
                    _context.Clientservice.Update(oClient);
                    _context.Entry(oClient).Property(r => r.Id).IsModified = false;
                    _context.SaveChanges();

                    return response.CreateSuccessful("El cambio de estado se realió exitosamente");
                }
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }

        public RequestResponse<AppointmentsResponseDto> GetById(int id)
        {
            RequestResponse<AppointmentsResponseDto> response = new();
            try
            {
                var result = _context.Clientservice.AsNoTracking()
                    .Where(f => f.Id == id)
                    .Select(s => new AppointmentsResponseDto()
                    {
                        Id = s.Id,
                        IdClient = s.PetNavigation.ClientNavigation.Id,
                        DocumentNumber = s.PetNavigation.ClientNavigation.DocumentNumber,
                        DocumentType = s.PetNavigation.ClientNavigation.DocumentType,
                        ClientName = $"{s.PetNavigation.ClientNavigation.Name} {s.PetNavigation.ClientNavigation.LastName} ",
                        Phone = s.PetNavigation.ClientNavigation.Phone,
                        Addresss = s.PetNavigation.ClientNavigation.Address,
                        Email = s.PetNavigation.ClientNavigation.Email,
                        IdPet = s.Pet,
                        PetName = s.PetNavigation.Name,
                        Species = s.PetNavigation.Species,
                        SpeciesDescription = s.PetNavigation.SpeciesNavigation.Description,
                        Breed = s.PetNavigation.Breed,
                        Age = s.PetNavigation.Age,
                        Weight = s.PetNavigation.Weight,
                        State = s.ServiceState,
                        StateDescription = s.ServiceStateNavigation.Description,
                        ServiceType = s.ServiceType,
                        ServiceTypeDescription = s.ServiceTypeNavigation.Description,
                        DateService = s.DateService,
                        HourService = s.HourService,
                        Value = s.Value
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

        public RequestResponse<IEnumerable<AppointmentsResponseDto>> GetByState(string param)
        {
            RequestResponse<IEnumerable<AppointmentsResponseDto>> response = new();
            try
            {
                var result = _context.Clientservice.AsNoTracking()
                    .Where(f => f.ServiceState == param)
                    .Select(s => new AppointmentsResponseDto()
                    {
                        Id = s.Id,
                        IdClient = s.PetNavigation.ClientNavigation.Id,
                        DocumentNumber = s.PetNavigation.ClientNavigation.DocumentNumber,
                        DocumentType = s.PetNavigation.ClientNavigation.DocumentType,
                        ClientName = $"{s.PetNavigation.ClientNavigation.Name} {s.PetNavigation.ClientNavigation.LastName} ",
                        Phone = s.PetNavigation.ClientNavigation.Phone,
                        Addresss = s.PetNavigation.ClientNavigation.Address,
                        Email = s.PetNavigation.ClientNavigation.Email,
                        IdPet = s.Pet,
                        PetName = s.PetNavigation.Name,
                        Species = s.PetNavigation.Species,
                        SpeciesDescription = s.PetNavigation.SpeciesNavigation.Description,
                        Breed = s.PetNavigation.Breed,
                        Age = s.PetNavigation.Age,
                        Weight = s.PetNavigation.Weight,
                        State = s.ServiceState,
                        StateDescription = s.ServiceStateNavigation.Description,
                        ServiceType = s.ServiceType,
                        ServiceTypeDescription = s.ServiceTypeNavigation.Description,
                        DateService = s.DateService,
                        HourService = s.HourService,
                        Value = s.Value
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

        public RequestResponse<IEnumerable<AppointmentsGetDto>> getService(FilterRequestDto param)
        {
            RequestResponse<IEnumerable<AppointmentsGetDto>> response = new();
            try
            {
                var result = _context.Clientservice.AsNoTracking()
                    .Select(s => new AppointmentsGetDto()
                    {
                        Id = s.Id,
                        IdClient = s.PetNavigation.ClientNavigation.Id,
                        DocumentNumber = s.PetNavigation.ClientNavigation.DocumentNumber,
                        DocumentType = s.PetNavigation.ClientNavigation.DocumentType,
                        ClientName = $"{s.PetNavigation.ClientNavigation.Name} {s.PetNavigation.ClientNavigation.LastName} ",
                        Phone = s.PetNavigation.ClientNavigation.Phone,
                        Addresss = s.PetNavigation.ClientNavigation.Address,
                        Email = s.PetNavigation.ClientNavigation.Email,
                        IdPet = s.Pet,
                        PetName = s.PetNavigation.Name,
                        Species = s.PetNavigation.Species,
                        SpeciesDescription = s.PetNavigation.SpeciesNavigation.Description,
                        Breed = s.PetNavigation.Breed,
                        Age = s.PetNavigation.Age,
                        Weight = s.PetNavigation.Weight,
                        State = s.ServiceState,
                        StateDescription = s.ServiceStateNavigation.Description,
                        ServiceType = s.ServiceType,
                        ServiceTypeDescription = s.ServiceTypeNavigation.Description,
                        DateService = s.DateService,
                        HourService = s.HourService,
                        Value = s.Value
                    });

                if (!result.Any())
                    return response.CreateUnsuccessful("No se encontró información en la base de datos");

                #region Filters
                if (param.IdClient.HasValue)
                    result = result.Where(f => f.IdClient == Convert.ToInt32(param.IdClient));

                if (!result.Any())
                    return response.CreateUnsuccessful("No se encontró información en la base de datos");

                if (param.IdPet.HasValue)
                    result = result.Where(f => f.IdPet == param.IdPet);

                if (!result.Any())
                    return response.CreateUnsuccessful("No se encontró información en la base de datos");

                if (!string.IsNullOrWhiteSpace(param.IdState))
                    result = result.Where(f => f.State == param.IdState);

                if (!result.Any())
                    return response.CreateUnsuccessful("No se encontró información en la base de datos");

                if (!string.IsNullOrWhiteSpace(param.IdServices))
                    result = result.Where(f => f.ServiceType == param.IdServices);

                if (!result.Any())
                    return response.CreateUnsuccessful("No se encontró información en la base de datos");
                #endregion

                return response.CreateSuccessful(result);
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }

        public RequestResponse<string> save(AppointmentsRequestDto param)
        {
            RequestResponse<string> response = new();

            try
            {
                if (ExistServices(param.ServiceType, param.DateService, param.HourService))
                    return response.CreateUnsuccessful("Ya existe un servicio agendado para los criterios seleccionados");

                var oClient = new Clientservice();

                oClient.Pet = param.IdPet;
                oClient.ServiceState = param.ServiceState;
                oClient.ServiceType = param.ServiceType;
                oClient.DateService = param.DateService;
                oClient.HourService = param.HourService;
                oClient.Value = param.Value;
                oClient.UserSave = param.UserSave;
                oClient.SaveDate = DateTime.Now;
                _context.Clientservice.Add(oClient);
                _context.SaveChanges();

                return response.CreateSuccessful("El servicio se creó exitosamente");
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }

        public RequestResponse<string> update(AppointmentsUpdateDto param)
        {
            RequestResponse<string> response = new();
            try
            {
                var oClient = _context.Clientservice.AsNoTracking().FirstOrDefault(f => f.Id == param.Id);

                if (oClient == null)
                    return response.CreateUnsuccessful("No se encontró información para el servicio");

                if (ExistServices(param.ServiceType, param.DateService, param.HourService))
                    return response.CreateUnsuccessful("Ya existe un servicio agendado para los criterios seleccionados");

                if (param.ServiceState == "CAN")
                {
                    _context.Clientservice.Remove(oClient);
                    _context.SaveChanges();

                    return response.CreateSuccessful("El servicio se canceló exitosamente");
                }
                else
                {
                    oClient.ServiceState = param.ServiceState;
                    oClient.DateService = param.DateService;
                    oClient.HourService = param.HourService;
                    oClient.UserUpdate = param.UserUpdate;
                    oClient.UpdateDate = DateTime.Now;
                    _context.Clientservice.Update(oClient);
                    _context.Entry(oClient).Property(r => r.Id).IsModified = false;
                    _context.SaveChanges();

                    return response.CreateSuccessful("La actualización del servicio se realió exitosamente");
                }
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }



        private bool ExistServices(string serviceType, string dateService, string hourService)
         => _context.Clientservice.AsNoTracking().Any(f => f.ServiceType == serviceType && f.DateService == dateService && f.HourService == hourService);

    }
}