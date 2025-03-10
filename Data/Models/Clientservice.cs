using System;
using System.Collections.Generic;

namespace PetSoft.WebServices.Data.Models;

public partial class Clientservice
{
    public int Id { get; set; }

    public int Pet { get; set; }

    public DateTime DateServices { get; set; }

    public string ServiceType { get; set; } = null!;

    public string ServiceState { get; set; } = null!;

    public double Value { get; set; }

    public DateTime SaveDate { get; set; }

    public int UserSave { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UserUpdate { get; set; }

    public virtual Pet PetNavigation { get; set; } = null!;

    public virtual Servicestate ServiceStateNavigation { get; set; } = null!;

    public virtual Servicetype ServiceTypeNavigation { get; set; } = null!;

    public virtual User UserSaveNavigation { get; set; } = null!;

    public virtual User? UserUpdateNavigation { get; set; }
}
