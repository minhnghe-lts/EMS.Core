namespace EMS.Core.Models
{
    public partial class DataSeeding
    {
        private static Tenant _adminTenant;
        private static Department _department;
        private static Position _position;
        private static Employee _employee;
        public static void InitData(AppDbContext context)
        {
            if (!context.Tenants.Any())
            {
                _adminTenant = new Tenant
                {
                    IsActive = true
                };
                context.Tenants.Add(_adminTenant);
                context.SaveChanges();
            }
            else
            {
                _adminTenant = context.Tenants.FirstOrDefault();
            }

            if (!context.DepartmentLevels.Any())
            {
                context.DepartmentLevels.Add(new DepartmentLevel
                {
                    Level = 1,
                    Name = "Root",
                    TenantId = _adminTenant.Id,
                });
                context.SaveChanges();
            }

            if (!context.Departments.Any())
            {
                //_department = new Department
                //{
                //    Name = "Head Quarter",
                //    IsActive = true,
                //    TenantId = _adminTenant.Id,
                //    DepartmentLevelId = context.DepartmentLevels.FirstOrDefault().Id
                //};
                //context.Departments.Add(_department);
                //context.SaveChanges();
            }
            else
            {
                _department = context.Departments.FirstOrDefault();
            }

            if (!context.Positions.Any())
            {
                _position = new Position
                {
                    TenantId = _adminTenant.Id,
                    DepartmentId = _department.Id,
                    Name = "Default Position"
                };
                context.Positions.Add(_position);
                context.SaveChanges();
            }
            else
            {
                _position = context.Positions.FirstOrDefault();
            }

            if (!context.Employees.Any())
            {
                _employee = new Employee
                {
                    DepartmentId = _department.Id,
                    FirstName = "Super",
                    LastName = "Admin",
                    IsActive = true,
                    PositionId = _position.Id,
                    TenantId = _adminTenant.Id,
                };
                context.Employees.Add(_employee);
                context.SaveChanges();
            }
            else
            {
                _employee = context.Employees.FirstOrDefault();
            }

            if (!context.Accounts.Any())
            {
                context.Accounts.Add(new Account
                {
                    EmployeeId = _employee.Id,
                    IsActive = true,
                    TenantId = _adminTenant.Id,
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("123123")
                });
                context.SaveChanges();
            }
        }
    }
}
