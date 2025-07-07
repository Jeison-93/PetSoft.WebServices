using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto.Report;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;
using System.Security.Cryptography.X509Certificates;

namespace PetSoft.WebServices.Application
{
    public class ReportAppService : IReportAppService
    {
        private readonly PetsoftdbContext _context;

        public ReportAppService(PetsoftdbContext context)
        {
            _context = context;
        }

        public RequestResponse<IEnumerable<ReportDto>> Get(FilterReport request)
        {
            RequestResponse<IEnumerable<ReportDto>> response = new();
            try
            {
                var result = _context.Clientservice
                   .GroupBy(cs => cs.DateService)
                   .Select(g => new ReportDto
                   {
                       Date = g.Key,
                       Amount = g.Count(),
                       ServiceType = g.Select(cs => cs.ServiceTypeNavigation.Code).FirstOrDefault(),
                       State = g.Select(cs => cs.ServiceStateNavigation.Code).FirstOrDefault(),
                   })
                   .OrderBy(r => r.Date)
                   .ToList();

                if(result.Any())
                {
                    var resultFilter = result.Where(cs => Convert.ToDateTime(cs.Date) >= Convert.ToDateTime(request.StartDate) &&
                    Convert.ToDateTime(cs.Date) <= Convert.ToDateTime(request.EndDate));

                    if (!resultFilter.Any())
                        return response.CreateUnsuccessful("No se encontró información en la base de datos");

                    if (!string.IsNullOrWhiteSpace(request.ServiceType))
                        resultFilter = resultFilter.Where(r => r.ServiceType == request.ServiceType);

                    if (!resultFilter.Any())
                        return response.CreateUnsuccessful("No se encontró información en la base de datos");


                    if (!string.IsNullOrWhiteSpace(request.State))
                        resultFilter = resultFilter.Where(r => r.State == request.State).ToList();

                    if (!resultFilter.Any())
                        return response.CreateUnsuccessful("No se encontró información en la base de datos");


                    return response.CreateSuccessful(resultFilter);

                }


                return response.CreateUnsuccessful("No se encontró información para el reporte");
            }
            catch (Exception ex)
            {

                return response.CreateError(ex.Message);
            }
        }
    }
}
