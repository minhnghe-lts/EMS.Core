namespace EMS.Core.Commons
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string objectName) : base(string.Format(CommonConstants.ExceptionMessage.OBJECT_INCORRECT_FORMAT, objectName))
        {

        }

        public InvalidFormatException() : base(CommonConstants.ExceptionMessage.INCORRECT_FORMAT)
        {

        }
    }
}
