using System.Collections.Generic;
using accesscontrol.Data;

namespace accesscontrol.Permission
{
    public class ApplicationPermission
    {
        public const string GetApplication = "GetApplication";
        public const string AddApplication = "AddApplication";
        public const string GetApplicationById = "GetApplicationById";
        public const string EditApplication = "EditApplication";
        public const string DeleteApplication = "DeleteApplication";

        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Code = GetApplication,
                    Name = "Get Application",
                    Description = "List all applications"
                },
                new Role
                {
                    Code = AddApplication,
                    Name = "Add Application",
                    Description = "Add new applications"
                },
                new Role
                {
                    Code = GetApplicationById,
                    Name = "Get Application by Id",
                    Description = "Get Application by Id"
                },
                new Role
                {
                    Code = EditApplication,
                    Name = "Edit Application",
                    Description = "Edit Application"
                },
                new Role
                {
                    Code = DeleteApplication,
                    Name = "Delete Application",
                    Description = "Delete Application"
                }
            };
        }
    }
}