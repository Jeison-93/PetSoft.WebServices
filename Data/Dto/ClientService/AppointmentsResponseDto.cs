namespace PetSoft.WebServices.Data.Dto.ClientService
{
    public class AppointmentsResponseDto
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string DocumentType { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Addresss { get; set; }
        public int IdPet { get; set; }
        public string PetName { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string SpeciesDescription { get; set; } = null!;
        public string? Breed { get; set; }
        public int? Age { get; set; }
        public decimal? Weight { get; set; }
        public string State { get; set; } = null!;
        public string StateDescription { get; set; } = null!;
        public string ServiceType { get; set; } = null!;
        public string ServiceTypeDescription { get; set; } = null!;
        public double? Value { get; set; }
        public string? DateService { get; set; }
        public string? HourService { get; set; }
    }
}
