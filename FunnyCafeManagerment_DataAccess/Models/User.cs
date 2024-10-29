﻿using System;
using System.Collections.Generic;

namespace FunnyCafeManagerment_DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public DateOnly? Dob { get; set; }

    public DateOnly? StartDay { get; set; }

    public string? Status { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}