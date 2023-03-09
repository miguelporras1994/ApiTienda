﻿using System;
using System.Collections.Generic;

namespace DataAcccesLayer.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? NameCategory { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
