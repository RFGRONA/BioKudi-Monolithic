using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioKudi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACTIVITY",
                columns: table => new
                {
                    id_activity = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the activity (integer).")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false, comment: "Type of activity (character string, maximum 128).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ACTIVITY__BBF4A24791BDEC3C", x => x.id_activity);
                });

            migrationBuilder.CreateTable(
                name: "AUDIT",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    view_action = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    action = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AUDIT__3213E83F45F049A7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PICTURE",
                columns: table => new
                {
                    id_picture = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the picture (integer).")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false, comment: "Name of the picture (character string, maximum 128)."),
                    link = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, comment: "Link of the picture (character string, maximum 255).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PICTURE__E967C4E5B8BC69DF", x => x.id_picture);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the role (integer).")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Name of the role (character string, maximum 50).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROLE__3D48441DA7587008", x => x.id_role);
                });

            migrationBuilder.CreateTable(
                name: "STATE",
                columns: table => new
                {
                    id_state = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the state (integer).")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_state = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true, comment: "Name of the state (character string, maximum 30).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__STATE__12FD6C4991F75C26", x => x.id_state);
                });

            migrationBuilder.CreateTable(
                name: "PLACE",
                columns: table => new
                {
                    id_place = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the place (integer).")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_place = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false, comment: "Name of the place (character string, maximum 80)."),
                    latitude = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Latitude of the place (character string, maximum 20 digits)."),
                    longitude = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, comment: "Longitude of the place (character string, maximum 20 digits)."),
                    address = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true, comment: "Address of the place (character string, maximum 128)."),
                    description = table.Column<string>(type: "varchar(560)", unicode: false, maxLength: 560, nullable: false, comment: "Description of the place (character string, maximum 560)."),
                    link = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, comment: "Link related to the place (character string, maximum 255)."),
                    state_id = table.Column<int>(type: "int", nullable: true, comment: "ID of the state to which the place belongs (integer).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PLACE__04D478F42E9BE1F1", x => x.id_place);
                    table.ForeignKey(
                        name: "FK__PLACE__state_id__5535A963",
                        column: x => x.state_id,
                        principalTable: "STATE",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the user (integer).")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_user = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false, comment: "Name of the user (character string, maximum 65)."),
                    email = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: false, comment: "Email address of the user (character string, maximum 75)."),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, comment: "Password of the user (character string, maximum 128)."),
                    role_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the user's role (integer)."),
                    state_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the user's state (integer)."),
                    key = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    salt = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USER__D2D1463726DE95DA", x => x.id_user);
                    table.ForeignKey(
                        name: "FK__USER__role_id__5070F446",
                        column: x => x.role_id,
                        principalTable: "ROLE",
                        principalColumn: "id_role");
                    table.ForeignKey(
                        name: "FK__USER__state_id__5629CD9C",
                        column: x => x.state_id,
                        principalTable: "STATE",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateTable(
                name: "ACTIVITY_PLACE",
                columns: table => new
                {
                    place_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the place associated with the activity (integer)."),
                    activity_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the activity associated with the place (integer).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ACTIVITY__9BA9939C1918C499", x => new { x.place_id, x.activity_id });
                    table.ForeignKey(
                        name: "FK__ACTIVITY___activ__4F7CD00D",
                        column: x => x.activity_id,
                        principalTable: "ACTIVITY",
                        principalColumn: "id_activity");
                    table.ForeignKey(
                        name: "FK__ACTIVITY___place__4E88ABD4",
                        column: x => x.place_id,
                        principalTable: "PLACE",
                        principalColumn: "id_place");
                });

            migrationBuilder.CreateTable(
                name: "PICTURE_PLACE",
                columns: table => new
                {
                    place_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the place associated with the picture (integer)."),
                    picture_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the picture associated with the place (integer).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PICTURE___64F9E9DAEA8FA6DB", x => new { x.place_id, x.picture_id });
                    table.ForeignKey(
                        name: "FK__PICTURE_P__pictu__4D94879B",
                        column: x => x.picture_id,
                        principalTable: "PICTURE",
                        principalColumn: "id_picture");
                    table.ForeignKey(
                        name: "FK__PICTURE_P__place__4CA06362",
                        column: x => x.place_id,
                        principalTable: "PLACE",
                        principalColumn: "id_place");
                });

            migrationBuilder.CreateTable(
                name: "REVIEW",
                columns: table => new
                {
                    id_review = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the review (integer).")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rate = table.Column<float>(type: "real", nullable: false, comment: "Rating of the review (float, precision of 2 digits)."),
                    comment = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "Comment of the review (character string, maximum 255)."),
                    user_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the user who made the review (integer).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__REVIEW__2F79F8C79EE9DCBF", x => x.id_review);
                    table.ForeignKey(
                        name: "FK__REVIEW__user_id__5165187F",
                        column: x => x.user_id,
                        principalTable: "USER",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "TICKET",
                columns: table => new
                {
                    id_ticket = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of the ticket (integer).")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "Type of ticket (character string, maximum 50)."),
                    affair = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false, comment: "Subject of the ticket (character string, maximum 1024)."),
                    user_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the user associated with the ticket (integer)."),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TICKET__48C6F52308C4296A", x => x.id_ticket);
                    table.ForeignKey(
                        name: "FK_TICKET_STATE",
                        column: x => x.state,
                        principalTable: "STATE",
                        principalColumn: "id_state");
                    table.ForeignKey(
                        name: "FK__TICKET__user_id__52593CB8",
                        column: x => x.user_id,
                        principalTable: "USER",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "REVIEW_PLACE",
                columns: table => new
                {
                    place_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the place associated with the review (integer)."),
                    review_id = table.Column<int>(type: "int", nullable: false, comment: "ID of the review associated with the place (integer).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__REVIEW_P__A923EB93308825A1", x => new { x.place_id, x.review_id });
                    table.ForeignKey(
                        name: "FK__REVIEW_PL__place__534D60F1",
                        column: x => x.place_id,
                        principalTable: "PLACE",
                        principalColumn: "id_place");
                    table.ForeignKey(
                        name: "FK__REVIEW_PL__revie__5441852A",
                        column: x => x.review_id,
                        principalTable: "REVIEW",
                        principalColumn: "id_review");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACTIVITY_PLACE_activity_id",
                table: "ACTIVITY_PLACE",
                column: "activity_id");

            migrationBuilder.CreateIndex(
                name: "IX_PICTURE_PLACE_picture_id",
                table: "PICTURE_PLACE",
                column: "picture_id");

            migrationBuilder.CreateIndex(
                name: "IX_PLACE_state_id",
                table: "PLACE",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_REVIEW_user_id",
                table: "REVIEW",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_REVIEW_PLACE_review_id",
                table: "REVIEW_PLACE",
                column: "review_id");

            migrationBuilder.CreateIndex(
                name: "IX_TICKET_state",
                table: "TICKET",
                column: "state");

            migrationBuilder.CreateIndex(
                name: "IX_TICKET_user_id",
                table: "TICKET",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_USER_role_id",
                table: "USER",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_USER_state_id",
                table: "USER",
                column: "state_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTIVITY_PLACE");

            migrationBuilder.DropTable(
                name: "AUDIT");

            migrationBuilder.DropTable(
                name: "PICTURE_PLACE");

            migrationBuilder.DropTable(
                name: "REVIEW_PLACE");

            migrationBuilder.DropTable(
                name: "TICKET");

            migrationBuilder.DropTable(
                name: "ACTIVITY");

            migrationBuilder.DropTable(
                name: "PICTURE");

            migrationBuilder.DropTable(
                name: "PLACE");

            migrationBuilder.DropTable(
                name: "REVIEW");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropTable(
                name: "STATE");
        }
    }
}
