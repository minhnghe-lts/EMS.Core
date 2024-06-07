namespace EMS.Core.Commons
{
    public class CommonEnums
    {
        public enum FeatureCode
        {
            Common = 0,
            SuperAdmin = 1,
            SystemAdmin = 2,
        }

        public enum PayMonth
        {
            All = 0,
            Jan,
            Feb,
            Mar,
            Apr,
            May,
            Jun,
            Jul,
            Aug,
            Sep,
            Oct,
            Nov,
            Dec,
            None
        }

        public enum RequestStatus
        {
            Draft,
            Submited,
            Approved,
            Rejected,
            Pending
        }

        public enum RequestFieldType
        {
            Text,
            MultiLineText,
            Date,
            Number,
            Employee
        }
    }
}
