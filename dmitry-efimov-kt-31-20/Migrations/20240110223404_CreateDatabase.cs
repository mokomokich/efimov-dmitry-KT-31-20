using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dmitryefimovkt3120.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ct_ratings",
                columns: table => new
                {
                    ratingsid = table.Column<int>(name: "ratings_id", type: "int", nullable: false, comment: "Идентификатор экзамена")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cratingsratingsname = table.Column<string>(name: "c_ratings_ratingsname", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название предмета по которому экзамен"),
                    cratingsratingsgrade = table.Column<int>(name: "c_ratings_ratingsgrade", type: "int4", maxLength: 100, nullable: false, comment: "Оценка за экзамен")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ct_ratings_ratings_id", x => x.ratingsid);
                });

            migrationBuilder.CreateTable(
                name: "ct_test",
                columns: table => new
                {
                    testid = table.Column<int>(name: "test_id", type: "int", nullable: false, comment: "Идентификатор зачета")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ctesttestname = table.Column<string>(name: "c_test_testname", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название предмета по которому зачет"),
                    ctestisthetest = table.Column<int>(name: "c_test_isthetest", type: "int4", maxLength: 100, nullable: false, comment: "Есть зачет или нет")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ct_test_test_id", x => x.testid);
                });

            migrationBuilder.CreateTable(
                name: "ct_student",
                columns: table => new
                {
                    studentid = table.Column<int>(name: "student_id", type: "int", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cstudentfirstname = table.Column<string>(name: "c_student_firstname", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя студента"),
                    cstudentlastname = table.Column<string>(name: "c_student_lastname", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    cstudentmiddlename = table.Column<string>(name: "c_student_middlename", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    cstudentratingsid = table.Column<int>(name: "c_student_ratings_id", type: "int4", nullable: false, comment: "Оценка"),
                    cstudenttestid = table.Column<bool>(name: "c_student_test_id", type: "int4", nullable: false, comment: "Зачет")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ct_student_student_id", x => x.studentid);
                    table.ForeignKey(
                        name: "fk_f_ratings_id",
                        column: x => x.cstudentratingsid,
                        principalTable: "ct_ratings",
                        principalColumn: "ratings_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_test_id",
                        column: x => x.cstudentratingsid,
                        principalTable: "ct_test",
                        principalColumn: "test_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_ct_student_fk_f_test_id",
                table: "ct_student",
                column: "c_student_test_id");

            migrationBuilder.CreateIndex(
                name: "idx_ct_studentfk_f_ratings_id",
                table: "ct_student",
                column: "c_student_ratings_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ct_student");

            migrationBuilder.DropTable(
                name: "ct_ratings");

            migrationBuilder.DropTable(
                name: "ct_test");
        }
    }
}
