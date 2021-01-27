using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SoftIran.Web
{
    public static class MapRoutes
    {

        private const string BaseUrl = "api/" + "v{version:apiVersion}";

        public static class Department
        {

            public const string list   = BaseUrl + "/department/list";
            public const string Upsert = BaseUrl + "/department/upsert";
            public const string Delete = BaseUrl + "/department/{request}";
            public const string Single = BaseUrl + "/department/{request}";

        }
        public static class RoleRoute
        {
            
            public const string ListRoles  = BaseUrl + "/identity/role/list";
            public const string UpsertRole = BaseUrl + "/identity/role/upsert";
            public const string DeleteRole = BaseUrl + "/identity/role/{request}";
            public const string SingleRole = BaseUrl + "/identity/role/{request}";

        }

    }
}
