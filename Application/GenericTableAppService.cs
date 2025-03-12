using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Models;

namespace PetSoft.WebServices.Application
{
    public class GenericTableAppService : IGenericTableAppService
    {
        readonly PetsoftdbContext _context;

        public GenericTableAppService(PetsoftdbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// servicio para devolver los tipos de docuemntos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GenericTableDto> GetDocumentType()
        {
            var result = _context.Documenttype
                .Where(f => f.State == 1)
                .Select(s => new GenericTableDto()
            {
                Code = s.Code,
                Description = s.Description
            });
            return result;
        }

        /// <summary>
        /// servicio para devolver los estados de los servicios
        /// </summary>
        /// <returns></returns>

        public IEnumerable<GenericTableDto> GetServiceState()
        {
            var result = _context.Servicestate
                .Where(f => f.State == 1)
                .Select(s => new GenericTableDto()
            {
                Code = s.Code,
                Description = s.Description
            });
            return result;
        }
        
        public IEnumerable<GenericTableDto> GetServiceType()
        {
            var result = _context.Servicetype
                .Where(f => f.State == 1)
                .Select(s => new GenericTableDto()
            {
                Code = s.Code,
                Description = s.Description,
                Value = s.Value
            });
            return result;
        }

        public IEnumerable<GenericTableDto> GetSpecies()
        {
            var result = _context.Species
                .Where(f=>f.State==1)
                .Select(s => new GenericTableDto()
            {
                Code = s.Code,
                Description = s.Description
            });
            return result;
        }

        public IEnumerable<GenericTableDto> GetUserType()
        {
            var result = _context.Usertype
                .Where(f => f.State == 1)
                .Select(s => new GenericTableDto()
            {
                Code = s.Code,
                Description = s.Description
            });
            return result;
        }
    }
}
