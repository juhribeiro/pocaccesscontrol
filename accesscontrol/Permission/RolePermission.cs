using System.Collections.Generic;
using accesscontrol.Data;

namespace accesscontrol.Permission
{
    public class RolePermission
    {
        public const string GetRole = "GetRole";
        public const string AddRole = "AddRole";
        public const string GetRoleById = "GetRoleById";
        public const string EditRole = "EditRole";
        public const string DeleteRole = "DeleteRole";

        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Code = GetRole,
                    Name = "Get Role",
                    Description = "List all Roles"
                },
                new Role
                {
                    Code = AddRole,
                    Name = "Add Role",
                    Description = "Add new Roles"
                },
                new Role
                {
                    Code = GetRoleById,
                    Name = "Get Role by Id",
                    Description = "Get Role by Id"
                },
                new Role
                {
                    Code = EditRole,
                    Name = "Edit Role",
                    Description = "Edit Role"
                },
                new Role
                {
                    Code = DeleteRole,
                    Name = "Delete Role",
                    Description = "Delete Role"
                }
            };
        }
    }
}