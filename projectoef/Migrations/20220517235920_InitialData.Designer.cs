﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectoef;

#nullable disable

namespace projectoef.Migrations
{
    [DbContext(typeof(TasksContext))]
    [Migration("20220517235920_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("projectoef.models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("1425a7b8-1345-49ad-9755-5095f34f4aaf"),
                            Description = "Activities to do",
                            Name = "Pending Activities",
                            Weight = 20
                        },
                        new
                        {
                            CategoryId = new Guid("1425a7b8-1345-49ad-9755-5095f34f4a02"),
                            Description = "Activities to do",
                            Name = "Personal Activities",
                            Weight = 50
                        });
                });

            modelBuilder.Entity("projectoef.models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PriorityTask")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("1425a7b8-1345-49ad-9755-5095f34f4a10"),
                            CategoryId = new Guid("1425a7b8-1345-49ad-9755-5095f34f4aaf"),
                            CreationDate = new DateTime(2022, 5, 17, 18, 59, 20, 40, DateTimeKind.Local).AddTicks(9390),
                            Description = "Task 1 Desc",
                            PriorityTask = 1,
                            Title = "Task 1"
                        },
                        new
                        {
                            TaskId = new Guid("1425a7b8-1345-49ad-9755-5095f34f4a00"),
                            CategoryId = new Guid("1425a7b8-1345-49ad-9755-5095f34f4a02"),
                            CreationDate = new DateTime(2022, 5, 17, 18, 59, 20, 40, DateTimeKind.Local).AddTicks(9460),
                            Description = "Task 2 Desc",
                            PriorityTask = 0,
                            Title = "Task 2"
                        });
                });

            modelBuilder.Entity("projectoef.models.Task", b =>
                {
                    b.HasOne("projectoef.models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("projectoef.models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
