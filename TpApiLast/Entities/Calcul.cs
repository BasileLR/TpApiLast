using System;
using System.Collections.Generic;

namespace TpApiLast.Entities;

public partial class Calcul
{
    public decimal? Kc { get; set; }

    public string? VolumeReserveEau { get; set; }

    public string? SurfaceCulture { get; set; }

    public int Id { get; set; }
}
