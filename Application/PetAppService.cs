using Microsoft.EntityFrameworkCore;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.DTO;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application
{
    public class PetAppService : IPetAppService
    {
        private readonly PetsoftdbContext _context;

        public PetAppService(PetsoftdbContext context)
        {
            _context = context;
        }

        public RequestResponse<IEnumerable<PetResponseDTO>> GetAll(int client)
        {
            RequestResponse<IEnumerable<PetResponseDTO>> response = new();
            try
            {
                var result = _context.Pet.AsNoTracking()
                    .Where(f => f.Client == client && f.State == 1)
                    .Select(s => new PetResponseDTO()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Breed = s.Breed,
                        Age = s.Age,
                        Weight = s.Weight,
                        Species = s.Species,
                        SpeciesDescription = s.SpeciesNavigation.Description,
                        Client = s.Client,
                        ClientName = $"{s.ClientNavigation.Name} {s.ClientNavigation.LastName}",
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

        public RequestResponse<PetResponseDTO> GetById(int id)
        {
            RequestResponse<PetResponseDTO> response = new();
            try
            {
                var result = _context.Pet.AsNoTracking()
                    .Where(f => f.Id == id)
                    .Select(s => new PetResponseDTO()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Breed = s.Breed,
                        Age = s.Age,
                        Weight = s.Weight,
                        Species = s.Species,
                        SpeciesDescription = s.SpeciesNavigation.Description,
                        Client = s.Client,
                        ClientName = $"{s.ClientNavigation.Name} {s.ClientNavigation.LastName}",
                        State = s.State,
                        StateDescription = s.State == 1 ? "Activo" : "Inactivo"
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

        public RequestResponse<string> Save(PetRequestDTO request)
        {
            RequestResponse<string> response = new();

            try
            {
                var oPet = new Pet();

                oPet.Name = request.Name;
                oPet.Age = request.Age;
                oPet.Species = request.Species;
                oPet.Breed = request.Breed;
                oPet.Weight = request.Weight;
                oPet.Client = request.Client;
                oPet.State = 1;
                _context.Pet.Add(oPet);

                _context.SaveChanges();

                return response.CreateSuccessful("La Mascota se creó exitosamente");
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }

        public RequestResponse<string> Update(PetRequestUpdateDTO request)
        {
            RequestResponse<string> response = new();
            try
            {
                var oPet = _context.Pet.AsNoTracking().FirstOrDefault(f => f.Id == request.Id);

                if (oPet == null)
                    return response.CreateUnsuccessful("No se encontró información para la Mascota");

                oPet.Name = request.Name;
                oPet.Age = request.Age;
                oPet.Species = request.Species;
                oPet.Breed = request.Breed;
                oPet.Weight = request.Weight;
                _context.Pet.Update(oPet);
                _context.Entry(oPet).Property(r => r.Id).IsModified = false;
                _context.SaveChanges();

                return response.CreateSuccessful("La información de la Mascota se actualizó exitosamente");
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }

        public RequestResponse<string> ChangeState(int id)
        {
            RequestResponse<string> response = new();
            try
            {
                var oPet = _context.Pet.AsNoTracking().FirstOrDefault(f => f.Id == id);

                if (oPet == null)
                    return response.CreateUnsuccessful("No se encontró información para las mascota");

                 oPet.State = (sbyte)(oPet.State == 0 ? 1 : 0);
                _context.Pet.Update(oPet);
                _context.Entry(oPet).Property(r => r.Id).IsModified = false;
                _context.SaveChanges();

                return response.CreateSuccessful("El cambio de estado se realió exitosamente");
            }
            catch (Exception ex)
            {
                return response.CreateError(ex.Message);
            }
        }
    }
}
