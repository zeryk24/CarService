using Microsoft.EntityFrameworkCore.Migrations;

namespace CarService.DAL.Migrations
{
    public partial class new_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumes_Repaires_RepairId",
                table: "Consumes");

            migrationBuilder.DropTable(
                name: "MechanicActivities");

            migrationBuilder.RenameColumn(
                name: "RepairId",
                table: "Consumes",
                newName: "ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Consumes_RepairId",
                table: "Consumes",
                newName: "IX_Consumes_ActivityId");

            migrationBuilder.AddColumn<int>(
                name: "MechanicId",
                table: "Repaires",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Repaires_MechanicId",
                table: "Repaires",
                column: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumes_Activities_ActivityId",
                table: "Consumes",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repaires_Mechanics_MechanicId",
                table: "Repaires",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumes_Activities_ActivityId",
                table: "Consumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Repaires_Mechanics_MechanicId",
                table: "Repaires");

            migrationBuilder.DropIndex(
                name: "IX_Repaires_MechanicId",
                table: "Repaires");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                table: "Repaires");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "Consumes",
                newName: "RepairId");

            migrationBuilder.RenameIndex(
                name: "IX_Consumes_ActivityId",
                table: "Consumes",
                newName: "IX_Consumes_RepairId");

            migrationBuilder.CreateTable(
                name: "MechanicActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityEntityId = table.Column<int>(type: "int", nullable: true),
                    MechanicEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MechanicActivities_Activities_ActivityEntityId",
                        column: x => x.ActivityEntityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MechanicActivities_Mechanics_MechanicEntityId",
                        column: x => x.MechanicEntityId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicActivities_ActivityEntityId",
                table: "MechanicActivities",
                column: "ActivityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicActivities_MechanicEntityId",
                table: "MechanicActivities",
                column: "MechanicEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumes_Repaires_RepairId",
                table: "Consumes",
                column: "RepairId",
                principalTable: "Repaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
