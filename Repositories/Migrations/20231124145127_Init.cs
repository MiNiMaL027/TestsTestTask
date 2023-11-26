using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArchivateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredCorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    ArchivateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Description", "RequiredCorrectAnswers", "ArchivateDate", "CreationDate", "Name", "UserId" },
                values: new object[] { "Choose right answer", 2, null, DateTime.Now, "Test1", null });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Description", "RequiredCorrectAnswers", "ArchivateDate", "CreationDate", "Name", "UserId" },
                values: new object[] { "Choose right answer", 1, null, DateTime.Now, "Test2", null });


            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    ArchivateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "TestId", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, null, DateTime.Now, "Question 1" });
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "TestId", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, null, DateTime.Now, "Question 2" });
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "TestId", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, null, DateTime.Now, "Question 3" });
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "TestId", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, null, DateTime.Now, "Question 1" });
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "TestId", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, null, DateTime.Now, "Question 2" });
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "TestId", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, null, DateTime.Now, "Question 3" });

            migrationBuilder.CreateTable(
                name: "UserTestResults",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestResults", x => new { x.UserId, x.TestId });
                    table.ForeignKey(
                        name: "FK_UserTestResults_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTestResults_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    isCorrect = table.Column<bool>(type: "bit", nullable: false),
                    ArchivateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, 1, false, null, DateTime.Now, "Answer 1" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, 1, true, null, DateTime.Now, "Answer 2(correct)" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, 1, false, null, DateTime.Now, "Answer 3" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, 2, false, null, DateTime.Now, "Answer 1" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, 2, true, null, DateTime.Now, "Answer 2(correct)" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, 2, false, null, DateTime.Now, "Answer 3" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, 3, true, null, DateTime.Now, "Answer 1(correct)" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, 3, false, null, DateTime.Now, "Answer 2" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 1, 3, false, null, DateTime.Now, "Answer 3" });


            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, 4, false, null, DateTime.Now, "Answer 1" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, 4, true, null, DateTime.Now, "Answer 2(correct)" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, 4, false, null, DateTime.Now, "Answer 3" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, 5, false, null, DateTime.Now, "Answer 1" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, 5, true, null, DateTime.Now, "Answer 2(correct)" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, 5, false, null, DateTime.Now, "Answer 3" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, 6, true, null, DateTime.Now, "Answer 1(correct)" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, 6, false, null, DateTime.Now, "Answer 2" });
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "TestId", "QuestionId", "isCorrect", "ArchivateDate", "CreationDate", "Name" },
                values: new object[] { 2, 6, false, null, DateTime.Now, "Answer 3" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TestId",
                table: "Answers",
                column: "TestId");

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
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResults_TestId",
                table: "UserTestResults",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

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
                name: "UserTestResults");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
