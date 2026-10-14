using System;
using System.Collections.Generic;

namespace Vankov_Pr_6_Var_1.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int DurationMinutes { get; set; }

    public int ReleaseYear { get; set; }

    public bool IsAvailable { get; set; }
}
