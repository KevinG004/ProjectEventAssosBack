using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEventAssos.Infrastucture.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class DbSetFinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categorie_CategorieId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipateEvent_Events_EventId",
                table: "ParticipateEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipateEvent_Users_UserId",
                table: "ParticipateEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_WaitingListEvent_Events_EventId",
                table: "WaitingListEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_WaitingListEvent_Users_UserId",
                table: "WaitingListEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaitingListEvent",
                table: "WaitingListEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipateEvent",
                table: "ParticipateEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie");

            migrationBuilder.RenameTable(
                name: "WaitingListEvent",
                newName: "WaitingListEvents");

            migrationBuilder.RenameTable(
                name: "ParticipateEvent",
                newName: "ParticipateEvents");

            migrationBuilder.RenameTable(
                name: "Categorie",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_WaitingListEvent_UserId",
                table: "WaitingListEvents",
                newName: "IX_WaitingListEvents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipateEvent_UserId",
                table: "ParticipateEvents",
                newName: "IX_ParticipateEvents_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaitingListEvents",
                table: "WaitingListEvents",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipateEvents",
                table: "ParticipateEvents",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategorieId",
                table: "Events",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipateEvents_Events_EventId",
                table: "ParticipateEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipateEvents_Users_UserId",
                table: "ParticipateEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingListEvents_Events_EventId",
                table: "WaitingListEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingListEvents_Users_UserId",
                table: "WaitingListEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategorieId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipateEvents_Events_EventId",
                table: "ParticipateEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipateEvents_Users_UserId",
                table: "ParticipateEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_WaitingListEvents_Events_EventId",
                table: "WaitingListEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_WaitingListEvents_Users_UserId",
                table: "WaitingListEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaitingListEvents",
                table: "WaitingListEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipateEvents",
                table: "ParticipateEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "WaitingListEvents",
                newName: "WaitingListEvent");

            migrationBuilder.RenameTable(
                name: "ParticipateEvents",
                newName: "ParticipateEvent");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorie");

            migrationBuilder.RenameIndex(
                name: "IX_WaitingListEvents_UserId",
                table: "WaitingListEvent",
                newName: "IX_WaitingListEvent_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipateEvents_UserId",
                table: "ParticipateEvent",
                newName: "IX_ParticipateEvent_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaitingListEvent",
                table: "WaitingListEvent",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipateEvent",
                table: "ParticipateEvent",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorie",
                table: "Categorie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categorie_CategorieId",
                table: "Events",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipateEvent_Events_EventId",
                table: "ParticipateEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipateEvent_Users_UserId",
                table: "ParticipateEvent",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingListEvent_Events_EventId",
                table: "WaitingListEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingListEvent_Users_UserId",
                table: "WaitingListEvent",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
