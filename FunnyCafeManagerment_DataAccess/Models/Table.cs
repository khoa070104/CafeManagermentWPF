using System;
using System.Collections.Generic;

namespace FunnyCafeManagerment_DataAccess.Models;

public partial class Table
{
    public string TableId { get; set; } = null!;

    public string? TableName { get; set; }

    public string? Status { get; set; }
}
