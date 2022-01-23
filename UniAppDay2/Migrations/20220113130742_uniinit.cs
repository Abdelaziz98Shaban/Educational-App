using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAppDay2.Migrations
{
    public partial class uniinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deptName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mangerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    degree = table.Column<int>(type: "int", nullable: false),
                    minDegree = table.Column<int>(type: "int", nullable: false),
                    deptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.id);
                    table.ForeignKey(
                        name: "FK_Course_Department_deptId",
                        column: x => x.deptId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    traineeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    traineeImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    traineeGrade = table.Column<int>(type: "int", nullable: false),
                    traineeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainee_Department_deptId",
                        column: x => x.deptId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    insName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    insImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    insSalary = table.Column<int>(type: "int", nullable: false),
                    insAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deptId = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_Course_courseId",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instructor_Department_deptId",
                        column: x => x.deptId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CourseResult",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    traineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResult", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseResult_Course_courseId",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseResult_Trainee_traineeId",
                        column: x => x.traineeId,
                        principalTable: "Trainee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_deptId",
                table: "Course",
                column: "deptId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResult_courseId",
                table: "CourseResult",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResult_traineeId",
                table: "CourseResult",
                column: "traineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_courseId",
                table: "Instructor",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_deptId",
                table: "Instructor",
                column: "deptId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_deptId",
                table: "Trainee",
                column: "deptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseResult");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
