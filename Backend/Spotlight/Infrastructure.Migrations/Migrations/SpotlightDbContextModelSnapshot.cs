﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SpotlightDbContext))]
    partial class SpotlightDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("author_id")
                        .HasComment("Id автора");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthday")
                        .HasComment("Дата рождения");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("name")
                        .HasComment("ФИО автора");

                    b.HasKey("AuthorId");

                    b.ToTable("authors", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Composition", b =>
                {
                    b.Property<int>("CompositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("composition_id")
                        .HasComment("Id композиции");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompositionId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("author_id")
                        .HasComment("Id автора");

                    b.Property<string>("HeroesInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("heroes_information")
                        .HasComment("Информация о героях произведения");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("name")
                        .HasComment("Название композиции");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("short_description")
                        .HasComment("Краткое описание");

                    b.HasKey("CompositionId");

                    b.HasIndex("AuthorId");

                    b.ToTable("compositions", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Play", b =>
                {
                    b.Property<int>("PlayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("play_id")
                        .HasComment("Id представления");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayId"));

                    b.Property<int>("CompositionId")
                        .HasColumnType("int")
                        .HasColumnName("composition_id")
                        .HasComment("Id композиции");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description")
                        .HasComment("Описание");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date")
                        .HasComment("Дата завершения");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("name")
                        .HasComment("Название");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date")
                        .HasComment("Дата начала");

                    b.Property<int>("TheaterId")
                        .HasColumnType("int")
                        .HasColumnName("theater_id")
                        .HasComment("Id театра");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ticket_price")
                        .HasComment("Стоимость билета");

                    b.HasKey("PlayId");

                    b.HasIndex("CompositionId");

                    b.HasIndex("TheaterId");

                    b.ToTable("plays", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Theater", b =>
                {
                    b.Property<int>("TheaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("theater_id")
                        .HasComment("Id театра");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TheaterId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("address")
                        .HasComment("Адрес");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description")
                        .HasComment("Описание");

                    b.Property<DateTime>("FirstOpeningDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("first_opening_date")
                        .HasComment("Дата первого открытия");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("name")
                        .HasComment("Название");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number")
                        .HasComment("Номер для связи");

                    b.HasKey("TheaterId");

                    b.ToTable("theaters", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TheaterHours", b =>
                {
                    b.Property<int>("TheaterHoursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("theater_hours_id")
                        .HasComment("Id режима работы");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TheaterHoursId"));

                    b.Property<TimeSpan>("ClosingTime")
                        .HasColumnType("time")
                        .HasColumnName("closing_time")
                        .HasComment("Время закрытия");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int")
                        .HasColumnName("day_of_week")
                        .HasComment("День недели");

                    b.Property<TimeSpan>("OpeningTime")
                        .HasColumnType("time")
                        .HasColumnName("opening_time")
                        .HasComment("Время открытия");

                    b.Property<int>("TheaterId")
                        .HasColumnType("int")
                        .HasColumnName("theater_id")
                        .HasComment("Id театра");

                    b.HasKey("TheaterHoursId");

                    b.HasIndex("TheaterId");

                    b.ToTable("theater_hours", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Composition", b =>
                {
                    b.HasOne("Domain.Entities.Author", "Author")
                        .WithMany("Compositions")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Domain.Entities.Play", b =>
                {
                    b.HasOne("Domain.Entities.Composition", "Composition")
                        .WithMany("Plays")
                        .HasForeignKey("CompositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Theater", "Theater")
                        .WithMany("Plays")
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Composition");

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("Domain.Entities.TheaterHours", b =>
                {
                    b.HasOne("Domain.Entities.Theater", "Theater")
                        .WithMany("TheaterHours")
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Navigation("Compositions");
                });

            modelBuilder.Entity("Domain.Entities.Composition", b =>
                {
                    b.Navigation("Plays");
                });

            modelBuilder.Entity("Domain.Entities.Theater", b =>
                {
                    b.Navigation("Plays");

                    b.Navigation("TheaterHours");
                });
#pragma warning restore 612, 618
        }
    }
}
