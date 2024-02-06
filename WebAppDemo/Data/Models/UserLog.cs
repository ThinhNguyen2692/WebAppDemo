using System;
using System.Collections.Generic;

namespace WebAppDemo.Data.Models;

public partial class UserLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public bool? IsAdmin { get; set; }

    public string? UserAction { get; set; }

    public string? TableName { get; set; }

    public int? RecordId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
