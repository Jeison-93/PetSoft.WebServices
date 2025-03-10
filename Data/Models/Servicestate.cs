using System;
using System.Collections.Generic;

namespace PetSoft.WebServices.Data.Models;

public partial class Servicestate
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public sbyte State { get; set; }

    public virtual ICollection<Clientservice> Clientservice { get; set; } = new List<Clientservice>();
}
