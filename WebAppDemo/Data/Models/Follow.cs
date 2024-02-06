using System;
using System.Collections.Generic;

namespace WebAppDemo.Data.Models;

public partial class Follow
{
    public int? UserId { get; set; }

    public int? ShopId { get; set; }

    public DateTime? FollowAt { get; set; }

    public bool? UnFollow { get; set; }

    public DateTime? UnFollowAt { get; set; }

    public virtual Shop? Shop { get; set; }

    public virtual User? User { get; set; }
}
