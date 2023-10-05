using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class User
{
    public int TId { get; set; }

    public string TUsername { get; set; } = null!;

    public string TPassword { get; set; } = null!;
}
