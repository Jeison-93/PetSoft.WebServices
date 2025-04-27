using System.Diagnostics.Contracts;

namespace PetSoft.WebServices.Data.Dto.ClientService
{
    public class FilterRequestDto
    {
        public int? IdServices { get; set; }
        public int? IdState { get; set; }
        public int? IdClient { get; set; }
        public int? IdPet { get; set; }
    }
}
