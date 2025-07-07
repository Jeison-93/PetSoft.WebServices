namespace PetSoft.WebServices.Data.Dto.Report
{
    public class ReportDto
    {
        /// <summary>
        /// amount=cantidad
        /// </summary>
        public int Amount { get; set; } 
        public string Date { get; set; }
        public string? ServiceType { get; set; }
        public string? State { get; set; }
       
    }
}
