﻿// <auto-generated />
using System;
using BioKudi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BioKudi.Migrations
{
    [DbContext(typeof(BiokudiDbContext))]
    partial class BiokudiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ActivityPlace", b =>
                {
                    b.Property<int>("PlaceId")
                        .HasColumnType("int")
                        .HasColumnName("place_id")
                        .HasComment("ID of the place associated with the activity (integer).");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int")
                        .HasColumnName("activity_id")
                        .HasComment("ID of the activity associated with the place (integer).");

                    b.HasKey("PlaceId", "ActivityId")
                        .HasName("PK__ACTIVITY__9BA9939C1918C499");

                    b.HasIndex("ActivityId");

                    b.ToTable("ACTIVITY_PLACE", (string)null);
                });

            modelBuilder.Entity("BioKudi.Models.Activity", b =>
                {
                    b.Property<int>("IdActivity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_activity")
                        .HasComment("Unique identifier of the activity (integer).");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdActivity"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("type")
                        .HasComment("Type of activity (character string, maximum 128).");

                    b.HasKey("IdActivity")
                        .HasName("PK__ACTIVITY__BBF4A24791BDEC3C");

                    b.ToTable("ACTIVITY", null, t =>
                        {
                            t.HasTrigger("tr_AuditActivity");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("BioKudi.Models.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("action");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("ViewAction")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("view_action");

                    b.HasKey("Id")
                        .HasName("PK__AUDIT__3213E83F45F049A7");

                    b.ToTable("AUDIT", (string)null);
                });

            modelBuilder.Entity("BioKudi.Models.Picture", b =>
                {
                    b.Property<int>("IdPicture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_picture")
                        .HasComment("Unique identifier of the picture (integer).");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPicture"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("link")
                        .HasComment("Link of the picture (character string, maximum 255).");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("name")
                        .HasComment("Name of the picture (character string, maximum 128).");

                    b.HasKey("IdPicture")
                        .HasName("PK__PICTURE__E967C4E5B8BC69DF");

                    b.ToTable("PICTURE", null, t =>
                        {
                            t.HasTrigger("tr_AuditPicture");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("BioKudi.Models.Place", b =>
                {
                    b.Property<int>("IdPlace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_place")
                        .HasComment("Unique identifier of the place (integer).");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlace"));

                    b.Property<string>("Address")
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("address")
                        .HasComment("Address of the place (character string, maximum 128).");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(560)
                        .IsUnicode(false)
                        .HasColumnType("varchar(560)")
                        .HasColumnName("description")
                        .HasComment("Description of the place (character string, maximum 560).");

                    b.Property<string>("Latitude")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("latitude")
                        .HasComment("Latitude of the place (character string, maximum 20 digits).");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("link")
                        .HasComment("Link related to the place (character string, maximum 255).");

                    b.Property<string>("Longitude")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("longitude")
                        .HasComment("Longitude of the place (character string, maximum 20 digits).");

                    b.Property<string>("NamePlace")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name_place")
                        .HasComment("Name of the place (character string, maximum 80).");

                    b.Property<int?>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("state_id")
                        .HasComment("ID of the state to which the place belongs (integer).");

                    b.HasKey("IdPlace")
                        .HasName("PK__PLACE__04D478F42E9BE1F1");

                    b.HasIndex("StateId");

                    b.ToTable("PLACE", null, t =>
                        {
                            t.HasTrigger("tr_AuditPlace");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("BioKudi.Models.Review", b =>
                {
                    b.Property<int>("IdReview")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_review")
                        .HasComment("Unique identifier of the review (integer).");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReview"));

                    b.Property<string>("Comment")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("comment")
                        .HasComment("Comment of the review (character string, maximum 255).");

                    b.Property<float>("Rate")
                        .HasColumnType("real")
                        .HasColumnName("rate")
                        .HasComment("Rating of the review (float, precision of 2 digits).");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id")
                        .HasComment("ID of the user who made the review (integer).");

                    b.HasKey("IdReview")
                        .HasName("PK__REVIEW__2F79F8C79EE9DCBF");

                    b.HasIndex("UserId");

                    b.ToTable("REVIEW", null, t =>
                        {
                            t.HasTrigger("tr_AuditReview");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("BioKudi.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_role")
                        .HasComment("Unique identifier of the role (integer).");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRole"));

                    b.Property<string>("NameRole")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name_role")
                        .HasComment("Name of the role (character string, maximum 50).");

                    b.HasKey("IdRole")
                        .HasName("PK__ROLE__3D48441DA7587008");

                    b.ToTable("ROLE", null, t =>
                        {
                            t.HasTrigger("tr_AuditRole");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("BioKudi.Models.State", b =>
                {
                    b.Property<int>("IdState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_state")
                        .HasComment("Unique identifier of the state (integer).");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdState"));

                    b.Property<string>("NameState")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name_state")
                        .HasComment("Name of the state (character string, maximum 30).");

                    b.HasKey("IdState")
                        .HasName("PK__STATE__12FD6C4991F75C26");

                    b.ToTable("STATE", null, t =>
                        {
                            t.HasTrigger("tr_AudityState");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("BioKudi.Models.Ticket", b =>
                {
                    b.Property<int>("IdTicket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_ticket")
                        .HasComment("Unique identifier of the ticket (integer).");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTicket"));

                    b.Property<string>("Affair")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("affair")
                        .HasComment("Subject of the ticket (character string, maximum 1024).");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("type")
                        .HasComment("Type of ticket (character string, maximum 50).");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id")
                        .HasComment("ID of the user associated with the ticket (integer).");

                    b.HasKey("IdTicket")
                        .HasName("PK__TICKET__48C6F52308C4296A");

                    b.HasIndex("State");

                    b.HasIndex("UserId");

                    b.ToTable("TICKET", null, t =>
                        {
                            t.HasTrigger("tr_AudityTicket");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("BioKudi.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_user")
                        .HasComment("Unique identifier of the user (integer).");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("email")
                        .HasComment("Email address of the user (character string, maximum 75).");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("key");

                    b.Property<string>("NameUser")
                        .IsRequired()
                        .HasMaxLength(65)
                        .IsUnicode(false)
                        .HasColumnType("varchar(65)")
                        .HasColumnName("name_user")
                        .HasComment("Name of the user (character string, maximum 65).");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password")
                        .HasComment("Password of the user (character string, maximum 128).");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id")
                        .HasComment("ID of the user's role (integer).");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("salt");

                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("state_id")
                        .HasComment("ID of the user's state (integer).");

                    b.HasKey("IdUser")
                        .HasName("PK__USER__D2D1463726DE95DA");

                    b.HasIndex("RoleId");

                    b.HasIndex("StateId");

                    b.ToTable("USER", null, t =>
                        {
                            t.HasTrigger("tr_AudityUser");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("PicturePlace", b =>
                {
                    b.Property<int>("PlaceId")
                        .HasColumnType("int")
                        .HasColumnName("place_id")
                        .HasComment("ID of the place associated with the picture (integer).");

                    b.Property<int>("PictureId")
                        .HasColumnType("int")
                        .HasColumnName("picture_id")
                        .HasComment("ID of the picture associated with the place (integer).");

                    b.HasKey("PlaceId", "PictureId")
                        .HasName("PK__PICTURE___64F9E9DAEA8FA6DB");

                    b.HasIndex("PictureId");

                    b.ToTable("PICTURE_PLACE", (string)null);
                });

            modelBuilder.Entity("ReviewPlace", b =>
                {
                    b.Property<int>("PlaceId")
                        .HasColumnType("int")
                        .HasColumnName("place_id")
                        .HasComment("ID of the place associated with the review (integer).");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int")
                        .HasColumnName("review_id")
                        .HasComment("ID of the review associated with the place (integer).");

                    b.HasKey("PlaceId", "ReviewId")
                        .HasName("PK__REVIEW_P__A923EB93308825A1");

                    b.HasIndex("ReviewId");

                    b.ToTable("REVIEW_PLACE", (string)null);
                });

            modelBuilder.Entity("ActivityPlace", b =>
                {
                    b.HasOne("BioKudi.Models.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .IsRequired()
                        .HasConstraintName("FK__ACTIVITY___activ__4F7CD00D");

                    b.HasOne("BioKudi.Models.Place", null)
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .IsRequired()
                        .HasConstraintName("FK__ACTIVITY___place__4E88ABD4");
                });

            modelBuilder.Entity("BioKudi.Models.Place", b =>
                {
                    b.HasOne("BioKudi.Models.State", "State")
                        .WithMany("Places")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FK__PLACE__state_id__5535A963");

                    b.Navigation("State");
                });

            modelBuilder.Entity("BioKudi.Models.Review", b =>
                {
                    b.HasOne("BioKudi.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__REVIEW__user_id__5165187F");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BioKudi.Models.Ticket", b =>
                {
                    b.HasOne("BioKudi.Models.State", "StateNavigation")
                        .WithMany("Tickets")
                        .HasForeignKey("State")
                        .IsRequired()
                        .HasConstraintName("FK_TICKET_STATE");

                    b.HasOne("BioKudi.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__TICKET__user_id__52593CB8");

                    b.Navigation("StateNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BioKudi.Models.User", b =>
                {
                    b.HasOne("BioKudi.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__USER__role_id__5070F446");

                    b.HasOne("BioKudi.Models.State", "State")
                        .WithMany("Users")
                        .HasForeignKey("StateId")
                        .IsRequired()
                        .HasConstraintName("FK__USER__state_id__5629CD9C");

                    b.Navigation("Role");

                    b.Navigation("State");
                });

            modelBuilder.Entity("PicturePlace", b =>
                {
                    b.HasOne("BioKudi.Models.Picture", null)
                        .WithMany()
                        .HasForeignKey("PictureId")
                        .IsRequired()
                        .HasConstraintName("FK__PICTURE_P__pictu__4D94879B");

                    b.HasOne("BioKudi.Models.Place", null)
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .IsRequired()
                        .HasConstraintName("FK__PICTURE_P__place__4CA06362");
                });

            modelBuilder.Entity("ReviewPlace", b =>
                {
                    b.HasOne("BioKudi.Models.Place", null)
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .IsRequired()
                        .HasConstraintName("FK__REVIEW_PL__place__534D60F1");

                    b.HasOne("BioKudi.Models.Review", null)
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .IsRequired()
                        .HasConstraintName("FK__REVIEW_PL__revie__5441852A");
                });

            modelBuilder.Entity("BioKudi.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BioKudi.Models.State", b =>
                {
                    b.Navigation("Places");

                    b.Navigation("Tickets");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BioKudi.Models.User", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}