namespace PetSoft.WebServices.Data.Dto.ClientService
{
    public class AppointmentsUpdateDto
    {
        public int Id { get; set; }
        public string DateService { get; set; } = null!;
        public string HourService { get; set; } = null!;
        public string ServiceType { get; set; } = null!;
        public string ServiceState { get; set; } = null!;
        public decimal? Value { get; set; }
        public int UserUpdate { get; set; }
    }
}
