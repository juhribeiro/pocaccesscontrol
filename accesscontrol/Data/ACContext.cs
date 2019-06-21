using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using accesscontrol.Service;
using Microsoft.EntityFrameworkCore;

namespace accesscontrol.Data
{
    public class ACContext : DbContext
    {
        private readonly IAuthService auth;
        public ACContext(DbContextOptions<ACContext> options, IAuthService auth)
        : base(options)
        {
            this.auth = auth;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<UserApplication> UserApplications { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RoleGroup> RoleGroups { get; set; }

        /// <summary>
        /// Change efective updates in data base
        /// </summary>
        /// <param name="cancellationToken"> Value of cancellation</param>
        /// <returns> Number of all entities updates</returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry =>
                {
                    if (entry.State == EntityState.Added)
                    {
                        if (entry.Properties.Any(a => a.Metadata.Name.Contains("CreateDate")))
                        {
                            entry.Property("CreateDate").CurrentValue = DateTime.UtcNow;
                        }

                        if (entry.Properties.Any(a => a.Metadata.Name.Contains("CreateUser")))
                        {
                            entry.Property("CreateUser").CurrentValue = this.auth.GetEmail();
                        }

                        if (entry.Properties.Any(a => a.Metadata.Name.Contains("Active")))
                        {
                            entry.Property("Active").CurrentValue = true;
                        }
                    }

                    if (entry.Properties.Any(a => a.Metadata.Name.Contains("LastChangeUser")))
                    {
                        entry.Property("LastChangeUser").CurrentValue = this.auth.GetEmail();
                    }

                    if (entry.Properties.Any(a => a.Metadata.Name.Contains("LastChangeDate")))
                    {
                        entry.Property("LastChangeDate").CurrentValue = DateTime.UtcNow;
                    }
                });

            return (await base.SaveChangesAsync(true, cancellationToken));
        }

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

            modelBuilder.Entity<UserApplication>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

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

            modelBuilder.Entity<UserGroup>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

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

            modelBuilder.Entity<RoleGroup>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //// aplication groups
            modelBuilder.Entity<Application>()
                .HasMany(x => x.Groups)
                .WithOne(x => x.Application)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

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