namespace EMS.Core.Models.ResponseModels
{
    public class GetPageSubjectResModel : BasePaginationResModel
    {
        public List<SubjectResModel> Data { get; set; }
    }

    public class SubjectResModel
    {
        public long Id { get; set; }
        public string CodeName { get; set; }
        public string Name { get; set; }
        public int TotalExercise { get; set; }
    }
}
