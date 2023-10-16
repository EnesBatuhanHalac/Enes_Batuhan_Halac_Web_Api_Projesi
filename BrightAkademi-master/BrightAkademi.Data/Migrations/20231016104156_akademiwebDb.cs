using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrightAkademi.Data.Migrations
{
    /// <inheritdoc />
    public partial class akademiwebDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    About = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    EducationalStatus = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Profession = table.Column<string>(type: "TEXT", nullable: true),
                    Experience = table.Column<string>(type: "TEXT", nullable: true),
                    EducationInfo = table.Column<string>(type: "TEXT", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TotalCourseHours = table.Column<string>(type: "TEXT", nullable: true),
                    HowManyMonths = table.Column<string>(type: "TEXT", nullable: true),
                    StartCourseTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FinishCourseTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: true),
                    Experience = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    LevelId = table.Column<int>(type: "INTEGER", nullable: true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseStudents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.CourseId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(645), "Kategorisi silinenleri buraya atacağız", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(648), "Genel", "genel" },
                    { 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(651), "Full Stack Web Developer", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(651), "Full Stack Web Developer", "full-stack-web-developer" },
                    { 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(652), "IOS Developer", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(653), "IOS Developer", "ios-developer" },
                    { 4, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(654), "BackEnd Developer", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(655), "BackEnd Developer", "backend-developer" },
                    { 5, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(656), "FrontEnd Developer", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(656), "FrontEnd Developer", "frontend-developer" },
                    { 6, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(658), "Java Developer", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(658), "Java Developer", "java-developer" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "About", "Address", "CreatedDate", "Email", "IsActive", "IsDeleted", "ModifiedDate", "Name", "PhoneNumber" },
                values: new object[] { 1, "Yazılım eğitimi veren ana kucağı", "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1324), "info.wissenakademie.com", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1327), "Wissen Akademie", "1234567890" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(2541), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(2543), "Easy" },
                    { 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(2545), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(2545), "Medium" },
                    { 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(2546), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(2547), "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(9053), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(9055), "Super Admin" },
                    { 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(9057), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(9057), "Admin" },
                    { 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(9058), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(9059), "Trainer" },
                    { 4, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(9060), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(9061), "Trainee" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Firstname", "IsActive", "IsDeleted", "Lastname", "ModifiedDate", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8398), "EnesBatuhan", true, false, "Admin", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8401), "superadmin", "superadmin" },
                    { 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8403), "ilkercelik", true, false, "Admin", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8404), "admin", "admin" },
                    { 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8405), "Ramiz", true, false, "Karaeski", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8406), "ramizkaraeski", "ramizkaraeski" },
                    { 4, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8407), "Kenan", true, false, "Birkan", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8408), "kenanbirkan", "kenanbirkan" },
                    { 5, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8409), "Ezel", true, false, "Bayraktar", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8410), "ezelbayraktar", "ezelbayraktar" },
                    { 6, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8411), "Mehmet", true, false, "Tezcan", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8412), "mehmettezcan", "mehmettezcan" },
                    { 7, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8413), "Selma", true, false, "Hünel", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8414), "selmahunel", "selmahunel" },
                    { 8, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8416), "Eyşan", true, false, "Atay", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8416), "eysanatay", "eysanatay" },
                    { 9, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8418), "Ali", true, false, "Kırgız", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8418), "alikizgin", "alikizgin" },
                    { 10, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8420), "Teyfik", true, false, "Zaim", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8420), "teyfikzaim", "teyfikzaim" },
                    { 11, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8422), "JeremyRichard", true, false, "Figarland", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8422), "figarlandFamily", "JeremyRichard" },
                    { 12, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8424), "Cengiz", true, false, "Atay", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8424), "cengizatay", "cengizatay" },
                    { 13, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8426), "Samurai", true, false, "Jean", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8426), "jean123Qwer.", "samurai" },
                    { 14, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8428), "Şebnem", true, false, "Sertuna", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8428), "sebnemsertuna", "sebnemsertuna" },
                    { 15, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8430), "Temmuz", true, false, "Kocaoğlu", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8430), "temmuzkocaoglu", "temmuzkocaoglu" },
                    { 16, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8432), "Bahar", true, false, "Tezcan", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8432), "bahartezcan", "bahartezcan" },
                    { 17, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8434), "Azad", true, false, "Karaeski", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(8434), "azadkaraeski", "azadkaraeski" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "EducationalStatus", "IsActive", "IsDeleted", "ModifiedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7751), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7755), 8 },
                    { 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7757), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7757), 9 },
                    { 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7759), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7759), 10 },
                    { 4, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7761), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7761), 11 },
                    { 5, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7762), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7763), 12 },
                    { 6, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7764), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7765), 13 },
                    { 7, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7766), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7766), 14 },
                    { 8, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7768), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7768), 15 },
                    { 9, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7769), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7770), 16 },
                    { 10, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7771), "Kayıtlı öğrenci başlayacak.", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(7772), 17 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Comment", "CreatedDate", "EducationInfo", "Experience", "IsActive", "IsDeleted", "ModifiedDate", "Profession", "UserId" },
                values: new object[,]
                {
                    { 1, "10 puan", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1955), "Zonguldak Bilgisayar Öğretmenliği", "30", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1958), "Full Stack Web Developer", 3 },
                    { 2, "10 puan", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1960), "Eskişehir Bilgisayar Mühendisliği", "10", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1961), "IOS Developer", 4 },
                    { 3, "10 puan", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1963), "Bahçeşehir Üniversitesi Yazılım Mühendisliği", "2", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1963), "Backend Developer", 5 },
                    { 4, "10 puan", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1965), "Arel Üniversitesi Elektronik Haberleşme Mühendisliği", "2", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1965), "Frontend Developer", 6 },
                    { 5, "10 puan", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1967), "Doğuş Üniversitesi", "2", true, false, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(1968), "Java Developer", 7 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "RoleId", "TeacherId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9196), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9212), 1, null, 1 },
                    { 2, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9213), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9214), 2, null, 2 },
                    { 3, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9215), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9216), 3, null, 3 },
                    { 4, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9217), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9217), 3, null, 4 },
                    { 5, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9219), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9219), 3, null, 5 },
                    { 6, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9221), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9221), 3, null, 6 },
                    { 7, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9222), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9223), 3, null, 7 },
                    { 8, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9224), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9225), 4, null, 8 },
                    { 9, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9226), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9226), 4, null, 9 },
                    { 10, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9228), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9228), 4, null, 10 },
                    { 11, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9229), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9230), 4, null, 11 },
                    { 12, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9231), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9232), 4, null, 12 },
                    { 13, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9233), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9233), 4, null, 13 },
                    { 14, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9235), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9241), 4, null, 14 },
                    { 15, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9242), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9250), 4, null, 15 },
                    { 16, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9267), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9268), 4, null, 16 },
                    { 17, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9270), true, false, new DateTime(2023, 10, 16, 13, 41, 56, 715, DateTimeKind.Local).AddTicks(9271), 4, null, 17 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Address", "CategoryId", "Comment", "CompanyId", "Content", "CreatedDate", "Description", "Experience", "FinishCourseTime", "HowManyMonths", "IsActive", "IsDeleted", "LevelId", "ModifiedDate", "Name", "Price", "StartCourseTime", "Status", "TeacherId", "TotalCourseHours" },
                values: new object[,]
                {
                    { 1, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 2, "Çok iyi bir kurs 10 puan", 1, "html css bootstrap react react native c# .net javascript node.js ajax", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3153), "Full Stack Developer eğitimi kapsamlı bir eğitim.", "Bu eğitim sayesinde;Temel ve ileri veritabanı mantığını, Web’in ve yazılımın çalışma prensibini ve tüm süreçlerini, Yeni nesil tüm programlama araç ve dillerini, Back end programlamayı ve API yazmayı, Uçtan uca bir proje geliştirmeyi öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", false, false, 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3159), "Full Stack Web Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 1, "200" },
                    { 2, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 2, "Çok iyi bir kurs 10 puan", 1, "html css bootstrap react react native c# .net javascript node.js ajax", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3176), "Full Stack Developer eğitimi kapsamlı bir eğitim.", "Bu eğitim sayesinde;Temel ve ileri veritabanı mantığını, Web’in ve yazılımın çalışma prensibini ve tüm süreçlerini, Yeni nesil tüm programlama araç ve dillerini, Back end programlamayı ve API yazmayı, Uçtan uca bir proje geliştirmeyi öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4", false, false, 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3176), "Full Stack Web Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 1, "400" },
                    { 3, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 2, "Çok iyi bir kurs 10 puan", 1, "html css bootstrap react react native c# .net javascript node.js ajax", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3181), "Full Stack Developer eğitimi kapsamlı bir eğitim.", "Bu eğitim sayesinde;Temel ve ileri veritabanı mantığını, Web’in ve yazılımın çalışma prensibini ve tüm süreçlerini, Yeni nesil tüm programlama araç ve dillerini, Back end programlamayı ve API yazmayı, Uçtan uca bir proje geliştirmeyi öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6", false, false, 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3181), "Full Stack Web Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 1, "600" },
                    { 4, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 3, "Çok iyi bir kurs 10 puan", 1, "Swift", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3186), "IOS Developer", "Bu eğitimde IOS Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak swift programını öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", false, false, 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3186), "IOS Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 2, "100" },
                    { 5, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 3, "Çok iyi bir kurs 10 puan", 1, "Swift", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3191), "IOS Developer", "Bu eğitimde IOS Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak swift programını öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", false, false, 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3191), "IOS Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 2, "200" },
                    { 6, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 3, "Çok iyi bir kurs 10 puan", 1, "Swift", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3195), "IOS Developer", "Bu eğitimde IOS Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak swift programını öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3", false, false, 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3196), "IOS Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 2, "300" },
                    { 7, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 4, "Çok iyi bir kurs 10 puan", 1, "c# .net javascript node.js ajax ", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3200), "Backend Developer", "Bu eğitimde Backend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", false, false, 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3200), "Backend Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 3, "100" },
                    { 8, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 4, "Çok iyi bir kurs 10 puan", 1, "c# .net javascript node.js ajax ", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3205), "Backend Developer", "Bu eğitimde Backend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", false, false, 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3205), "Backend Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 3, "200" },
                    { 9, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 4, "Çok iyi bir kurs 10 puan", 1, "c# .net javascript node.js ajax ", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3209), "Backend Developer", "Bu eğitimde Backend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3", false, false, 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3210), "Backend Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 3, "300" },
                    { 10, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 5, "Çok iyi bir kurs 10 puan", 1, "html css bootstrap javascript react react native", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3214), "Frontend Developer", "Bu eğitimde Frontend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", false, false, 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3214), "Frontend Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 4, "100" },
                    { 11, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 5, "Çok iyi bir kurs 10 puan", 1, "html css bootstrap javascript react react native", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3218), "Frontend Developer", "Bu eğitimde Frontend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", false, false, 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3219), "Frontend Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 4, "200" },
                    { 12, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 5, "Çok iyi bir kurs 10 puan", 1, "html css bootstrap javascript react react native", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3265), "Frontend Developer", "Bu eğitimde Frontend Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3", false, false, 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3266), "Frontend Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 4, "300" },
                    { 13, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 6, "Çok iyi bir kurs 10 puan", 1, "Java", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3271), "Frontend Developer", "Bu eğitimde Java Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", false, false, 1, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3271), "Java Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 5, "100" },
                    { 14, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 6, "Çok iyi bir kurs 10 puan", 1, "Java", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3275), "Frontend Developer", "Bu eğitimde Java Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", false, false, 2, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3276), "Java Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 5, "200" },
                    { 15, "Kuloğlu Mh., Barbaros Blv. Yıldız İş Hanı No:9, 34353 Beşiktaş/İstanbul", 6, "Çok iyi bir kurs 10 puan", 1, "Java", new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3280), "Frontend Developer", "Bu eğitimde Java Developer olmak adına seçeceğiniz eğitim seviyesine göre eğitim alacak gerekli programları öğreneceksiniz.", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3", false, false, 3, new DateTime(2023, 10, 16, 13, 41, 56, 716, DateTimeKind.Local).AddTicks(3280), "Java Developer", 10000, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Açılacak", 5, "300" }
                });

            migrationBuilder.InsertData(
                table: "CourseStudents",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 5, 10 },
                    { 6, 1 },
                    { 6, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 8, 5 },
                    { 8, 6 },
                    { 9, 7 },
                    { 9, 8 },
                    { 10, 9 },
                    { 10, 10 },
                    { 11, 1 },
                    { 11, 2 },
                    { 12, 3 },
                    { 12, 4 },
                    { 13, 5 },
                    { 13, 6 },
                    { 14, 7 },
                    { 14, 8 },
                    { 15, 9 },
                    { 15, 10 }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourses",
                columns: new[] { "CourseId", "TeacherId", "CreatedDate", "Id", "IsActive", "IsDeleted", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2035), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2039) },
                    { 2, 1, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2040), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2041) },
                    { 3, 1, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2042), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2042) },
                    { 4, 2, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2043), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2043) },
                    { 5, 2, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2044), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2045) },
                    { 6, 2, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2046), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2046) },
                    { 7, 3, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2047), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2048) },
                    { 8, 3, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2049), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2049) },
                    { 9, 3, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2050), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2051) },
                    { 10, 4, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2052), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2052) },
                    { 11, 4, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2053), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2054) },
                    { 12, 4, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2055), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2055) },
                    { 13, 5, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2056), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2057) },
                    { 14, 5, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2057), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2058) },
                    { 15, 5, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2059), 0, true, false, new DateTime(2023, 10, 16, 13, 41, 56, 717, DateTimeKind.Local).AddTicks(2059) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CompanyId",
                table: "Courses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LevelId",
                table: "Courses",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentId",
                table: "CourseStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_TeacherId",
                table: "UserRoles",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
