namespace EMS.Core.Models.DatabaseSeeding
{
    public partial class DataSeeding
    {
        private static Tenant _adminTenant;
        private static Department _department;
        public static void InitData(AppDbContext context)
        {
            if (!context.Tenants.Any())
            {
                _adminTenant = new Tenant {
                    
                };
                context.Tenants.Add(_adminTenant);
                context.SaveChanges();
            }
            else
            {
                _adminTenant = context.Tenants.FirstOrDefault();
            }

            if (!context.Departments.Any())
            {

                context.Departments.Add(new Department
                {
                    Name = "Root",
                    IsActive = true,
                    TenantId = _adminTenant.Id,
                });
                context.SaveChanges();
            }
            else
            {
                _department = context.Departments.FirstOrDefault();
            }

            if (!context.Positions.Any())
            {
                var dept = context.Departments.FirstOrDefault();
                if (dept != null)
                {
                    context.Positions.Add(new Position
                    {
                        TenantId = _adminTenant.Id,
                        DepartmentId = dept.Id,
                        Name = "Dev"
                    });
                    context.SaveChanges();
                }
            }

            if (!context.Employees.Any())
            {
                var dept = context.Departments.FirstOrDefault();

            }
        }
    }
}
