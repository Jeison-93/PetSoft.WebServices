﻿namespace PetSoft.WebServices.Data.Dto.User
{
    public class UserAuthDto
    {
        public int Id { get; set; }
        public string DocumentType { get; set; } = null!;

        public string DocumentNumber { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Address { get; set; }

        public string Phone { get; set; } = null!;

        public string? Password { get; set; }

        public string UserType { get; set; } = null!;
    }
}
