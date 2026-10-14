using System;
using System.Collections.Generic;

namespace Vankov_Pr_6_Var_1.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string Subject { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Priority { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsClosed { get; set; }
}
