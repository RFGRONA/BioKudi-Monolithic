using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.IdActivity).HasName("PK__ACTIVITY__BBF4A24791BDEC3C");

            entity.ToTable("ACTIVITY");

            entity.Property(e => e.IdActivity).HasColumnName("id_activity");
            entity.Property(e => e.Type)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.IdAudit).HasName("PK__AUDIT__5BC2526A0750825F");

            entity.ToTable("AUDIT");

            entity.Property(e => e.IdAudit).HasColumnName("id_audit");
            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ViewAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("view_action");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.IdPicture).HasName("PK__PICTURE__E967C4E5B8BC69DF");

            entity.ToTable("PICTURE");

            entity.Property(e => e.IdPicture).HasColumnName("id_picture");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.IdPlace).HasName("PK__PLACE__04D478F42E9BE1F1");

            entity.ToTable("PLACE");

            entity.Property(e => e.IdPlace).HasColumnName("id_place");
            entity.Property(e => e.Address)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Description)
                .HasMaxLength(560)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.NamePlace)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("name_place");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.State).WithMany(p => p.Places)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__PLACE__state_id__5535A963");

            entity.HasMany(d => d.Activities).WithMany(p => p.Places)
                .UsingEntity<Dictionary<string, object>>(
                    "ActivityPlace",
                    r => r.HasOne<Activity>().WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ACTIVITY___activ__4F7CD00D"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ACTIVITY___place__4E88ABD4"),
                    j =>
                    {
                        j.HasKey("PlaceId", "ActivityId").HasName("PK__ACTIVITY__9BA9939C1918C499");
                        j.ToTable("ACTIVITY_PLACE");
                        j.IndexerProperty<int>("PlaceId").HasColumnName("place_id");
                        j.IndexerProperty<int>("ActivityId").HasColumnName("activity_id");
                    });

            entity.HasMany(d => d.Pictures).WithMany(p => p.Places)
                .UsingEntity<Dictionary<string, object>>(
                    "PicturePlace",
                    r => r.HasOne<Picture>().WithMany()
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PICTURE_P__pictu__4D94879B"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PICTURE_P__place__4CA06362"),
                    j =>
                    {
                        j.HasKey("PlaceId", "PictureId").HasName("PK__PICTURE___64F9E9DAEA8FA6DB");
                        j.ToTable("PICTURE_PLACE");
                        j.IndexerProperty<int>("PlaceId").HasColumnName("place_id");
                        j.IndexerProperty<int>("PictureId").HasColumnName("picture_id");
                    });

            entity.HasMany(d => d.Reviews).WithMany(p => p.Places)
                .UsingEntity<Dictionary<string, object>>(
                    "ReviewPlace",
                    r => r.HasOne<Review>().WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__REVIEW_PL__revie__5441852A"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__REVIEW_PL__place__534D60F1"),
                    j =>
                    {
                        j.HasKey("PlaceId", "ReviewId").HasName("PK__REVIEW_P__A923EB93308825A1");
                        j.ToTable("REVIEW_PLACE");
                        j.IndexerProperty<int>("PlaceId").HasColumnName("place_id");
                        j.IndexerProperty<int>("ReviewId").HasColumnName("review_id");
                    });
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("PK__REVIEW__2F79F8C79EE9DCBF");

            entity.ToTable("REVIEW");

            entity.Property(e => e.IdReview).HasColumnName("id_review");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__REVIEW__user_id__5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__ROLE__3D48441DA7587008");

            entity.ToTable("ROLE");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.IdState).HasName("PK__STATE__12FD6C4991F75C26");

            entity.ToTable("STATE");

            entity.Property(e => e.IdState).HasColumnName("id_state");
            entity.Property(e => e.NameState)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name_state");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK__TICKET__48C6F52308C4296A");

            entity.ToTable("TICKET");

            entity.Property(e => e.IdTicket).HasColumnName("id_ticket");
            entity.Property(e => e.Affair)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("affair");
            entity.Property(e => e.State)
                .HasMaxLength(1)
                .HasColumnName("state");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TICKET__user_id__52593CB8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__USER__D2D1463726DE95DA");

            entity.ToTable("USER");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Email)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.NameUser)
                .HasMaxLength(65)
                .IsUnicode(false)
                .HasColumnName("name_user");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USER__role_id__5070F446");

            entity.HasOne(d => d.State).WithMany(p => p.Users)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__USER__state_id__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
