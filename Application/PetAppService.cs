using Google.Protobuf;
using Microsoft.EntityFrameworkCore;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Dto.Pet;
using PetSoft.WebServices.Data.Models;

namespace PetSoft.WebServices.Application
{
    public class PetAppService :  IPetAppService
    {
        readonly PetsoftdbContext _context;
        public PetAppService(PetsoftdbContext context)
        {
            _context = context;
        }
        public PetGetDto Get(int id)
        {
            var result = _context.Pet
             .Where(f => f.Id == id)
                 .Select(s => new PetGetDto()
                 {
 
                     Id = s.Id,
                     Name = s.Name,
                     Species = s.Species,
                     Breed = s.Breed,
                     Age = s.Age,
                     Weight = s.Weight,
                     Client = s.Client,
                     State = s.State,
                 }).FirstOrDefault();

            return result != null ? result : new PetGetDto();
        }

        public IEnumerable<PetGetDto> GetAll(int Client)
        {
            {
                var result = _context.Pet
                    .Where (f => f.Client == Client)
                     .Select(s => new PetGetDto()
                     {
                         Id= s.Id,
                         Name = s.Name,
                         Species = s.Species,
                         Breed = s.Breed,
                         Age = s.Age,
                         Weight = s.Weight,
                         Client = s.Client,
                         State = s.State,

                     });

                return result;
            }
        }

      
        public string Save(PetSaveDto parameter)
        {
            try
            {

            Pet pet = new();
            pet.Name = parameter.Name;
            pet.Species = parameter.Species;
            pet.Breed = parameter.Breed;
            pet.Age = parameter.Age;
            pet.Weight = parameter.Weight;
            pet.Client = parameter.Client;
            pet.State = 1;

            _context.Pet.Add(pet);
            _context.SaveChanges();


            return "Registro Exitoso";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Update(PetUpdateDto parameter)
        {
            try
            {
                Pet pet = _context.Pet.FirstOrDefault(f => f.Id == parameter.Id);
                if (pet == null)
                {
                    return "El usuario no existe";
                }

                pet.Name = parameter.Name;
                pet.Species = parameter.Species;
                pet.Breed = parameter.Breed;
                pet.Age = parameter.Age;
                pet.Weight = parameter.Weight;
                pet.State = parameter.State;


                _context.Pet.Update(pet);
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
