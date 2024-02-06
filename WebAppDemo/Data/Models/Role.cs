using System;
using System.Collections.Generic;

namespace WebAppDemo.Data.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }
}
