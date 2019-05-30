using System.Collections.Generic;
using accesscontrol.Data;

namespace accesscontrol.Permission
{
    public class UserApplicationPermission
    {
        public const string GetUserApplication = "GetUserApplication";
        public const string AddUserApplication = "AddUserApplication";
        public const string GetUserApplicationById = "GetUserApplicationById";
        public const string EditUserApplication = "EditUserApplication";
        public const string DeleteUserApplication = "DeleteUserApplication";

        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Code = GetUserApplication,
                    Name = "Get UserApplication",
                    Description = "List all UserApplications"
                },
                new Role
                {
                    Code = AddUserApplication,
                    Name = "Add UserApplication",
                    Description = "Add new UserApplications"
                },
                new Role
                {
                    Code = GetUserApplicationById,
                    Name = "Get UserApplication by Id",
                    Description = "Get UserApplication by Id"
                },
                new Role
                {
                    Code = EditUserApplication,
                    Name = "Edit UserApplication",
                    Description = "Edit UserApplication"
                },
                new Role
                {
                    Code = DeleteUserApplication,
                    Name = "Delete UserApplication",
                    Description = "Delete UserApplication"
                }
            };
        }
    }
}