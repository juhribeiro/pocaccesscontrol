using System.Collections.Generic;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.Permission;
using Microsoft.EntityFrameworkCore;

namespace accesscontrol.Util
{
    public static class SeedData
    {
        public const string PrincipalApplication = "J&M";
        private const string PrincipalUser = "J&M";
        public const string PrincipalEmail = "juliane.goncalves94@gmail.com";
        private const string AdmGroupAC = "AdmGroupAC";

        public static async Task SeedAsync(ACContext context)
        {
            await context.Database.MigrateAsync();
            if (!await context.Users.AnyAsync())
            {
                var user = CreateAdm();
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        private static User CreateAdm()
        {
            var user = new User
            {
                Name = PrincipalUser,
                Email = PrincipalEmail,
                DocumentNumber = "27.133.598/0001-43",
                PhoneNumber = "(55)(41)98800-4834",
                CellPhoneNumber = "(55)(41)98800-4834",
                Password = Criptografy.EncriptPassword(PrincipalEmail, "qazqaz")
            };

            var group = new Group
            {
                Application = CreateApplication(),
                Code = AdmGroupAC,
                Name = "Adm Access Control",
                Description = "Adm Access Control"
            };

            foreach (var role in CreateRoles())
            {
                var rolegroup = new RoleGroup
                {
                    Group = group,
                    Role = role
                };

                group.RoleGroups.Add(rolegroup);
            }

            var usergroup = new UserGroup
            {
                User = user,
                Group = group
            };

            user.UserGroups.Add(usergroup);
            return user;
        }

        private static Application CreateApplication()
        {
            var app = new Application
            {
                Code = PrincipalApplication,
                Name = "J & M Consultoria",
                Description = "Consultoria de sistemas"
            };

            return app;
        }

        private static List<Role> CreateRoles()
        {
            var roles = new List<Role>();
            roles.AddRange(ApplicationPermission.GetRoles());
            roles.AddRange(GroupPermission.GetRoles());
            roles.AddRange(RoleGroupPermission.GetRoles());
            roles.AddRange(RolePermission.GetRoles());
            roles.AddRange(UserApplicationPermission.GetRoles());
            roles.AddRange(UserGroupPermission.GetRoles());
            roles.AddRange(UserPermission.GetRoles());
            return roles;
        }
    }
}