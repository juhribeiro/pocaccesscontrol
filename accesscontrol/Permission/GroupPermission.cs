using System.Collections.Generic;
using accesscontrol.Data;

namespace accesscontrol.Permission
{
    public class GroupPermission
    {
        public const string GetGroup = "GetGroup";
        public const string AddGroup = "AddGroup";
        public const string GetGroupById = "GetGroupById";
        public const string EditGroup = "EditGroup";
        public const string DeleteGroup = "DeleteGroup";

        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Code = GetGroup,
                    Name = "Get Group",
                    Description = "List all Groups"
                },
                new Role
                {
                    Code = AddGroup,
                    Name = "Add Group",
                    Description = "Add new Groups"
                },
                new Role
                {
                    Code = GetGroupById,
                    Name = "Get Group by Id",
                    Description = "Get Group by Id"
                },
                new Role
                {
                    Code = EditGroup,
                    Name = "Edit Group",
                    Description = "Edit Group"
                },
                new Role
                {
                    Code = DeleteGroup,
                    Name = "Delete Group",
                    Description = "Delete Group"
                }
            };
        }
    }
}