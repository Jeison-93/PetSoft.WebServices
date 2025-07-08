namespace PetSoft.WebServices.Data.Dto.ClientService
{
    public class AppointmentsRequestDto
    {   public string Id { get; set; } = null!;
        public int IdPet { get; set; }
        public string DateService { get; set; } = null!;
        public string HourService { get; set; } = null!;
        public string ServiceType { get; set; } = null!;
        public string ServiceState { get; set; } = null!;
        public double Value { get; set; }
        public int UserSave { get; set; }
    }
}
