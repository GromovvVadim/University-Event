﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University_Event.Persistence;

namespace University_Event.Persistence.Migrations
{
    [DbContext(typeof(UEDbContext))]
    partial class UEDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("University_Event.Domain.Admin", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Email = "admin@gmail.com",
                            Password = "admin"
                        });
                });

            modelBuilder.Entity("University_Event.Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("LongTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<string>("ShortTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2020, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LongTitle = "Профспілка студентів орзанізовує шаховий турнір між студентами. Запрошуємо усіх бажаючих.",
                            NumberOfPeople = 24,
                            ShortTitle = "Шаховий турнір."
                        });
                });

            modelBuilder.Entity("University_Event.Domain.EventStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("StudentId");

                    b.ToTable("EventStudents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventId = 1,
                            StudentId = "123456c"
                        },
                        new
                        {
                            Id = 2,
                            EventId = 1,
                            StudentId = "123457c"
                        });
                });

            modelBuilder.Entity("University_Event.Domain.Student", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            ID = "123456c",
                            FirstName = "Вадим",
                            LastName = "Громов",
                            MiddleName = "Глібович",
                            Password = "123456c"
                        },
                        new
                        {
                            ID = "123457c",
                            FirstName = "Данило",
                            LastName = "Тимець",
                            MiddleName = "Ігорович",
                            Password = "123457c"
                        });
                });

            modelBuilder.Entity("University_Event.Domain.EventStudent", b =>
                {
                    b.HasOne("University_Event.Domain.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University_Event.Domain.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}
