using PetSoft.WebServices.Data.Dto.Report;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Application.Interface
{
    public interface IReportAppService
    {
        public RequestResponse<IEnumerable<ReportDto>> Get(FilterReport request);

    }

    
}
