using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atilim.Services.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StudentEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curriculum",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurriculumName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LessonCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LessonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentIdentity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TCIdentificationNo = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CityOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactInformationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentIdentity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumLesson",
                columns: table => new
                {
                    CurriculumsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LessonsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumLesson", x => new { x.CurriculumsId, x.LessonsId });
                    table.ForeignKey(
                        name: "FK_CurriculumLesson_Curriculum_CurriculumsId",
                        column: x => x.CurriculumsId,
                        principalTable: "Curriculum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumLesson_Lesson_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactImformation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudentIdentityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactImformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactImformation_StudentIdentity_StudentIdentityId",
                        column: x => x.StudentIdentityId,
                        principalTable: "StudentIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentNo = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    StudentIdentityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurriculumId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_StudentIdentity_StudentIdentityId",
                        column: x => x.StudentIdentityId,
                        principalTable: "StudentIdentity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactImformation_Email",
                table: "ContactImformation",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactImformation_Id",
                table: "ContactImformation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContactImformation_StudentIdentityId",
                table: "ContactImformation",
                column: "StudentIdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CurriculumName",
                table: "Curriculum",
                column: "CurriculumName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Id",
                table: "Curriculum",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumLesson_LessonsId",
                table: "CurriculumLesson",
                column: "LessonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_Id",
                table: "Lesson",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_LessonCode",
                table: "Lesson",
                column: "LessonCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CurriculumId",
                table: "Student",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Id",
                table: "Student",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentIdentityId",
                table: "Student",
                column: "StudentIdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentNo",
                table: "Student",
                column: "StudentNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentity_Id",
                table: "StudentIdentity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentity_Name_Surname",
                table: "StudentIdentity",
                columns: new[] { "Name", "Surname" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentity_TCIdentificationNo",
                table: "StudentIdentity",
                column: "TCIdentificationNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentity_UserId",
                table: "StudentIdentity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactImformation");

            migrationBuilder.DropTable(
                name: "CurriculumLesson");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Curriculum");

            migrationBuilder.DropTable(
                name: "StudentIdentity");
        }
    }
}
