namespace EMS.Core.Models
{
    public partial class DataSeeding
    {
        public static void ProductionSeeding(AppDbContext context)
        {
            if (!context.Tenants.Any())
            {

            }
        }
    }
}