using System;
using System.Collections.Generic;

namespace _24_8_2024_Task2.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public string? ProductImage { get; set; }

    public decimal? Price { get; set; }

    public virtual Category? Category { get; set; }
}
