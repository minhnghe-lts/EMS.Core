using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tenant_Holiday_Reference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Holidays_TenantId",
                table: "Holidays",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Tenants_TenantId",
                table: "Holidays",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Tenants_TenantId",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_TenantId",
                table: "Holidays");
        }
    }
}
