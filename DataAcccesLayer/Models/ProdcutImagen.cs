using System;
using System.Collections.Generic;

namespace DataAcccesLayer.Models;

public partial class ProdcutImagen
{
    public int Id { get; set; }

    public int? IdProduct { get; set; }

    public int? Urlimagen { get; set; }
}
