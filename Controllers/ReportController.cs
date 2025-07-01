using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto.Report;
using PetSoft.WebServices.Helpers;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportAppService _ReportAppService;
        public ReportController(IReportAppService ReportAppService)
        {
            _ReportAppService = ReportAppService;
        }

        [HttpPost]
        [Route("Get")]
        public async Task<RequestResponse<IEnumerable<ReportDto>>> Get(FilterReport request)
        {

            return await Task.Run(() =>
            {
                return _ReportAppService.Get(request);
            });

        }
    }
}
