using System;
using System.Collections.Generic;

namespace WebAppDemo.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public string? Avatar { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmailAddres { get; set; }

    public string? Password { get; set; }

    public DateTime? EndLockAt { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
