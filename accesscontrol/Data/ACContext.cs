using Microsoft.EntityFrameworkCore;

namespace accesscontrol.Data
{
    public class ACContext : DbContext
    {
        public ACContext(DbContextOptions<ACContext> options)
           : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RoleGroup> RoleGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("accesscontrol");

            ////User application
            modelBuilder.Entity<User>()
            .HasMany(x => x.UserApplications)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Application>()
            .HasMany(x => x.UserApplications)
            .WithOne(x => x.Application)
            .HasForeignKey(x => x.ApplicationId);

            modelBuilder.Entity<UserApplication>()
            .HasKey(x => new { x.UserId, x.ApplicationId });

            //// user group
            modelBuilder.Entity<User>()
            .HasMany(x => x.UserGroups)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Group>()
            .HasMany(x => x.UserGroups)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.GroupId);

            modelBuilder.Entity<UserGroup>()
            .HasKey(x => new { x.UserId, x.GroupId });

            //// role group
            modelBuilder.Entity<Role>()
           .HasMany(x => x.RoleGroups)
           .WithOne(x => x.Role)
           .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<Group>()
            .HasMany(x => x.RoleGroups)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.GroupId);

            modelBuilder.Entity<RoleGroup>()
            .HasKey(x => new { x.RoleId, x.GroupId });

            //// aplication groups
            modelBuilder.Entity<Application>()
            .HasMany(x => x.Groups)
            .WithOne(x => x.Application)
            .HasForeignKey(x => x.ApplicationId);

            //// Unique
            modelBuilder.Entity<Group>()
            .HasIndex(x => x.Code)
            .IsUnique();

            modelBuilder.Entity<Role>()
            .HasIndex(x => x.Code)
            .IsUnique();

            modelBuilder.Entity<Application>()
            .HasIndex(x => x.Code)
            .IsUnique();

            modelBuilder.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique();
        }
    }
}