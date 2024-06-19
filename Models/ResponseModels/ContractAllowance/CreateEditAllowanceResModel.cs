namespace EMS.Core.Models.ResponseModels
{
    public class CreateEditAllowanceResModel
    {
        public long Id {  get; set; }
        public string Name {  get; set; }
        public string Decription { get; set; }
        public decimal Amount {  get; set; }
        public DateTime FromDate {  get; set; }
        public DateTime ToDate { get; set; }
    }
}
