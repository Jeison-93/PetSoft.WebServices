using PetSoft.WebServices.Data.Models;

namespace PetSoft.WebServices.Data.Dto.ClientServices
{
    public class AppointmentsGetDto
    {
        public int Id { get; set; }
        public int PetId { get; set; }

        public string IdServiceType { get; set; } = null!;

        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string ClientName { get; set; } = null!;

        public string? Breed { get; set; }

        public int? Age { get; set; }

        public decimal? Weight { get; set; }

        public int IdClient { get; set; }

        public sbyte State { get; set; }
        public string ClientDoc { get; set; } = null!;
        public string ClientEmail { get; set; } = null!;
        public string ClientPhone { get; set; } = null!;
        public string ClientDocNumber { get; set; } = null!;
    }
          
}
