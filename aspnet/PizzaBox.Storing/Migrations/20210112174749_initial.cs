using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedStoreEntityID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Users_Stores_SelectedStoreEntityID",
                        column: x => x.SelectedStoreEntityID,
                        principalTable: "Stores",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    UserEntityID = table.Column<long>(type: "bigint", nullable: true),
                    StoreEntityID = table.Column<long>(type: "bigint", nullable: true),
                    DateModifier = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreEntityID",
                        column: x => x.StoreEntityID,
                        principalTable: "Stores",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserEntityID",
                        column: x => x.UserEntityID,
                        principalTable: "Users",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APizzaModel",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeEntityID = table.Column<long>(type: "bigint", nullable: true),
                    OrderEntityID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaModel", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_APizzaModel_Orders_OrderEntityID",
                        column: x => x.OrderEntityID,
                        principalTable: "Orders",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APizzaModel_Sizes_SizeEntityID",
                        column: x => x.SizeEntityID,
                        principalTable: "Sizes",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APizzaModelTopping",
                columns: table => new
                {
                    PizzasEntityID = table.Column<long>(type: "bigint", nullable: false),
                    ToppingsEntityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaModelTopping", x => new { x.PizzasEntityID, x.ToppingsEntityID });
                    table.ForeignKey(
                        name: "FK_APizzaModelTopping_APizzaModel_PizzasEntityID",
                        column: x => x.PizzasEntityID,
                        principalTable: "APizzaModel",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APizzaModelTopping_Toppings_ToppingsEntityID",
                        column: x => x.ToppingsEntityID,
                        principalTable: "Toppings",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Name" },
                values: new object[] { 1L, "one" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Name" },
                values: new object[] { 2L, "two" });

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModel_OrderEntityID",
                table: "APizzaModel",
                column: "OrderEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModel_SizeEntityID",
                table: "APizzaModel",
                column: "SizeEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModelTopping_ToppingsEntityID",
                table: "APizzaModelTopping",
                column: "ToppingsEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreEntityID",
                table: "Orders",
                column: "StoreEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserEntityID",
                table: "Orders",
                column: "UserEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectedStoreEntityID",
                table: "Users",
                column: "SelectedStoreEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APizzaModelTopping");

            migrationBuilder.DropTable(
                name: "APizzaModel");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
