using System.Diagnostics.CodeAnalysis;

namespace PetSoft.WebServices.Data.Dto.Report
{
    public class FilterReport
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string? State { get; set; }
        public string? ServiceType { get; set; }
    }
}
