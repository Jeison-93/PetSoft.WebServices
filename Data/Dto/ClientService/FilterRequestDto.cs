using System.Diagnostics.Contracts;

namespace PetSoft.WebServices.Data.Dto.ClientService
{
    public class FilterRequestDto
    {
        public string? IdServices { get; set; }
        public string? IdState { get; set; }
        public int? IdClient { get; set; }
        public int? IdPet { get; set; }
    }
}
