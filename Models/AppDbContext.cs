using EMS.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Core.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountPermission> AccountPermissions { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractAllowance> ContractAllowances { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentLevel> DepartmentLevels { get; set; }
        public DbSet<DepartmentManager> DepartmentManagers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionFeature> PermissionFeatures { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionPermission> PositionPermissions { get; set; }
        public DbSet<PositionRole> PositionRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAllocation> StudentAllocation { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
