namespace PetSoft.WebServices.Data.Dto.ClientService
{
    public class AppointmentsChangeStateDto
    {
        public int Id { get; set; }
        public string ServiceState { get; set; } = null!;
        public int UserUpdate { get; set; }
    }
}
