﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoryApp.Data;

#nullable disable

namespace StoryApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241108093315_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoryApp.Entities.Story", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("_createdAt");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("_createdBy");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("_isDeleted");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("_lastModifiedAt");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("_lastModifiedBy");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stories");

                    b.HasData(
                        new
                        {
                            Id = 10L,
                            Body = "Body Something 1",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            PublishedDate = new DateTime(2024, 11, 8, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6796),
                            Tile = "Title Something 1"
                        },
                        new
                        {
                            Id = 2L,
                            Body = "Body Something 2",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            PublishedDate = new DateTime(2024, 11, 9, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6809),
                            Tile = "Title Something 2"
                        },
                        new
                        {
                            Id = 3L,
                            Body = "Body Something 3",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            PublishedDate = new DateTime(2024, 11, 10, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6816),
                            Tile = "Title Something 3"
                        },
                        new
                        {
                            Id = 4L,
                            Body = "Body Something 4",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            PublishedDate = new DateTime(2024, 11, 11, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6818),
                            Tile = "Title Something 4"
                        },
                        new
                        {
                            Id = 5L,
                            Body = "Body Something 5",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            PublishedDate = new DateTime(2024, 11, 13, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6819),
                            Tile = "Title Something 5"
                        });
                });

            modelBuilder.Entity("StoryApp.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("_createdAt");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("_createdBy");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("_isDeleted");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("_lastModifiedAt");

                    b.Property<long?>("LastModifiedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("_lastModifiedBy");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "System",
                            IsDeleted = false,
                            LastName = "",
                            Password = "System",
                            Username = "System",
                            isActive = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
