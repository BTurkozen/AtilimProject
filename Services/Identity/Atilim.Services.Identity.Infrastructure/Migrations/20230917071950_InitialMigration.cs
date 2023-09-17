using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Atilim.Services.Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curriculums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LessonName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TCIdentificationNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CityOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactInformationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentIdentities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumLesson",
                columns: table => new
                {
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumLesson", x => new { x.CurriculumId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_CurriculumLesson_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumLesson_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudentIdentityId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInformations_StudentIdentities_StudentIdentityId",
                        column: x => x.StudentIdentityId,
                        principalTable: "StudentIdentities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNo = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    StudentIdentityId = table.Column<int>(type: "int", nullable: false),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_StudentIdentities_StudentIdentityId",
                        column: x => x.StudentIdentityId,
                        principalTable: "StudentIdentities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "9eb3c90e-586b-44bb-bbd4-868d6b2a7970", "admin", "ADMIN" },
                    { 2, "9f0a4374-7754-41ee-b75e-2a6bad22031c", "student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "60f012c1-5d17-4f1a-810a-7274f1831de5", "admin@atilimProject.com", false, false, null, "atilim", null, null, null, null, false, "fcf1fc58-e56d-4143-876a-42d88e4405d5", "admin", false, "atilim.admin" },
                    { 2, 0, "437a89f1-84b6-47ef-be87-b587078ebe02", "hasan.ersoy@atilimProject.com", false, false, null, "hasan", null, null, null, null, false, "d22af253-b1a6-4153-bf46-99f3b060715d", "ersoy", false, "hasan.ersoy" },
                    { 3, 0, "e5a64900-4807-4808-906f-5475f9b1746a", "mehmet.yilmaz@atilimProject.com", false, false, null, "mehmet", null, null, null, null, false, "231aeb93-e89c-4e14-bfc8-d5018382723b", "yilmaz", false, "mehmet.yilmaz" },
                    { 4, 0, "321322b4-60d4-4f75-87ee-f9e850a5f372", "ahmet.unal@atilimProject.com", false, false, null, "ahmet", null, null, null, null, false, "26f55d41-aeee-4cb7-9ea0-ef594c57fca1", "unal", false, "ahmet.unal" },
                    { 5, 0, "79578d10-3c94-4258-b7d9-02a9c4482b91", "mustafa.isik@atilimProject.com", false, false, null, "mustafa", null, null, null, null, false, "37742e3d-ba98-44b9-81e6-8d304b4d1d19", "isik", false, "mustafa.isik" },
                    { 6, 0, "40285e1b-4daa-47e6-b25f-746647d84209", "ayse.erdogan@atilimProject.com", false, false, null, "ayse", null, null, null, null, false, "0ddd68b4-04c9-423c-b6a3-2fc018e09a89", "erdogan", false, "ayse.erdogan" },
                    { 7, 0, "eef51d94-0750-4a30-8287-68ecdfaeb041", "fatma.korkmaz@atilimProject.com", false, false, null, "fatma", null, null, null, null, false, "6de80e5f-17e8-492a-b9fd-c02702ea8d0a", "korkmaz", false, "fatma.korkmaz" }
                });

            migrationBuilder.InsertData(
                table: "Curriculums",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CurriculumName", "IsDeleted", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 17, 10, 19, 50, 659, DateTimeKind.Local).AddTicks(8825), "Bilgisayar_Mühendisliği", false, null, null },
                    { 2, 1, new DateTime(2023, 9, 17, 10, 19, 50, 659, DateTimeKind.Local).AddTicks(8832), "Grafik_Mühendisliği", false, null, null },
                    { 3, 1, new DateTime(2023, 9, 17, 10, 19, 50, 659, DateTimeKind.Local).AddTicks(8833), "Ingiliz_Dil_Edebiyatı", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Credit", "IsDeleted", "LessonCode", "LessonName", "Status", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 17, 10, 19, 50, 660, DateTimeKind.Local).AddTicks(7144), 5, false, "HUM101", "Türk Demokrasi Tarihi", true, null, null },
                    { 2, 1, new DateTime(2023, 9, 17, 10, 19, 50, 660, DateTimeKind.Local).AddTicks(7153), 6, false, "MATH102", "Calculus 2", true, null, null },
                    { 3, 1, new DateTime(2023, 9, 17, 10, 19, 50, 660, DateTimeKind.Local).AddTicks(7155), 6, false, "MATE103", "Metalurjiye Giriş", false, null, null },
                    { 4, 1, new DateTime(2023, 9, 17, 10, 19, 50, 660, DateTimeKind.Local).AddTicks(7157), 5, false, "GRA105", "Grafik Dizayn", true, null, null },
                    { 5, 1, new DateTime(2023, 9, 17, 10, 19, 50, 660, DateTimeKind.Local).AddTicks(7158), 4, false, "CMPE201", "Bilgisayar Teknolojileri", true, null, null },
                    { 6, 1, new DateTime(2023, 9, 17, 10, 19, 50, 660, DateTimeKind.Local).AddTicks(7160), 4, false, "ENG102", "İngilizce 2", true, null, null },
                    { 7, 1, new DateTime(2023, 9, 17, 10, 19, 50, 660, DateTimeKind.Local).AddTicks(7161), 6, false, "MATH201", "İleri Calculus ", true, null, null }
                });

            migrationBuilder.InsertData(
                table: "StudentIdentities",
                columns: new[] { "Id", "CityOfBirth", "ContactInformationId", "CreatedBy", "CreatedOn", "DateOfBirth", "IsDeleted", "Name", "StudentId", "Surname", "TCIdentificationNo", "UpdatedBy", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { 1, "Kayseri", 0, 1, new DateTime(2023, 9, 17, 10, 19, 50, 663, DateTimeKind.Local).AddTicks(7089), new DateTime(1983, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Hasan", 1, "Ersoy", "45456747611", null, null, 2 },
                    { 2, "Adana", 0, 1, new DateTime(2023, 9, 17, 10, 19, 50, 663, DateTimeKind.Local).AddTicks(7176), new DateTime(2000, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mehmet", 2, "Yılmaz", "67967856634", null, null, 3 },
                    { 3, "Ankara", 0, 1, new DateTime(2023, 9, 17, 10, 19, 50, 663, DateTimeKind.Local).AddTicks(7183), new DateTime(2001, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ahmet", 3, "Ünal", "72347322958", null, null, 4 },
                    { 4, "Sivas", 0, 1, new DateTime(2023, 9, 17, 10, 19, 50, 663, DateTimeKind.Local).AddTicks(7190), new DateTime(2000, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mustafa", 4, "Işık", "97850348520", null, null, 5 },
                    { 5, "Uşak", 0, 1, new DateTime(2023, 9, 17, 10, 19, 50, 663, DateTimeKind.Local).AddTicks(7197), new DateTime(2001, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Ayşe", 5, "Erdoğan", "32756874239", null, null, 6 },
                    { 6, "Kütahya", 0, 1, new DateTime(2023, 9, 17, 10, 19, 50, 663, DateTimeKind.Local).AddTicks(7202), new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Fatma", 6, "Korkmaz", "98423479320", null, null, 7 }
                });

            migrationBuilder.InsertData(
                table: "ContactInformations",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedBy", "CreatedOn", "District", "Email", "IsDeleted", "MobilePhoneNumber", "StudentIdentityId", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "DEMİRCİKARA MAH. B.ONAT CAD. HEDE SİT. B BLOK NO : 1", "ANKARA", "Türkiye", 1, new DateTime(2023, 9, 17, 10, 19, 50, 659, DateTimeKind.Local).AddTicks(3799), "PURSAKLAR", "mno@xyz.com", false, "5555424245", 1, null, null },
                    { 2, "CUMHURİYET MAH. BİRİNCİ SOK. İKİNCİ APT. NO:111/6", "Ankara", "Türkiye", 1, new DateTime(2023, 9, 17, 10, 19, 50, 659, DateTimeKind.Local).AddTicks(3825), "YENİMAHALLE", "abc@hotmail.com", false, "5332342342", 2, null, null },
                    { 3, "SİTELER MAHALLESİ 6223 SOKAK DURU APT. NO:11 KAT:3 ", "Ankara", "Türkiye", 1, new DateTime(2023, 9, 17, 10, 19, 50, 659, DateTimeKind.Local).AddTicks(3828), "POLATLI", "klm@outlook.com", false, "5408932042", 3, null, null },
                    { 4, "TURAN GÜNEŞ BULVARI TAMTAM SİTESİ 13. CAD. NO:51", "Ankara", "Türkiye", 0, new DateTime(2023, 9, 17, 10, 19, 50, 659, DateTimeKind.Local).AddTicks(3830), "KEÇİÖREN", "ghi@abc.com", false, "5305464646", 4, null, null },
                    { 5, "AHMET HAMDİ SOK. NO:19/15", "Ankara", "Türkiye", 1, new DateTime(2023, 9, 17, 10, 19, 50, 659, DateTimeKind.Local).AddTicks(3832), "SİNCAN", "prs@hotmail.com", false, "5302908432", 5, null, null },
                    { 6, "KUŞADASI SOK. NO:123 KARAAĞAÇ", "Ankara", "Türkiye", 1, new DateTime(2023, 9, 17, 10, 19, 50, 659, DateTimeKind.Local).AddTicks(3834), "ÇANKAYA", "def@gmail.com", false, "5437657567", 6, null, null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CurriculumId", "IsDeleted", "StudentIdentityId", "StudentNo", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 17, 10, 19, 50, 661, DateTimeKind.Local).AddTicks(6265), 1, false, 1, 23462368, null, null },
                    { 2, 1, new DateTime(2023, 9, 17, 10, 19, 50, 661, DateTimeKind.Local).AddTicks(6274), 1, false, 2, 27482379, null, null },
                    { 3, 1, new DateTime(2023, 9, 17, 10, 19, 50, 661, DateTimeKind.Local).AddTicks(6276), 2, false, 3, 34565479, null, null },
                    { 4, 1, new DateTime(2023, 9, 17, 10, 19, 50, 661, DateTimeKind.Local).AddTicks(6277), 2, false, 4, 53456346, null, null },
                    { 5, 1, new DateTime(2023, 9, 17, 10, 19, 50, 661, DateTimeKind.Local).AddTicks(6279), 3, false, 5, 34674575, null, null },
                    { 6, 1, new DateTime(2023, 9, 17, 10, 19, 50, 661, DateTimeKind.Local).AddTicks(6280), 3, false, 6, 64672359, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformations_Email",
                table: "ContactInformations",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformations_Id",
                table: "ContactInformations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformations_StudentIdentityId",
                table: "ContactInformations",
                column: "StudentIdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumLesson_LessonId",
                table: "CurriculumLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "CurriculumName",
                table: "Curriculums",
                column: "CurriculumName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_Id",
                table: "Curriculums",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Id",
                table: "Lessons",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonCode",
                table: "Lessons",
                column: "LessonCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentities_Id",
                table: "StudentIdentities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentities_Name_Surname",
                table: "StudentIdentities",
                columns: new[] { "Name", "Surname" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentities_TCIdentificationNo",
                table: "StudentIdentities",
                column: "TCIdentificationNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdentities_UserId",
                table: "StudentIdentities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CurriculumId",
                table: "Students",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Id",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentIdentityId",
                table: "Students",
                column: "StudentIdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentNo",
                table: "Students",
                column: "StudentNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContactInformations");

            migrationBuilder.DropTable(
                name: "CurriculumLesson");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Curriculums");

            migrationBuilder.DropTable(
                name: "StudentIdentities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
