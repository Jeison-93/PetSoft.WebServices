using System;
using System.Collections.Generic;

namespace PetSoft.WebServices.Data.Models;

public partial class Pet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string? Breed { get; set; }

    public int? Age { get; set; }

    public decimal? Weight { get; set; }

    public int Client { get; set; }

    public sbyte State { get; set; }

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual ICollection<Clientservice> Clientservice { get; set; } = new List<Clientservice>();

    public virtual Species SpeciesNavigation { get; set; } = null!;
}
