using System;
using System.Collections.Generic;

namespace PetSoft.WebServices.Data.Models;

public partial class Species
{
    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public sbyte State { get; set; }

    public virtual ICollection<Pet> Pet { get; set; } = new List<Pet>();
}
