using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BioKudi.dto;

namespace BioKudi.Models;

public partial class BiokudiDbContext : DbContext
{
    public BiokudiDbContext()
    {
    }

    public BiokudiDbContext(DbContextOptions<BiokudiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //Data base connection string
    //public static string ConnectionString = "Data Source=biokudi-server.database.windows.net,1433;Initial Catalog=biokudi-database;User ID=biokudi-server-admin;Password=8Zc3nq1B$xAUlb4R";
    public static string ConnectionString = "server=localhost; database=BIOKUDI-DB; user id=sysbiokudi; password=BK2a2; TrustServerCertificate=Yes;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.IdActivity).HasName("PK__ACTIVITY__BBF4A24791BDEC3C");

            entity.ToTable("ACTIVITY", tb => tb.HasTrigger("tr_AuditActivity"));

            entity.Property(e => e.IdActivity)
                .HasComment("Unique identifier of the activity (integer).")
                .HasColumnName("id_activity");
            entity.Property(e => e.Type)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Type of activity (character string, maximum 128).")
                .HasColumnName("type");
        });

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.IdAudit).HasName("PK__AUDIT__3213E83F45F049A7");

            entity.ToTable("AUDIT");

            entity.Property(e => e.IdAudit)
                .HasComment("Unique identifier of audit (integer).")
                .HasColumnName("id_audit");
            entity.Property(e => e.Action)
                .HasMaxLength(250)
                .HasComment("Type of action performed (character string, maximun 500).")
                .HasColumnName("action");
            entity.Property(e => e.Date)
                .HasComment("Date the audit was done (date).")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.ViewAction)
                .HasMaxLength(250)
                .HasComment("Table in which some modification was made (character string, maximum 500).")
                .HasColumnName("view_action");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.IdPicture).HasName("PK__PICTURE__E967C4E5B8BC69DF");

            entity.ToTable("PICTURE", tb => tb.HasTrigger("tr_AuditPicture"));

            entity.Property(e => e.IdPicture)
                .HasComment("Unique identifier of the picture (integer).")
                .HasColumnName("id_picture");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Link of the picture (character string, maximum 255).")
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Name of the picture (character string, maximum 128).")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.IdPlace).HasName("PK__PLACE__04D478F42E9BE1F1");

            entity.ToTable("PLACE", tb => tb.HasTrigger("tr_AuditPlace"));

            entity.Property(e => e.IdPlace)
                .HasComment("Unique identifier of the place (integer).")
                .HasColumnName("id_place");
            entity.Property(e => e.Address)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Address of the place (character string, maximum 128).")
                .HasColumnName("address");
            entity.Property(e => e.Description)
                .HasMaxLength(560)
                .IsUnicode(false)
                .HasComment("Description of the place (character string, maximum 560).")
                .HasColumnName("description");
            entity.Property(e => e.Latitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Latitude of the place (character string, maximum 20 digits).")
                .HasColumnName("latitude");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Link related to the place (character string, maximum 255).")
                .HasColumnName("link");
            entity.Property(e => e.Longitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Longitude of the place (character string, maximum 20 digits).")
                .HasColumnName("longitude");
            entity.Property(e => e.NamePlace)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasComment("Name of the place (character string, maximum 80).")
                .HasColumnName("name_place");
            entity.Property(e => e.StateId)
                .HasComment("ID of the state to which the place belongs (integer).")
                .HasColumnName("state_id");

            entity.HasOne(d => d.State).WithMany(p => p.Places)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__PLACE__state_id__5535A963");

            entity.HasMany(d => d.IdActivities).WithMany(p => p.IdPlaces)
                .UsingEntity<Dictionary<string, object>>(
                    "ActivityPlace",
                    r => r.HasOne<Activity>().WithMany()
                        .HasForeignKey("IdActivity")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ACTIVITY___id_ac__114A936A"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("IdPlace")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ACTIVITY___id_pl__10566F31"),
                    j =>
                    {
                        j.HasKey("IdPlace", "IdActivity").HasName("PK_Activity_Place");
                        j.ToTable("ACTIVITY_PLACE");
                        j.IndexerProperty<int>("IdPlace")
                            .HasComment("ID of the place associated with the activity (integer).")
                            .HasColumnName("id_place");
                        j.IndexerProperty<int>("IdActivity")
                            .HasComment("ID of the activity associated with the place (integer).")
                            .HasColumnName("id_activity");
                    });

            entity.HasMany(d => d.IdPictures).WithMany(p => p.IdPlaces)
                .UsingEntity<Dictionary<string, object>>(
                    "PicturePlace",
                    r => r.HasOne<Picture>().WithMany()
                        .HasForeignKey("IdPicture")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PICTURE_P__id_pi__0C85DE4D"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("IdPlace")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PICTURE_P__id_pl__0B91BA14"),
                    j =>
                    {
                        j.HasKey("IdPlace", "IdPicture").HasName("PK_Picture_Place");
                        j.ToTable("PICTURE_PLACE");
                        j.IndexerProperty<int>("IdPlace")
                            .HasComment("ID of the place associated with the picture (integer).")
                            .HasColumnName("id_place");
                        j.IndexerProperty<int>("IdPicture")
                            .HasComment("ID of the picture associated with the place (integer).")
                            .HasColumnName("id_picture");
                    });

            entity.HasMany(d => d.IdReviews).WithMany(p => p.IdPlaces)
                .UsingEntity<Dictionary<string, object>>(
                    "ReviewPlace",
                    r => r.HasOne<Review>().WithMany()
                        .HasForeignKey("IdReview")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__REVIEW_PL__id_re__151B244E"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("IdPlace")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__REVIEW_PL__id_pl__14270015"),
                    j =>
                    {
                        j.HasKey("IdPlace", "IdReview").HasName("PK_Review_Place");
                        j.ToTable("REVIEW_PLACE");
                        j.IndexerProperty<int>("IdPlace")
                            .HasComment("ID of the place associated with the review (integer).")
                            .HasColumnName("id_place");
                        j.IndexerProperty<int>("IdReview")
                            .HasComment("ID of the review associated with the place (integer).")
                            .HasColumnName("id_review");
                    });
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("PK__REVIEW__2F79F8C79EE9DCBF");

            entity.ToTable("REVIEW", tb => tb.HasTrigger("tr_AuditReview"));

            entity.Property(e => e.IdReview)
                .HasComment("Unique identifier of the review (integer).")
                .HasColumnName("id_review");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Comment of the review (character string, maximum 255).")
                .HasColumnName("comment");
            entity.Property(e => e.Rate)
                .HasComment("Rating of the review (float, precision of 2 digits).")
                .HasColumnName("rate");
            entity.Property(e => e.UserId)
                .HasComment("ID of the user who made the review (integer).")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__REVIEW__user_id__5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__ROLE__3D48441DA7587008");

            entity.ToTable("ROLE", tb => tb.HasTrigger("tr_AuditRole"));

            entity.Property(e => e.IdRole)
                .HasComment("Unique identifier of the role (integer).")
                .HasColumnName("id_role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Name of the role (character string, maximum 50).")
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.IdState).HasName("PK__STATE__12FD6C4991F75C26");

            entity.ToTable("STATE", tb => tb.HasTrigger("tr_AudityState"));

            entity.Property(e => e.IdState)
                .HasComment("Unique identifier of the state (integer).")
                .HasColumnName("id_state");
            entity.Property(e => e.NameState)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComment("Name of the state (character string, maximum 30).")
                .HasColumnName("name_state");
            entity.Property(e => e.Table)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Table related to the type of status (character string, maximum 20)")
                .HasColumnName("table");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK__TICKET__48C6F52308C4296A");

            entity.ToTable("TICKET", tb => tb.HasTrigger("tr_AudityTicket"));

            entity.Property(e => e.IdTicket)
                .HasComment("Unique identifier of the ticket (integer).")
                .HasColumnName("id_ticket");
            entity.Property(e => e.Affair)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasComment("Subject of the ticket (character string, maximum 1024).")
                .HasColumnName("affair");
            entity.Property(e => e.State)
                .HasComment("ID of the state in which the ticket is located (integer).")
                .HasColumnName("state");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Type of ticket (character string, maximum 50).")
                .HasColumnName("type");
            entity.Property(e => e.UserId)
                .HasComment("ID of the user associated with the ticket (integer).")
                .HasColumnName("user_id");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.State)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TICKET_STATE");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TICKET__user_id__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__USER__D2D1463726DE95DA");

            entity.ToTable("USER", tb => tb.HasTrigger("tr_AudityUser"));

            entity.Property(e => e.IdUser)
                .HasComment("Unique identifier of the user (integer).")
                .HasColumnName("id_user");
            entity.Property(e => e.Email)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasComment("Email address of the user (character string, maximum 75).")
                .HasColumnName("email");
            entity.Property(e => e.Key)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Key of the user (character string, maximun 255).")
                .HasColumnName("key");
            entity.Property(e => e.NameUser)
                .HasMaxLength(65)
                .IsUnicode(false)
                .HasComment("Name of the user (character string, maximum 65).")
                .HasColumnName("name_user");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Password of the user (character string, maximum 128).")
                .HasColumnName("password");
            entity.Property(e => e.RoleId)
                .HasComment("ID of the user's role (integer).")
                .HasColumnName("role_id");
            entity.Property(e => e.Salt)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("Salt of the user (character string, maximun 255).")
                .HasColumnName("salt");
            entity.Property(e => e.StateId)
                .HasComment("ID of the user's state (integer).")
                .HasColumnName("state_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USER__role_id__5070F446");

            entity.HasOne(d => d.State).WithMany(p => p.Users)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USER__state_id__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<BioKudi.dto.PictureDto> PictureDto { get; set; } = default!;

public DbSet<BioKudi.dto.TicketDto> TicketDto { get; set; } = default!;

public DbSet<BioKudi.dto.StateDto> StateDto { get; set; } = default!;

public DbSet<BioKudi.dto.RoleDto> RoleDto { get; set; } = default!;

public DbSet<BioKudi.dto.ActivityDto> ActivityDto { get; set; } = default!;

public DbSet<BioKudi.dto.AuditDto> AuditDto { get; set; } = default!;

public DbSet<BioKudi.dto.ReviewDto> ReviewDto { get; set; } = default!;

public DbSet<BioKudi.dto.UserDto> UserDto { get; set; } = default!;
}
