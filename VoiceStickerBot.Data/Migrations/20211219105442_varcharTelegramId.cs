using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VoiceStickerBot.Data.Migrations
{
    public partial class varcharTelegramId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AudioFileTags_AudioFileId",
                table: "AudioFileTags");

            migrationBuilder.DropIndex(
                name: "IX_AudioFileTags_TagId",
                table: "AudioFileTags");

            migrationBuilder.AlterColumn<string>(
                name: "TelegramFileId",
                table: "AudioFiles",
                type: "varchar(70)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFileTags_AudioFileId",
                table: "AudioFileTags",
                column: "AudioFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AudioFileTags_TagId",
                table: "AudioFileTags",
                column: "TagId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AudioFileTags_AudioFileId",
                table: "AudioFileTags");

            migrationBuilder.DropIndex(
                name: "IX_AudioFileTags_TagId",
                table: "AudioFileTags");

            migrationBuilder.AlterColumn<Guid>(
                name: "TelegramFileId",
                table: "AudioFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AudioFileTags_AudioFileId",
                table: "AudioFileTags",
                column: "AudioFileId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioFileTags_TagId",
                table: "AudioFileTags",
                column: "TagId");
        }
    }
}
