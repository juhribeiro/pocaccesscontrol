using System.Collections.Generic;
using accesscontrol.Data;

namespace accesscontrol.Permission
{
    public class UserPermission
    {
        public const string GetUser = "GetUser";
        public const string GetUserById = "GetUserById";
        public const string GetUserByGroup = "GetUserByGroup";
        public const string GetUserByApplication = "GetUserByApplication";
        public const string DeleteUser = "DeleteUser";

        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Code = GetUser,
                    Name = "Get User",
                    Description = "List all Users"
                },
                new Role
                {
                    Code = GetUserById,
                    Name = "Get User by Id",
                    Description = "Get User by Id"
                },
                new Role
                {
                    Code = DeleteUser,
                    Name = "Delete User",
                    Description = "Delete User"
                },
                new Role
                {
                    Code = GetUserByGroup,
                    Name = "Get User by Group",
                    Description = "Get User by Group"
                },
                 new Role
                {
                    Code = GetUserByApplication,
                    Name = "Get User by Application",
                    Description = "Get User by Application"
                }
            };
        }
    }
}