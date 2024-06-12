using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseAndSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountPermissions_Accounts_AccountId",
                table: "AccountPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountPermissions_Permissions_PermissionId",
                table: "AccountPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Accounts_AccountId",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Roles_RoleId",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Tenants_TenantId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitDepartment_Benefits_BenefitId",
                table: "BenefitDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitDepartment_Departments_DepartmentId",
                table: "BenefitDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitPosition_Benefits_BenefitId",
                table: "BenefitPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitPosition_Positions_PositionId",
                table: "BenefitPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractAllowance_Contracts_ContractId",
                table: "ContractAllowance");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractBenefit_Benefits_BenefitId",
                table: "ContractBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractBenefit_Contracts_ContractId",
                table: "ContractBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractRemunerationRegime_Contracts_ContractId",
                table: "ContractRemunerationRegime");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractRemunerationRegime_RemunerationRegime_RemunerationRegimeId",
                table: "ContractRemunerationRegime");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_ContractTypes_ContractTypeId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Departments_DepartmentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_EmployeeId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Positions_PositionId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentManagers_Departments_DepartmentId",
                table: "DepartmentManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentManagers_Employees_EmployeeId",
                table: "DepartmentManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DepartmentLevels_DepartmentLevelId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSchedules_Employees_EmployeeId",
                table: "EmployeeSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSchedules_Schedules_ScheduleId",
                table: "EmployeeSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Tenants_TenantId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionFeatures_Permissions_PermissionId",
                table: "PermissionFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPermissions_Permissions_PermissionId",
                table: "PositionPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPermissions_Positions_PositionId",
                table: "PositionPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionRoles_Positions_PositionId",
                table: "PositionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionRoles_Roles_RoleId",
                table: "PositionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_RemunerationRegimeBenefit_Benefits_BenefitId",
                table: "RemunerationRegimeBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_RemunerationRegimeBenefit_RemunerationRegime_RemunerationRegimeId",
                table: "RemunerationRegimeBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Tenants_TenantId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAllocation_EmployeeSchedules_EmployeeScheduleId",
                table: "StudentAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAllocation_Students_StudentId",
                table: "StudentAllocation");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSubjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_CourseId",
                table: "CourseSubjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_SubjectId",
                table: "CourseSubjects",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountPermissions_Accounts_AccountId",
                table: "AccountPermissions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountPermissions_Permissions_PermissionId",
                table: "AccountPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Accounts_AccountId",
                table: "AccountRoles",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Roles_RoleId",
                table: "AccountRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Tenants_TenantId",
                table: "Accounts",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitDepartment_Benefits_BenefitId",
                table: "BenefitDepartment",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitDepartment_Departments_DepartmentId",
                table: "BenefitDepartment",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitPosition_Benefits_BenefitId",
                table: "BenefitPosition",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitPosition_Positions_PositionId",
                table: "BenefitPosition",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractAllowance_Contracts_ContractId",
                table: "ContractAllowance",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractBenefit_Benefits_BenefitId",
                table: "ContractBenefit",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractBenefit_Contracts_ContractId",
                table: "ContractBenefit",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractRemunerationRegime_Contracts_ContractId",
                table: "ContractRemunerationRegime",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractRemunerationRegime_RemunerationRegime_RemunerationRegimeId",
                table: "ContractRemunerationRegime",
                column: "RemunerationRegimeId",
                principalTable: "RemunerationRegime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_ContractTypes_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId",
                principalTable: "ContractTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Departments_DepartmentId",
                table: "Contracts",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_EmployeeId",
                table: "Contracts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Positions_PositionId",
                table: "Contracts",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentManagers_Departments_DepartmentId",
                table: "DepartmentManagers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentManagers_Employees_EmployeeId",
                table: "DepartmentManagers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DepartmentLevels_DepartmentLevelId",
                table: "Departments",
                column: "DepartmentLevelId",
                principalTable: "DepartmentLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSchedules_Employees_EmployeeId",
                table: "EmployeeSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSchedules_Schedules_ScheduleId",
                table: "EmployeeSchedules",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Tenants_TenantId",
                table: "Holidays",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionFeatures_Permissions_PermissionId",
                table: "PermissionFeatures",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPermissions_Permissions_PermissionId",
                table: "PositionPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPermissions_Positions_PositionId",
                table: "PositionPermissions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionRoles_Positions_PositionId",
                table: "PositionRoles",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionRoles_Roles_RoleId",
                table: "PositionRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RemunerationRegimeBenefit_Benefits_BenefitId",
                table: "RemunerationRegimeBenefit",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RemunerationRegimeBenefit_RemunerationRegime_RemunerationRegimeId",
                table: "RemunerationRegimeBenefit",
                column: "RemunerationRegimeId",
                principalTable: "RemunerationRegime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Tenants_TenantId",
                table: "Roles",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAllocation_EmployeeSchedules_EmployeeScheduleId",
                table: "StudentAllocation",
                column: "EmployeeScheduleId",
                principalTable: "EmployeeSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAllocation_Students_StudentId",
                table: "StudentAllocation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountPermissions_Accounts_AccountId",
                table: "AccountPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountPermissions_Permissions_PermissionId",
                table: "AccountPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Accounts_AccountId",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Roles_RoleId",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Tenants_TenantId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitDepartment_Benefits_BenefitId",
                table: "BenefitDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitDepartment_Departments_DepartmentId",
                table: "BenefitDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitPosition_Benefits_BenefitId",
                table: "BenefitPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitPosition_Positions_PositionId",
                table: "BenefitPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractAllowance_Contracts_ContractId",
                table: "ContractAllowance");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractBenefit_Benefits_BenefitId",
                table: "ContractBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractBenefit_Contracts_ContractId",
                table: "ContractBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractRemunerationRegime_Contracts_ContractId",
                table: "ContractRemunerationRegime");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractRemunerationRegime_RemunerationRegime_RemunerationRegimeId",
                table: "ContractRemunerationRegime");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_ContractTypes_ContractTypeId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Departments_DepartmentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_EmployeeId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Positions_PositionId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentManagers_Departments_DepartmentId",
                table: "DepartmentManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentManagers_Employees_EmployeeId",
                table: "DepartmentManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DepartmentLevels_DepartmentLevelId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSchedules_Employees_EmployeeId",
                table: "EmployeeSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSchedules_Schedules_ScheduleId",
                table: "EmployeeSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Tenants_TenantId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionFeatures_Permissions_PermissionId",
                table: "PermissionFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPermissions_Permissions_PermissionId",
                table: "PositionPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPermissions_Positions_PositionId",
                table: "PositionPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionRoles_Positions_PositionId",
                table: "PositionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionRoles_Roles_RoleId",
                table: "PositionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_RemunerationRegimeBenefit_Benefits_BenefitId",
                table: "RemunerationRegimeBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_RemunerationRegimeBenefit_RemunerationRegime_RemunerationRegimeId",
                table: "RemunerationRegimeBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Tenants_TenantId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAllocation_EmployeeSchedules_EmployeeScheduleId",
                table: "StudentAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAllocation_Students_StudentId",
                table: "StudentAllocation");

            migrationBuilder.DropTable(
                name: "CourseSubjects");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountPermissions_Accounts_AccountId",
                table: "AccountPermissions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountPermissions_Permissions_PermissionId",
                table: "AccountPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Accounts_AccountId",
                table: "AccountRoles",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Roles_RoleId",
                table: "AccountRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Tenants_TenantId",
                table: "Accounts",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitDepartment_Benefits_BenefitId",
                table: "BenefitDepartment",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitDepartment_Departments_DepartmentId",
                table: "BenefitDepartment",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitPosition_Benefits_BenefitId",
                table: "BenefitPosition",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitPosition_Positions_PositionId",
                table: "BenefitPosition",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractAllowance_Contracts_ContractId",
                table: "ContractAllowance",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractBenefit_Benefits_BenefitId",
                table: "ContractBenefit",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractBenefit_Contracts_ContractId",
                table: "ContractBenefit",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractRemunerationRegime_Contracts_ContractId",
                table: "ContractRemunerationRegime",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractRemunerationRegime_RemunerationRegime_RemunerationRegimeId",
                table: "ContractRemunerationRegime",
                column: "RemunerationRegimeId",
                principalTable: "RemunerationRegime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_ContractTypes_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId",
                principalTable: "ContractTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Departments_DepartmentId",
                table: "Contracts",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_EmployeeId",
                table: "Contracts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Positions_PositionId",
                table: "Contracts",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentManagers_Departments_DepartmentId",
                table: "DepartmentManagers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentManagers_Employees_EmployeeId",
                table: "DepartmentManagers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DepartmentLevels_DepartmentLevelId",
                table: "Departments",
                column: "DepartmentLevelId",
                principalTable: "DepartmentLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSchedules_Employees_EmployeeId",
                table: "EmployeeSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSchedules_Schedules_ScheduleId",
                table: "EmployeeSchedules",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Tenants_TenantId",
                table: "Holidays",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionFeatures_Permissions_PermissionId",
                table: "PermissionFeatures",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPermissions_Permissions_PermissionId",
                table: "PositionPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPermissions_Positions_PositionId",
                table: "PositionPermissions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionRoles_Positions_PositionId",
                table: "PositionRoles",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionRoles_Roles_RoleId",
                table: "PositionRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RemunerationRegimeBenefit_Benefits_BenefitId",
                table: "RemunerationRegimeBenefit",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RemunerationRegimeBenefit_RemunerationRegime_RemunerationRegimeId",
                table: "RemunerationRegimeBenefit",
                column: "RemunerationRegimeId",
                principalTable: "RemunerationRegime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Tenants_TenantId",
                table: "Roles",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAllocation_EmployeeSchedules_EmployeeScheduleId",
                table: "StudentAllocation",
                column: "EmployeeScheduleId",
                principalTable: "EmployeeSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAllocation_Students_StudentId",
                table: "StudentAllocation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
