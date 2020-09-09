using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WPF.Start.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Dni = table.Column<string>(nullable: true),
                    Student_Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LastName2 = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    Chair = table.Column<int>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: true),
                    ExamId = table.Column<Guid>(nullable: true),
                    Grade = table.Column<double>(nullable: true),
                    StudentSubject_StudentId = table.Column<Guid>(nullable: true),
                    StudentSubject_SubjectId = table.Column<Guid>(nullable: true),
                    Subject_Name = table.Column<string>(nullable: true),
                    Season = table.Column<string>(nullable: true),
                    Credits = table.Column<int>(nullable: true),
                    NumberStudents = table.Column<int>(nullable: true),
                    TeacherId = table.Column<Guid>(nullable: true),
                    Teacher_Name = table.Column<string>(nullable: true),
                    LastName1 = table.Column<string>(nullable: true),
                    Teacher_LastName2 = table.Column<string>(nullable: true),
                    MaxCredits = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_SubjectId",
                table: "Entity",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_StudentId",
                table: "Entity",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_TeacherId",
                table: "Entity",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
