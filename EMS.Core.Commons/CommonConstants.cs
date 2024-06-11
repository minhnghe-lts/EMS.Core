namespace EMS.Core.Commons
{
    public class CommonConstants
    {
        public class DefaultValue
        {
            public const string DEFAULT_CONTROLLER_ROUTE = "api/[controller]/[action]";
            public const int DEFAULT_PAGE_SIZE = 10;
            public const int DEFAULT_PAGE_NO = 1;
            public const int DEFAULT_TOKEN_EXPIRED_TIME_IN_MINUTE = 12000;
            public const int DEFAULT_REFRESH_TOKEN_EXPIRED_TIME_IN_HOUR = 3;
        }
        public class ExceptionMessage
        {
            public const string ITEM_NOT_FOUND = "Item not found";
            public const string INCORRECT_FORMAT = "Invalid format";
            public const string OBJECT_INCORRECT_FORMAT = "Invalid {0} format";
        }

        public class AppSettingKeys
        {
            public const string DEFAULT_CONNECTION = "DefaultConnection";
            public const string AUTH_SECRET = "AuthSecret";
        }

        public class ContextItem
        {
            public const string USER = "User";
            public const string PERMISSIONS = "Permissions";
            public const string TENANT_ID = "TenantId";
        }
    }
}
