﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using website_backend.DbContexts;

#nullable disable

namespace website_backend.Migrations
{
    [DbContext(typeof(WebsiteContext))]
    [Migration("20220822162938_add-date-created-to-seed")]
    partial class adddatecreatedtoseed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("website_backend.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "this is better than anything I could ever do",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7479),
                            PostId = 1,
                            Title = "Really cool!",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7482)
                        },
                        new
                        {
                            Id = 2,
                            Body = "lorem ipsum is a sample text who cares tho",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7484),
                            PostId = 1,
                            Title = "Lorem ",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7486)
                        },
                        new
                        {
                            Id = 3,
                            Body = "lorem ipsum is a sample text who cares tho",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7488),
                            PostId = 1,
                            Title = "Lorem Log 3",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7489)
                        },
                        new
                        {
                            Id = 4,
                            Body = "this is dev log one",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7490),
                            PostId = 2,
                            Title = "Really cool!",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7492)
                        },
                        new
                        {
                            Id = 5,
                            Body = "this is dev log two",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7493),
                            PostId = 2,
                            Title = "Dev Lorem 2",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7494)
                        },
                        new
                        {
                            Id = 6,
                            Body = "lorem ipsum is a sample text who cares tho",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7496),
                            PostId = 2,
                            Title = "Lorem Log 3",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7497)
                        },
                        new
                        {
                            Id = 7,
                            Body = "So this is how you do it!",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7499),
                            PostId = 3,
                            Title = "Really cool!",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7500)
                        },
                        new
                        {
                            Id = 8,
                            Body = "I could do way better",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7502),
                            PostId = 3,
                            Title = "Kinda sucks",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7503)
                        },
                        new
                        {
                            Id = 9,
                            Body = "lorem ipsum is a sample text who cares tho",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7504),
                            PostId = 3,
                            Title = "Lorem ipsum",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7506)
                        });
                });

            modelBuilder.Entity("website_backend.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "this is dev log one",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7346),
                            Title = "Dev Log 1",
                            Type = "Dev Log",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7372)
                        },
                        new
                        {
                            Id = 2,
                            Body = "this is dev log two",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7374),
                            Title = "Dev Log 2",
                            Type = "Dev Log",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7375)
                        },
                        new
                        {
                            Id = 3,
                            Body = "this is dev log three",
                            CreatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7377),
                            Title = "Dev Log 3",
                            Type = "Dev Log",
                            UpdatedOn = new DateTime(2022, 8, 22, 17, 29, 38, 489, DateTimeKind.Local).AddTicks(7379)
                        });
                });

            modelBuilder.Entity("website_backend.Entities.Comment", b =>
                {
                    b.HasOne("website_backend.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("website_backend.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}