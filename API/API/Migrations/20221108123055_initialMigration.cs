using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CatalogName = table.Column<string>(type: "text", nullable: true),
                    WuName = table.Column<string>(type: "text", nullable: true),
                    WuPrice = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KPIType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KPIType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectNumber = table.Column<string>(type: "text", nullable: true),
                    ACME = table.Column<bool>(type: "boolean", nullable: true),
                    Service = table.Column<string>(type: "text", nullable: true),
                    RiskPlan = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSubcontrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ContactName = table.Column<string>(type: "text", nullable: true),
                    ContactEmail = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSubcontrator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siglum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siglum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAcceptanceNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    Month = table.Column<int>(type: "integer", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: true),
                    DanSerial = table.Column<int>(type: "integer", nullable: true),
                    DanGenerationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BoD = table.Column<string>(type: "text", nullable: true),
                    PhtFocal = table.Column<string>(type: "text", nullable: true),
                    BodSigned = table.Column<bool>(type: "boolean", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAcceptanceNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAcceptanceNote_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PoAirbusTech = table.Column<string>(type: "text", nullable: true),
                    PoAirbus = table.Column<string>(type: "text", nullable: true),
                    PoPhtSubc = table.Column<string>(type: "text", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderWUForecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WUName = table.Column<int>(type: "integer", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    January = table.Column<int>(type: "integer", nullable: true),
                    February = table.Column<int>(type: "integer", nullable: true),
                    March = table.Column<int>(type: "integer", nullable: true),
                    April = table.Column<int>(type: "integer", nullable: true),
                    May = table.Column<int>(type: "integer", nullable: true),
                    June = table.Column<int>(type: "integer", nullable: true),
                    July = table.Column<int>(type: "integer", nullable: true),
                    August = table.Column<int>(type: "integer", nullable: true),
                    September = table.Column<int>(type: "integer", nullable: true),
                    October = table.Column<int>(type: "integer", nullable: true),
                    November = table.Column<int>(type: "integer", nullable: true),
                    December = table.Column<int>(type: "integer", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWUForecast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderWUForecast_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdsContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bod = table.Column<string>(type: "text", nullable: true),
                    Email1 = table.Column<string>(type: "text", nullable: true),
                    Email2 = table.Column<string>(type: "text", nullable: true),
                    Ios = table.Column<string>(type: "text", nullable: true),
                    SiglumId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdsContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdsContact_Siglum_SiglumId",
                        column: x => x.SiglumId,
                        principalTable: "Siglum",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderWUDistribution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: true),
                    WUName = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    January = table.Column<int>(type: "integer", nullable: true),
                    February = table.Column<int>(type: "integer", nullable: true),
                    March = table.Column<int>(type: "integer", nullable: true),
                    April = table.Column<int>(type: "integer", nullable: true),
                    May = table.Column<int>(type: "integer", nullable: true),
                    June = table.Column<int>(type: "integer", nullable: true),
                    July = table.Column<int>(type: "integer", nullable: true),
                    August = table.Column<int>(type: "integer", nullable: true),
                    September = table.Column<int>(type: "integer", nullable: true),
                    October = table.Column<int>(type: "integer", nullable: true),
                    November = table.Column<int>(type: "integer", nullable: true),
                    December = table.Column<int>(type: "integer", nullable: true),
                    JanuaryStatus = table.Column<int>(type: "integer", nullable: true),
                    FebruaryStatus = table.Column<int>(type: "integer", nullable: true),
                    MarchStatus = table.Column<int>(type: "integer", nullable: true),
                    AprilStatus = table.Column<int>(type: "integer", nullable: true),
                    MayStatus = table.Column<int>(type: "integer", nullable: true),
                    JuneStatus = table.Column<int>(type: "integer", nullable: true),
                    JulyStatus = table.Column<int>(type: "integer", nullable: true),
                    AugustStatus = table.Column<int>(type: "integer", nullable: true),
                    SeptemberStatus = table.Column<int>(type: "integer", nullable: true),
                    OctoberStatus = table.Column<int>(type: "integer", nullable: true),
                    NovemberStatus = table.Column<int>(type: "integer", nullable: true),
                    DecemberStatus = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWUDistribution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderWUDistribution_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAcceptandeNoteLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DanId = table.Column<int>(type: "integer", nullable: true),
                    OrderWUDistributionId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Otd = table.Column<int>(type: "integer", nullable: true),
                    Oqd = table.Column<int>(type: "integer", nullable: true),
                    Rft = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAcceptandeNoteLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAcceptandeNoteLine_DeliveryAcceptanceNote_DanId",
                        column: x => x.DanId,
                        principalTable: "DeliveryAcceptanceNote",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryAcceptandeNoteLine_OrderWUDistribution_OrderWUDistr~",
                        column: x => x.OrderWUDistributionId,
                        principalTable: "OrderWUDistribution",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order_WU_KPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderWUDistributionId = table.Column<int>(type: "integer", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    January = table.Column<int>(type: "integer", nullable: true),
                    February = table.Column<int>(type: "integer", nullable: true),
                    March = table.Column<int>(type: "integer", nullable: true),
                    April = table.Column<int>(type: "integer", nullable: true),
                    May = table.Column<int>(type: "integer", nullable: true),
                    June = table.Column<int>(type: "integer", nullable: true),
                    July = table.Column<int>(type: "integer", nullable: true),
                    August = table.Column<int>(type: "integer", nullable: true),
                    September = table.Column<int>(type: "integer", nullable: true),
                    October = table.Column<int>(type: "integer", nullable: true),
                    November = table.Column<int>(type: "integer", nullable: true),
                    December = table.Column<int>(type: "integer", nullable: true),
                    KPITypeId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_WU_KPI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_WU_KPI_KPIType_KPITypeId",
                        column: x => x.KPITypeId,
                        principalTable: "KPIType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_WU_KPI_OrderWUDistribution_OrderWUDistributionId",
                        column: x => x.OrderWUDistributionId,
                        principalTable: "OrderWUDistribution",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdsContact_SiglumId",
                table: "AdsContact",
                column: "SiglumId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAcceptanceNote_ProjectId",
                table: "DeliveryAcceptanceNote",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAcceptandeNoteLine_DanId",
                table: "DeliveryAcceptandeNoteLine",
                column: "DanId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAcceptandeNoteLine_OrderWUDistributionId",
                table: "DeliveryAcceptandeNoteLine",
                column: "OrderWUDistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProjectId",
                table: "Order",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_WU_KPI_KPITypeId",
                table: "Order_WU_KPI",
                column: "KPITypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_WU_KPI_OrderWUDistributionId",
                table: "Order_WU_KPI",
                column: "OrderWUDistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWUDistribution_OrderId",
                table: "OrderWUDistribution",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWUForecast_ProjectId",
                table: "OrderWUForecast",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdsContact");

            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "DeliveryAcceptandeNoteLine");

            migrationBuilder.DropTable(
                name: "Order_WU_KPI");

            migrationBuilder.DropTable(
                name: "OrderWUForecast");

            migrationBuilder.DropTable(
                name: "ProjectSubcontrator");

            migrationBuilder.DropTable(
                name: "Siglum");

            migrationBuilder.DropTable(
                name: "DeliveryAcceptanceNote");

            migrationBuilder.DropTable(
                name: "KPIType");

            migrationBuilder.DropTable(
                name: "OrderWUDistribution");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
