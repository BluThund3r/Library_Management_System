using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class modifiedsubscriptioncardfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SubscriptionCards_Id",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionCards_UserId",
                table: "SubscriptionCards",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionCards_Users_UserId",
                table: "SubscriptionCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionCards_Users_UserId",
                table: "SubscriptionCards");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionCards_UserId",
                table: "SubscriptionCards");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SubscriptionCards_Id",
                table: "Users",
                column: "Id",
                principalTable: "SubscriptionCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
