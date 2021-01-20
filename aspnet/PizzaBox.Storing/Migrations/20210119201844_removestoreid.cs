using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class removestoreid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreEntityId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "StoreEntityId",
                table: "Orders",
                newName: "StoreEntityID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_StoreEntityId",
                table: "Orders",
                newName: "IX_Orders_StoreEntityID");

            migrationBuilder.AlterColumn<long>(
                name: "StoreEntityID",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders",
                column: "StoreEntityID",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreEntityID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "StoreEntityID",
                table: "Orders",
                newName: "StoreEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_StoreEntityID",
                table: "Orders",
                newName: "IX_Orders_StoreEntityId");

            migrationBuilder.AlterColumn<long>(
                name: "StoreEntityId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreEntityId",
                table: "Orders",
                column: "StoreEntityId",
                principalTable: "Stores",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
