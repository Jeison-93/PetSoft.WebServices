using System;
using System.Collections.Generic;

namespace PetSoft.WebServices.Data.Models;

public partial class User
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

    public sbyte State { get; set; }

    public virtual ICollection<Clientservice> ClientserviceUserSaveNavigation { get; set; } = new List<Clientservice>();

    public virtual ICollection<Clientservice> ClientserviceUserUpdateNavigation { get; set; } = new List<Clientservice>();

    public virtual Documenttype DocumentTypeNavigation { get; set; } = null!;

    public virtual Usertype UserTypeNavigation { get; set; } = null!;
}
