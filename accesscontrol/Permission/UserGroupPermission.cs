using System.Collections.Generic;
using accesscontrol.Data;

namespace accesscontrol.Permission
{
    public class UserGroupPermission
    {
        public const string GetUserGroup = "GetUserGroup";
        public const string AddUserGroup = "AddUserGroup";
        public const string GetUserGroupById = "GetUserGroupById";
        public const string EditUserGroup = "EditUserGroup";
        public const string DeleteUserGroup = "DeleteUserGroup";

        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Code = GetUserGroup,
                    Name = "Get UserGroup",
                    Description = "List all UserGroups"
                },
                new Role
                {
                    Code = AddUserGroup,
                    Name = "Add UserGroup",
                    Description = "Add new UserGroups"
                },
                new Role
                {
                    Code = GetUserGroupById,
                    Name = "Get UserGroup by Id",
                    Description = "Get UserGroup by Id"
                },
                new Role
                {
                    Code = EditUserGroup,
                    Name = "Edit UserGroup",
                    Description = "Edit UserGroup"
                },
                new Role
                {
                    Code = DeleteUserGroup,
                    Name = "Delete UserGroup",
                    Description = "Delete UserGroup"
                }
            };
        }
    }
}