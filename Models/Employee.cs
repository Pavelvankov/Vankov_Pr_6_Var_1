using System;
using System.Collections.Generic;

namespace Vankov_Pr_6_Var_1.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public decimal Salary { get; set; }

    public DateOnly HireDate { get; set; }

    public bool IsActive { get; set; }
}
