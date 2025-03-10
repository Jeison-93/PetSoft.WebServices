using System;
using System.Collections.Generic;

namespace PetSoft.WebServices.Data.Models;

public partial class Servicetype
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double? Value { get; set; }

    public sbyte State { get; set; }

    public virtual ICollection<Clientservice> Clientservice { get; set; } = new List<Clientservice>();
}
