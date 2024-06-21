namespace EMS.Core.Models.RequestModels
{
    public class CreateEditSubjectReqModel
    {
        public long Id { get; set; }
        public string CodeName { get; set; }
        public string Name { get; set; }
        public int TotalExercise { get; set; }
    }
}
