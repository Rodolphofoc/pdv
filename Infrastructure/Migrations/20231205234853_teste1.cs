using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class teste1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetaEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstrumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstTradeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegularMarketTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gmtoffset = table.Column<TimeSpan>(type: "time", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeTimezoneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegularMarketPrice = table.Column<float>(type: "real", nullable: false),
                    ChartPreviousClose = table.Column<float>(type: "real", nullable: false),
                    PreviousClose = table.Column<float>(type: "real", nullable: false),
                    Scale = table.Column<int>(type: "int", nullable: false),
                    PriceHint = table.Column<int>(type: "int", nullable: false),
                    DataGranularity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IntegrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaEntity");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
