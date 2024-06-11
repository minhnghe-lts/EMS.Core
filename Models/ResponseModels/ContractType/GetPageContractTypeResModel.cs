namespace EMS.Core.Models.ResponseModels
{
    public class GetPageContractTypeResModel : BasePaginationResModel
    {
        public List<ContractTypeResModel> Data { get; set; }
    }

    public class ContractTypeResModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

    }
}
