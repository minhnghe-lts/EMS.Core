using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class updateaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractRemunerationRegime",
                table: "ContractRemunerationRegime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractBenefit",
                table: "ContractBenefit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractAllowance",
                table: "ContractAllowance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BenefitPosition",
                table: "BenefitPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BenefitDepartment",
                table: "BenefitDepartment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ContractAllowance");

            migrationBuilder.RenameTable(
                name: "ContractRemunerationRegime",
                newName: "ContractRemunerationRegimes");

            migrationBuilder.RenameTable(
                name: "ContractBenefit",
                newName: "ContractBenefits");

            migrationBuilder.RenameTable(
                name: "ContractAllowance",
                newName: "ContractAllowances");

            migrationBuilder.RenameTable(
                name: "BenefitPosition",
                newName: "BenefitPositions");

            migrationBuilder.RenameTable(
                name: "BenefitDepartment",
                newName: "BenefitDepartments");

            migrationBuilder.RenameIndex(
                name: "IX_ContractRemunerationRegime_RemunerationRegimeId",
                table: "ContractRemunerationRegimes",
                newName: "IX_ContractRemunerationRegimes_RemunerationRegimeId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractRemunerationRegime_ContractId",
                table: "ContractRemunerationRegimes",
                newName: "IX_ContractRemunerationRegimes_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractBenefit_ContractId",
                table: "ContractBenefits",
                newName: "IX_ContractBenefits_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractBenefit_BenefitId",
                table: "ContractBenefits",
                newName: "IX_ContractBenefits_BenefitId");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "ContractAllowances",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ContractAllowance_ContractId",
                table: "ContractAllowances",
                newName: "IX_ContractAllowances_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_BenefitPosition_PositionId",
                table: "BenefitPositions",
                newName: "IX_BenefitPositions_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_BenefitPosition_BenefitId",
                table: "BenefitPositions",
                newName: "IX_BenefitPositions_BenefitId");

            migrationBuilder.RenameIndex(
                name: "IX_BenefitDepartment_DepartmentId",
                table: "BenefitDepartments",
                newName: "IX_BenefitDepartments_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_BenefitDepartment_BenefitId",
                table: "BenefitDepartments",
                newName: "IX_BenefitDepartments_BenefitId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "History",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ContractAllowances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ContractAllowances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ContractAllowances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "ContractAllowances",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractRemunerationRegimes",
                table: "ContractRemunerationRegimes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractBenefits",
                table: "ContractBenefits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractAllowances",
                table: "ContractAllowances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BenefitPositions",
                table: "BenefitPositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BenefitDepartments",
                table: "BenefitDepartments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitDepartments_Benefits_BenefitId",
                table: "BenefitDepartments",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitDepartments_Departments_DepartmentId",
                table: "BenefitDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitPositions_Benefits_BenefitId",
                table: "BenefitPositions",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitPositions_Positions_PositionId",
                table: "BenefitPositions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractAllowances_Contracts_ContractId",
                table: "ContractAllowances",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractBenefits_Benefits_BenefitId",
                table: "ContractBenefits",
                column: "BenefitId",
                principalTable: "Benefits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractBenefits_Contracts_ContractId",
                table: "ContractBenefits",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractRemunerationRegimes_Contracts_ContractId",
                table: "ContractRemunerationRegimes",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractRemunerationRegimes_RemunerationRegime_RemunerationRegimeId",
                table: "ContractRemunerationRegimes",
                column: "RemunerationRegimeId",
                principalTable: "RemunerationRegime",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BenefitDepartments_Benefits_BenefitId",
                table: "BenefitDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitDepartments_Departments_DepartmentId",
                table: "BenefitDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitPositions_Benefits_BenefitId",
                table: "BenefitPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_BenefitPositions_Positions_PositionId",
                table: "BenefitPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractAllowances_Contracts_ContractId",
                table: "ContractAllowances");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractBenefits_Benefits_BenefitId",
                table: "ContractBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractBenefits_Contracts_ContractId",
                table: "ContractBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractRemunerationRegimes_Contracts_ContractId",
                table: "ContractRemunerationRegimes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractRemunerationRegimes_RemunerationRegime_RemunerationRegimeId",
                table: "ContractRemunerationRegimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractRemunerationRegimes",
                table: "ContractRemunerationRegimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractBenefits",
                table: "ContractBenefits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractAllowances",
                table: "ContractAllowances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BenefitPositions",
                table: "BenefitPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BenefitDepartments",
                table: "BenefitDepartments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "History",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ContractAllowances");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ContractAllowances");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ContractAllowances");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ContractAllowances");

            migrationBuilder.RenameTable(
                name: "ContractRemunerationRegimes",
                newName: "ContractRemunerationRegime");

            migrationBuilder.RenameTable(
                name: "ContractBenefits",
                newName: "ContractBenefit");

            migrationBuilder.RenameTable(
                name: "ContractAllowances",
                newName: "ContractAllowance");

            migrationBuilder.RenameTable(
                name: "BenefitPositions",
                newName: "BenefitPosition");

            migrationBuilder.RenameTable(
                name: "BenefitDepartments",
                newName: "BenefitDepartment");

            migrationBuilder.RenameIndex(
                name: "IX_ContractRemunerationRegimes_RemunerationRegimeId",
                table: "ContractRemunerationRegime",
                newName: "IX_ContractRemunerationRegime_RemunerationRegimeId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractRemunerationRegimes_ContractId",
                table: "ContractRemunerationRegime",
                newName: "IX_ContractRemunerationRegime_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractBenefits_ContractId",
                table: "ContractBenefit",
                newName: "IX_ContractBenefit_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractBenefits_BenefitId",
                table: "ContractBenefit",
                newName: "IX_ContractBenefit_BenefitId");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ContractAllowance",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractAllowances_ContractId",
                table: "ContractAllowance",
                newName: "IX_ContractAllowance_ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_BenefitPositions_PositionId",
                table: "BenefitPosition",
                newName: "IX_BenefitPosition_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_BenefitPositions_BenefitId",
                table: "BenefitPosition",
                newName: "IX_BenefitPosition_BenefitId");

            migrationBuilder.RenameIndex(
                name: "IX_BenefitDepartments_DepartmentId",
                table: "BenefitDepartment",
                newName: "IX_BenefitDepartment_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_BenefitDepartments_BenefitId",
                table: "BenefitDepartment",
                newName: "IX_BenefitDepartment_BenefitId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ContractAllowance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractRemunerationRegime",
                table: "ContractRemunerationRegime",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractBenefit",
                table: "ContractBenefit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractAllowance",
                table: "ContractAllowance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BenefitPosition",
                table: "BenefitPosition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BenefitDepartment",
                table: "BenefitDepartment",
                column: "Id");

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
        }
    }
}
