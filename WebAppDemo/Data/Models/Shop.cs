using System;
using System.Collections.Generic;

namespace WebAppDemo.Data.Models;

public partial class Shop
{
    public int Id { get; set; }

    public int? ShopOldId { get; set; }

    public int? OwnerId { get; set; }

    public string? Name { get; set; }

    public string? Avatar { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmailAddres { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? TaxIdentificationNumber { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsCancel { get; set; }

    public int? AdminApproved { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual User? Owner { get; set; }
}
