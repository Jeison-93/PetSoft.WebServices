﻿namespace PetSoft.WebServices.Data.Dto
{
    public class UserSaveDto
    {
        public string DocumentType { get; set; } = null!;

        public string DocumentNumber { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Addresss { get; set; }

        public string Phone { get; set; } = null!;

        public string? Password { get; set; }

        public string UserType { get; set; } = null!;
    }
}
