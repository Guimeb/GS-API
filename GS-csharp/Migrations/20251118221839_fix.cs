using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GS_csharp.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceTrack_Competences_CompetencesId",
                table: "CompetenceTrack");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceTrack_Tracks_TracksId",
                table: "CompetenceTrack");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Tracks_TrackId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_UserId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetenceTrack",
                table: "CompetenceTrack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competences",
                table: "Competences");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Tracks",
                newName: "tracks");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "enrollments");

            migrationBuilder.RenameTable(
                name: "CompetenceTrack",
                newName: "competencetrack");

            migrationBuilder.RenameTable(
                name: "Competences",
                newName: "competences");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_UserId",
                table: "enrollments",
                newName: "IX_enrollments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_TrackId",
                table: "enrollments",
                newName: "IX_enrollments_TrackId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceTrack_TracksId",
                table: "competencetrack",
                newName: "IX_competencetrack_TracksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tracks",
                table: "tracks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enrollments",
                table: "enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_competencetrack",
                table: "competencetrack",
                columns: new[] { "CompetencesId", "TracksId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_competences",
                table: "competences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_competencetrack_competences_CompetencesId",
                table: "competencetrack",
                column: "CompetencesId",
                principalTable: "competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_competencetrack_tracks_TracksId",
                table: "competencetrack",
                column: "TracksId",
                principalTable: "tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_tracks_TrackId",
                table: "enrollments",
                column: "TrackId",
                principalTable: "tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_users_UserId",
                table: "enrollments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_competencetrack_competences_CompetencesId",
                table: "competencetrack");

            migrationBuilder.DropForeignKey(
                name: "FK_competencetrack_tracks_TracksId",
                table: "competencetrack");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_tracks_TrackId",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_users_UserId",
                table: "enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tracks",
                table: "tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enrollments",
                table: "enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_competencetrack",
                table: "competencetrack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_competences",
                table: "competences");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tracks",
                newName: "Tracks");

            migrationBuilder.RenameTable(
                name: "enrollments",
                newName: "Enrollments");

            migrationBuilder.RenameTable(
                name: "competencetrack",
                newName: "CompetenceTrack");

            migrationBuilder.RenameTable(
                name: "competences",
                newName: "Competences");

            migrationBuilder.RenameIndex(
                name: "IX_enrollments_UserId",
                table: "Enrollments",
                newName: "IX_Enrollments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollments_TrackId",
                table: "Enrollments",
                newName: "IX_Enrollments_TrackId");

            migrationBuilder.RenameIndex(
                name: "IX_competencetrack_TracksId",
                table: "CompetenceTrack",
                newName: "IX_CompetenceTrack_TracksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetenceTrack",
                table: "CompetenceTrack",
                columns: new[] { "CompetencesId", "TracksId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competences",
                table: "Competences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceTrack_Competences_CompetencesId",
                table: "CompetenceTrack",
                column: "CompetencesId",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceTrack_Tracks_TracksId",
                table: "CompetenceTrack",
                column: "TracksId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Tracks_TrackId",
                table: "Enrollments",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_UserId",
                table: "Enrollments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
