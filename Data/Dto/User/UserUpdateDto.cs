namespace PetSoft.WebServices.Data.Dto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        public string? Addresss { get; set; }

        public string Phone { get; set; } = null!;

        public string? Password { get; set; }

        public string UserType { get; set; } = null!;

        public sbyte State { get; set; }
    }
}
