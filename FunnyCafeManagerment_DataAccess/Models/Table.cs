using System;
using System.Collections.Generic;

namespace FunnyCafeManagerment_DataAccess.Models;

public partial class Table
{
    public int TableId { get; set; }

    public string? TableName { get; set; }

    public string? Status { get; set; }
}
