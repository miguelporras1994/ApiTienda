using System;
using System.Collections.Generic;

namespace PresentationLayer.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public double Price { get; set; }

    public string Discretion { get; set; } = null!;

    public int? IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }
}
