using System;
using System.Configuration;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI_order_ticket.Models;

public partial class OrderTicketContext : DbContext
{
    public OrderTicketContext()
    {
    }

    public OrderTicketContext(DbContextOptions<OrderTicketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cast> Casts { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HIEU-MAI\\SQLEXPRESS;Initial Catalog=order_ticket;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False").UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cast>(entity =>
        {
            entity.HasKey(e => e.CastId).HasName("PK__cast__D4C48F88F65476AC");

            entity.ToTable("cast");

            entity.Property(e => e.CastId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("cast_id");
            entity.Property(e => e.BirthDay)
                .HasColumnType("date")
                .HasColumnName("birth_day");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nationality");
        });

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.HasKey(e => e.IdCinema).HasName("PK__Cinemas__C52FCE0A19539CAA");

            entity.Property(e => e.IdCinema)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("Id_cinema");
            entity.Property(e => e.AddresCinama)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("addres_cinama");
            entity.Property(e => e.ImageCinema)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("image_cinema");
            entity.Property(e => e.NameCinema)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_cinema");
            entity.Property(e => e.PhoneCinema)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone_cinema");

            entity.HasMany(d => d.Movies).WithMany(p => p.IdCinemas)
                .UsingEntity<Dictionary<string, object>>(
                    "Show",
                    r => r.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__shows__movie_id__5629CD9C"),
                    l => l.HasOne<Cinema>().WithMany()
                        .HasForeignKey("IdCinema")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__shows__Id_cinema__5535A963"),
                    j =>
                    {
                        j.HasKey("IdCinema", "MovieId").HasName("PK__shows__4D13117ED7FEBE53");
                        j.ToTable("shows");
                        j.IndexerProperty<string>("IdCinema")
                            .HasMaxLength(36)
                            .IsUnicode(false)
                            .HasColumnName("Id_cinema");
                        j.IndexerProperty<string>("MovieId")
                            .HasMaxLength(36)
                            .IsUnicode(false)
                            .HasColumnName("movie_id");
                    });
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__genres__18428D42ED8B7045");

            entity.ToTable("genres");

            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnName("genre_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__invoices__F58DFD49F2B37B36");

            entity.ToTable("invoices");

            entity.Property(e => e.InvoiceId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("invoice_id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("date")
                .HasColumnName("create_at");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("payment_status");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__movies__83CDF74938A0F1A1");

            entity.ToTable("movies");

            entity.Property(e => e.MovieId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("movie_id");
            entity.Property(e => e.AgeRating).HasColumnName("age_rating");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Director)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Language)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("language");
            entity.Property(e => e.Poster)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("poster");
            entity.Property(e => e.ReleasedDate)
                .HasColumnType("date")
                .HasColumnName("released_date");
            entity.Property(e => e.Title)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasMany(d => d.Casts).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCast",
                    r => r.HasOne<Cast>().WithMany()
                        .HasForeignKey("CastId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__movie_cas__cast___52593CB8"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__movie_cas__movie__5165187F"),
                    j =>
                    {
                        j.HasKey("MovieId", "CastId").HasName("PK__movie_ca__1E81BFB1FDC2C530");
                        j.ToTable("movie_cast");
                        j.IndexerProperty<string>("MovieId")
                            .HasMaxLength(36)
                            .IsUnicode(false)
                            .HasColumnName("movie_id");
                        j.IndexerProperty<string>("CastId")
                            .HasMaxLength(36)
                            .IsUnicode(false)
                            .HasColumnName("cast_id");
                    });
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__rooms__19675A8AC4736394");

            entity.ToTable("rooms");

            entity.Property(e => e.RoomId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("room_id");
            entity.Property(e => e.AvailableSeats).HasColumnName("available_seats");
            entity.Property(e => e.IdCinema)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("Id_cinema");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NumberSeats).HasColumnName("number_seats");


        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__schedule__C46A8A6F9FCB31E2");

            entity.ToTable("schedules");

            entity.Property(e => e.ScheduleId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("schedule_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("date")
                .HasColumnName("end_time");
            entity.Property(e => e.MovieId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("movie_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ShowTime)
                .HasColumnType("date")
                .HasColumnName("show_time");

            //entity.HasOne(d => d.Movie).WithMany(p => p.Schedules)
            //    .HasForeignKey(d => d.MovieId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__schedules__movie__49C3F6B7");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__seats__906DED9C66C12166");

            entity.ToTable("seats");

            entity.Property(e => e.SeatId)
                .ValueGeneratedNever()
                .HasColumnName("seat_id");
            entity.Property(e => e.RoomId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("room_id");
            entity.Property(e => e.RowNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("row_number");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TypeSeat)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type_seat");

        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__tickets__D596F96BB7CE88FF");

            entity.ToTable("tickets");

            entity.Property(e => e.TicketId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("ticket_id");
            entity.Property(e => e.InvoiceId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("invoice_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PurchaseAt)
                .HasColumnType("date")
                .HasColumnName("purchase_at");
            entity.Property(e => e.ScheduleId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("schedule_id");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");

        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370F3EB0B2AF");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.BirthDay)
                .HasColumnType("date")
                .HasColumnName("birth_day");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
