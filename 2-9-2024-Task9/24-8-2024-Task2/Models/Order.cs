using System;
using System.Collections.Generic;

namespace _24_8_2024_Task2.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public virtual User? User { get; set; }
}
