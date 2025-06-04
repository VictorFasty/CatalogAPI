﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CatalogoAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Stock = table.Column<float>(type: "real", nullable: false),
                    DateOfRegistry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Products_tb_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tb_category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Products_CategoryId",
                table: "tb_Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Products");

            migrationBuilder.DropTable(
                name: "tb_category");
        }
    }
}
