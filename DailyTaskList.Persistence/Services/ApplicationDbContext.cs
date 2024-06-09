using DailyTasksList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTasksList.Persistence
{
    #region Public  Class
    public class ApplicationDbContext : DbContext
    {
        #region Public  Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        #endregion Public  Constructor

        #region Public  Properties
        public DbSet<DailyTaskes> DailyTaskes { get; set; }
          public DbSet<User> Users { get; set; }
          public DbSet<Role> Roles { get; set; }
          public DbSet<Permission> Permissions { get; set; }
          public DbSet<UserRoles> UserRoles { get; set; }
          public DbSet<RolePermission> RolePermissions { get; set; }
        #endregion Public  Properties

        #region Public  Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             
            // UserRole many-to-many relationship
            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // RolePermission many-to-many relationship
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);
        }
        #endregion Public  Methods
       
    } 
    #endregion Public  Class
}
