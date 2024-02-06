using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppDemo.Data.Models;

public partial class EcommerceAuthenticationServiceContext : DbContext
{
    public EcommerceAuthenticationServiceContext()
    {
    }

    public EcommerceAuthenticationServiceContext(DbContextOptions<EcommerceAuthenticationServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLog> UserLogs { get; set; }

    public virtual DbSet<UsersRole> UsersRoles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-5DKEKQQ7\\NGUYENTHINH;Initial Catalog=EcommerceAuthenticationService;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminUse__3214EC0792148003");

            entity.ToTable("AdminUser");

            entity.Property(e => e.Avatar).HasMaxLength(1);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteAt).HasColumnType("datetime");
            entity.Property(e => e.DisplayName).HasMaxLength(1);
            entity.Property(e => e.EndLockAt).HasColumnType("datetime");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FollowAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UnFollowAt).HasColumnType("datetime");

            entity.HasOne(d => d.Shop).WithMany()
                .HasForeignKey(d => d.ShopId)
                .HasConstraintName("FK__Follows__ShopId__37A5467C");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Follows__UserId__36B12243");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07464C2D64");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteAt).HasColumnType("datetime");
            entity.Property(e => e.DisplayName).HasMaxLength(1);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shops__3214EC0757DEE1C5");

            entity.Property(e => e.Address).HasMaxLength(1);
            entity.Property(e => e.Avatar).HasMaxLength(1);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(1);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Owner).WithMany(p => p.Shops)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Shops__OwnerId__35BCFE0A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0709E9C98F");

            entity.Property(e => e.Avatar).HasMaxLength(1);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteAt).HasColumnType("datetime");
            entity.Property(e => e.DisplayName).HasMaxLength(1);
            entity.Property(e => e.EndLockAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(1);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__UserLogs__5E548648DBE3D46E");

            entity.Property(e => e.LogId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserAction)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsersRole>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UsersRole__RoleI__34C8D9D1");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UsersRole__UserI__33D4B598");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
