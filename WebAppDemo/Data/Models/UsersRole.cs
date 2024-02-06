using System;
using System.Collections.Generic;

namespace WebAppDemo.Data.Models;

public partial class UsersRole
{
    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual AdminUser? User { get; set; }
}
