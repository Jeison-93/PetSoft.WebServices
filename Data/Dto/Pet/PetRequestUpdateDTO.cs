namespace PetSoft.WebServices.Data.Dto
{
    public class PetRequestUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;   
        public string Species { get; set; } = null!;
        public string? Breed { get; set; }
        public int? Age { get; set; }
        public decimal? Weight { get; set; }
        public int State { get; set; }
    }
}
