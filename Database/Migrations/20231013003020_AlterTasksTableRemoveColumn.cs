using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace to_do_api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AlterTasksTableRemoveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "TodoTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "TodoTasks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
