using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoApp.DataAccess.Migrations
{
    public partial class NotificationForSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Notification",
                table: "Subscriptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notification",
                table: "Subscriptions");
        }
    }
}
