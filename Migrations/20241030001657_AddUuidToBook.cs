using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BooksAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUuidToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing `Id` column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Books");

            // Add a new `Id` column with UUID as default value
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Books",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()");

            // Optionally, add primary key constraint
            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the new UUID `Id` column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Books");

            // Recreate the original `Id` column as integer (if needed)
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Books",
                type: "integer",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");
        }

    }
}
