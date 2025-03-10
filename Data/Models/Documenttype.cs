using System;
using System.Collections.Generic;

namespace PetSoft.WebServices.Data.Models;

public partial class Documenttype
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public sbyte State { get; set; }

    public virtual ICollection<Client> Client { get; set; } = new List<Client>();

    public virtual ICollection<User> User { get; set; } = new List<User>();
}
