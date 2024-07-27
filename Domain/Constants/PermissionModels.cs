using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Constants.Enums;

namespace Domain.Constants
{
    public class PermissionModels
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
            {
                $"CanView{module}",
                $"CanCreate{module}",
                $"CanEdit{module}",
                $"CanDelete{module}"
            };
        }

        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();

            var modules = Enum.GetValues(typeof(Enums.Models));


            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));

            return allPermissions;
        }

        public static List<Permission> FillPermissions()
        {
            var PermissionNumbers = new List<int>();
            var PermissionNames = new List<string>();
            var Permissions = new List<Permission>();
            int id = 0;
            foreach (var name in GenerateAllPermissions())
            {
                var permission = new Permission();
                id++;
                permission.Name = name;
                permission.id = id;
                //PermissionNames.Add(name);
                //PermissionNumbers.Add(id);
                Permissions.Add(permission);

            }
            return Permissions;
        }

    }
}
