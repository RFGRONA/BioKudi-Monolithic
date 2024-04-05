using System;
using System.Collections.Generic;
using BioKudi.dto;
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

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__ACTIVITY__3213E83FE2BA3462");

            entity.ToTable("ACTIVITY");

            entity.Property(e => e.ActivityId)
                .ValueGeneratedNever()
                .HasColumnName("activity_id");
            entity.Property(e => e.Type)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AUDIT__3213E83FBD3C44B2");

            entity.ToTable("AUDIT");

            entity.Property(e => e.AuditId)
                .ValueGeneratedNever()
                .HasColumnName("audit_id");
            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ViewAction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("view_action");

            entity.HasOne(d => d.User).WithMany(p => p.Audits)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AUDIT__USER_id__534D60F1");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.PictureId).HasName("PK__PICTURE__3213E83F4507BFB6");

            entity.ToTable("PICTURE");

            entity.Property(e => e.PictureId)
                .ValueGeneratedNever()
                .HasColumnName("picture_id");
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
            entity.HasKey(e => e.PlaceId).HasName("PK__PLACE__3213E83FF12074EB");

            entity.ToTable("PLACE");

            entity.Property(e => e.PlaceId)
                .ValueGeneratedNever()
                .HasColumnName("place_id");
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

            entity.HasMany(d => d.Activities).WithMany(p => p.Places)
                .UsingEntity<Dictionary<string, object>>(
                    "ActivityPlace",
                    r => r.HasOne<Activity>().WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ACTIVITY___ACTIV__4D94879B"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ACTIVITY___PLACE__4CA06362"),
                    j =>
                    {
                        j.HasKey("PlaceId", "ActivityId").HasName("PK__ACTIVITY__A6C8C7262763DD4A");
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
                        .HasConstraintName("FK__PICTURE_P__PICTU__4BAC3F29"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PICTURE_P__PLACE__4AB81AF0"),
                    j =>
                    {
                        j.HasKey("PlaceId", "PictureId").HasName("PK__PICTURE___C262CDB2C4E953F8");
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
                        .HasConstraintName("FK__REVIEW_PL__REVIE__52593CB8"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__REVIEW_PL__PLACE__5165187F"),
                    j =>
                    {
                        j.HasKey("PlaceId", "ReviewId").HasName("PK__REVIEW_P__8DF86B8EB54423BA");
                        j.ToTable("REVIEW_PLACE");
                        j.IndexerProperty<int>("PlaceId").HasColumnName("place_id");
                        j.IndexerProperty<int>("ReviewId").HasColumnName("review_id");
                    });
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__REVIEW__3213E83F92D1333E");

            entity.ToTable("REVIEW");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedNever()
                .HasColumnName("review_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__REVIEW__USER_id__4F7CD00D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__ROLE__3213E83F4DDD033F");

            entity.ToTable("ROLE");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__TICKET__3213E83FB8A06724");

            entity.ToTable("TICKET");

            entity.Property(e => e.TicketId)
                .ValueGeneratedNever()
                .HasColumnName("ticket_id");
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
                .HasConstraintName("FK__TICKET__USER_id__5070F446");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USER__3213E83F9B564E0C");

            entity.ToTable("USER");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
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

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USER__ROLE_id__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
