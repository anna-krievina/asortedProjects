using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Task
{
    public int TId { get; set; }

    public string TTitle { get; set; } = null!;

    public string? TDescription { get; set; }

    public DateTime? TDueDate { get; set; }

    public int TPriorityLevel { get; set; }

    public int TStatus { get; set; }

    public int TUserId { get; set; }

    public virtual PriorityLevel TPriorityLevelNavigation { get; set; } = null!;

    public virtual TaskStatus TStatusNavigation { get; set; } = null!;
}
