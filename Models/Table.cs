using System;
using System.Collections.Generic;

namespace BlazorServerWithLocalization.Models;

public partial class Table
{
    public string Key { get; set; } = null!;

    public string? EnUs { get; set; }

    public string? De { get; set; }
}
