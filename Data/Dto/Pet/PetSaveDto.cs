namespace PetSoft.WebServices.Data.Dto.Pet
{
    public class PetSaveDto
    {

        public string Name { get; set; } = null!;

        public string Species { get; set; } = null!;

        public string? Breed { get; set; }

        public int? Age { get; set; }

        public decimal? Weight { get; set; }

        public int Client { get; set; }


    }
}
