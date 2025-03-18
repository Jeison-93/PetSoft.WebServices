namespace PetSoft.WebServices.Data.Dto
{
    public class ClientGetDto
    {
        public int Id { get; set; }

        public string DocumentType { get; set; } = null!;

        public string DocumentNumber { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Addresss { get; set; }

        public string Phone { get; set; } = null!;

        public sbyte State { get; set; }
        public string? StateDescription { get; set; }
    }
}
