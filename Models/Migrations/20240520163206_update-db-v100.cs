using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class updatedbv100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DirectManagerId",
                table: "Employees",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Benefits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsPayWithSalary",
                table: "Benefits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "Benefits",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayMonth",
                table: "Benefits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BenefitDepartment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitDepartment_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BenefitDepartment_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BenefitPosition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitId = table.Column<long>(type: "bigint", nullable: false),
                    PositionId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitPosition_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BenefitPosition_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContractAllowance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractAllowance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractAllowance_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContractBenefit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    BenefitId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractBenefit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractBenefit_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractBenefit_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RemunerationRegime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemunerationRegime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractRemunerationRegime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    RemunerationRegimeId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRemunerationRegime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRemunerationRegime_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractRemunerationRegime_RemunerationRegime_RemunerationRegimeId",
                        column: x => x.RemunerationRegimeId,
                        principalTable: "RemunerationRegime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RemunerationRegimeBenefit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemunerationRegimeId = table.Column<long>(type: "bigint", nullable: false),
                    BenefitId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemunerationRegimeBenefit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemunerationRegimeBenefit_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RemunerationRegimeBenefit_RemunerationRegime_RemunerationRegimeId",
                        column: x => x.RemunerationRegimeId,
                        principalTable: "RemunerationRegime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DirectManagerId",
                table: "Employees",
                column: "DirectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitDepartment_BenefitId",
                table: "BenefitDepartment",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitDepartment_DepartmentId",
                table: "BenefitDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitPosition_BenefitId",
                table: "BenefitPosition",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitPosition_PositionId",
                table: "BenefitPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAllowance_ContractId",
                table: "ContractAllowance",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBenefit_BenefitId",
                table: "ContractBenefit",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBenefit_ContractId",
                table: "ContractBenefit",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRemunerationRegime_ContractId",
                table: "ContractRemunerationRegime",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRemunerationRegime_RemunerationRegimeId",
                table: "ContractRemunerationRegime",
                column: "RemunerationRegimeId");

            migrationBuilder.CreateIndex(
                name: "IX_RemunerationRegimeBenefit_BenefitId",
                table: "RemunerationRegimeBenefit",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_RemunerationRegimeBenefit_RemunerationRegimeId",
                table: "RemunerationRegimeBenefit",
                column: "RemunerationRegimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_DirectManagerId",
                table: "Employees",
                column: "DirectManagerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_DirectManagerId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "BenefitDepartment");

            migrationBuilder.DropTable(
                name: "BenefitPosition");

            migrationBuilder.DropTable(
                name: "ContractAllowance");

            migrationBuilder.DropTable(
                name: "ContractBenefit");

            migrationBuilder.DropTable(
                name: "ContractRemunerationRegime");

            migrationBuilder.DropTable(
                name: "RemunerationRegimeBenefit");

            migrationBuilder.DropTable(
                name: "RemunerationRegime");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DirectManagerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DirectManagerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "IsPayWithSalary",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "PayMonth",
                table: "Benefits");
        }
    }
}
