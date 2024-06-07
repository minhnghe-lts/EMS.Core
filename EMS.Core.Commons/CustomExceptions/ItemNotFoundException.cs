namespace EMS.Core.Commons
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base(CommonConstants.ExceptionMessage.ITEM_NOT_FOUND)
        {

        }
    }
}
