namespace PetSoft.WebServices.Data.Dto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        public string? Address { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }

        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string? Password { get; set; }

        public string UserType { get; set; } = null!;

        public sbyte State { get; set; }
        public string DocumentType { get; set; } = null!;
    }
}
