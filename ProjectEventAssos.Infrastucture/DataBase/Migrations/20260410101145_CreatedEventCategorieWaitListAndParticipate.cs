using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEventAssos.Infrastucture.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class CreatedEventCategorieWaitListAndParticipate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinParticipants = table.Column<int>(type: "int", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    WaitList = table.Column<bool>(type: "bit", nullable: false),
                    DateLimiteInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MajDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.CheckConstraint("CK_Event_DateFinishStart", "[DateTimeFinish] > [DateTimeStart]");
                    table.CheckConstraint("CK_Event_DateLimite", "[DateLimiteInscription] <= [DateTimeStart]");
                    table.CheckConstraint("CK_Event_MaxParticipant", "[MaxParticipants] <=200");
                    table.CheckConstraint("CK_Event_MinMaxParticipant", "[MinParticipants] <= [MaxParticipants]");
                    table.CheckConstraint("CK_Event_MinParticipant", "[MinParticipants] >= 1");
                    table.ForeignKey(
                        name: "FK_Events_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipateEvent",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipateEvent", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ParticipateEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipateEvent_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaitingListEvent",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingListEvent", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_WaitingListEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaitingListEvent_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategorieId",
                table: "Events",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipateEvent_UserId",
                table: "ParticipateEvent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingListEvent_UserId",
                table: "WaitingListEvent",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipateEvent");

            migrationBuilder.DropTable(
                name: "WaitingListEvent");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
