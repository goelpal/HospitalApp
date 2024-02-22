using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_DoctorId",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Patient",
                newName: "Doctor1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_DoctorId",
                table: "Patient",
                newName: "IX_Patient_Doctor1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_Doctor1Id",
                table: "Patient",
                column: "Doctor1Id",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_Doctor1Id",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "Doctor1Id",
                table: "Patient",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_Doctor1Id",
                table: "Patient",
                newName: "IX_Patient_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_DoctorId",
                table: "Patient",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
