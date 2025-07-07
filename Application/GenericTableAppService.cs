using Microsoft.EntityFrameworkCore;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Data;
using PetSoft.WebServices.Data.Dto;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application
{
    public class GenericTableAppService : IGenericTableAppService
    {
        readonly PetsoftdbContext _context;

        public GenericTableAppService(PetsoftdbContext context)
        {
            _context = context;
        }

        public RequestResponse<IEnumerable<GenericTableDto>> Get(string table)  
        {
            {
                RequestResponse<IEnumerable<GenericTableDto>> response = new();
                try
                {
                    GenericTableEnum tableEnum = table.ToEnum<GenericTableEnum>();

                    switch (tableEnum)
                    {
                        case GenericTableEnum.DocumentType:
                            var documentType = from dt in _context.Documenttype.AsNoTracking()
                                               select new GenericTableDto()
                                               {
                                                   Code = dt.Code,
                                                   Description = dt.Description,
                                               };
                            response.CreateSuccessful(documentType);
                            break;
                        case GenericTableEnum.ServiceState:
                            var serviceState = from dt in _context.Servicestate.AsNoTracking()
                                               select new GenericTableDto()
                                               {
                                                   Code = dt.Code,
                                                   Description = dt.Description,
                                               };
                            response.CreateSuccessful(serviceState);
                            break;
                        case GenericTableEnum.UserType:
                            var userType = from dt in _context.Usertype.AsNoTracking()
                                           select new GenericTableDto()
                                           {
                                               Code = dt.Code,
                                               Description = dt.Description,
                                           };
                            response.CreateSuccessful(userType);
                            break;
                        case GenericTableEnum.Species:
                            var species = from dt in _context.Species.AsNoTracking()
                                          select new GenericTableDto()
                                          {
                                              Code = dt.Code,
                                              Description = dt.Description,
                                          };
                            response.CreateSuccessful(species);
                            break;
                        case GenericTableEnum.ServiceType:
                            var serviceType = from dt in _context.Servicetype.AsNoTracking()
                                              select new GenericTableDto()
                                              {
                                                  Code = dt.Code,
                                                  Description = dt.Description,
                                                  Value = dt.Value
                                              };
                            response.CreateSuccessful(serviceType);
                            break;
                        default:
                            break;
                    }
                    return response;
                }
                catch (Exception ex)
                {
                    return response.CreateError(ex.Message);
                }

            }
        }
    }

        
    
}
