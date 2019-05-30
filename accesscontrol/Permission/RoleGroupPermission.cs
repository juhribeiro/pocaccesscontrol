using System.Collections.Generic;
using accesscontrol.Data;

namespace accesscontrol.Permission
{
    public class RoleGroupPermission
    {
        public const string GetRoleGroup = "GetRoleGroup";
        public const string AddRoleGroup = "AddRoleGroup";
        public const string GetRoleGroupById = "GetRoleGroupById";
        public const string EditRoleGroup = "EditRoleGroup";
        public const string DeleteRoleGroup = "DeleteRoleGroup";

        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Code = GetRoleGroup,
                    Name = "Get RoleGroup",
                    Description = "List all RoleGroups"
                },
                new Role
                {
                    Code = AddRoleGroup,
                    Name = "Add RoleGroup",
                    Description = "Add new RoleGroups"
                },
                new Role
                {
                    Code = GetRoleGroupById,
                    Name = "Get RoleGroup by Id",
                    Description = "Get RoleGroup by Id"
                },
                new Role
                {
                    Code = EditRoleGroup,
                    Name = "Edit RoleGroup",
                    Description = "Edit RoleGroup"
                },
                new Role
                {
                    Code = DeleteRoleGroup,
                    Name = "Delete RoleGroup",
                    Description = "Delete RoleGroup"
                }
            };
        }
    }
}