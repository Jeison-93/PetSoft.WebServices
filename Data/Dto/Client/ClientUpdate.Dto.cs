namespace PetSoft.WebServices.Data.Dto.Client
{
    public class ClientUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Addresss { get; set; }

        public string Phone { get; set; } = null!;
        public sbyte State { get; set; }
    }
}
