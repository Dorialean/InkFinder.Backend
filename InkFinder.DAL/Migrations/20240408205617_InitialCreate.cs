using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InkFinder.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TatooService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatooService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    SurName = table.Column<string>(type: "text", nullable: true),
                    FatherName = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    GenericSalt = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtworkEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtworkEntity_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TatooSignUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParticipantId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatooSignUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TatooSignUp_TatooService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "TatooService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TatooSignUp_User_MasterId",
                        column: x => x.MasterId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TatooSignUp_User_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserToRole_RoleEntity_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSheet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSheet_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RoleEntity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("544384bd-9e78-43ff-9e7b-514cb553b6d9"), "ADMIN" },
                    { new Guid("64a84203-88bb-46b4-a57c-36d673686343"), "MASTER" },
                    { new Guid("b8cb9bf8-d585-43f1-be49-884005af78a8"), "PARTICIPANT" }
                });

            migrationBuilder.InsertData(
                table: "TatooService",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "создание уникального рисунка с учетом пожеланий клиента и его индивидуальных особенностей", "Индивидуальный дизайн татуировки" },
                    { 2, "помощь в определении подходящего дизайна, который отразит вашу личность и стиль", "Консультация по выбору мотива и стиля" },
                    { 3, "проработка и улучшение вашей идеи татуировки в сотрудничестве с мастером", "Работа с клиентскими эскизами" },
                    { 4, "возможность создания татуировки на любой выбранной вами области кожи", "Татуировки на любых частях тела" },
                    { 5, "возможность исправления и улучшения существующих татуировок", "Коррекция и доработка старых тату" },
                    { 6, "профессиональное удаление татуировок без следов и рубцов", "Удаление нежелательных татуировок" },
                    { 7, "выбор временных вариантов татуировок для тех, кто хочет испытать новый образ временно", "Временные татуировки и хной" },
                    { 8, "рекомендации и средства для максимально комфортного заживления кожи после татуировки", "Уход и реабилитация после процедуры" },
                    { 9, "обучение и повышение квалификации в сфере татуировки по индивидуальной программе", "Услуги мастерства и обучения" },
                    { 10, "участие в мероприятиях и выставках, где вы сможете увидеть работы талантливых мастеров и получить новые впечатления", "Проведение тематических мероприятий и выставок" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkEntity_CreatorId",
                table: "ArtworkEntity",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkEntity_Name",
                table: "ArtworkEntity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntity_Name",
                table: "RoleEntity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TatooService_Name",
                table: "TatooService",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TatooSignUp_MasterId",
                table: "TatooSignUp",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_TatooSignUp_ParticipantId",
                table: "TatooSignUp",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_TatooSignUp_ServiceId",
                table: "TatooSignUp",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRole_RoleId",
                table: "UserToRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSheet_UserId",
                table: "WorkSheet",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtworkEntity");

            migrationBuilder.DropTable(
                name: "TatooSignUp");

            migrationBuilder.DropTable(
                name: "UserToRole");

            migrationBuilder.DropTable(
                name: "WorkSheet");

            migrationBuilder.DropTable(
                name: "TatooService");

            migrationBuilder.DropTable(
                name: "RoleEntity");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
