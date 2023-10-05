using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class PriorityLevel
{
    public int TId { get; set; }

    public string TStatus { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
