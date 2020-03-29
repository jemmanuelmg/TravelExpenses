using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelExpenses.Web.Migrations
{
    public partial class CommentFieldInExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Expenses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Expenses");
        }
    }
}
