﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Note.Infra.Data;

namespace Note.Infra.Data.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20190606152447_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Note.Core.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("FirstName")
                        .HasMaxLength(250);

                    b.Property<string>("LastName")
                        .HasMaxLength(250);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Roles");

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e8b0c60-9419-452e-9fac-0ec52e6f90fe"),
                            CreatedAt = new DateTime(2019, 6, 6, 17, 24, 46, 379, DateTimeKind.Local).AddTicks(975),
                            CreatedBy = "Seed",
                            Email = "admin@note.com",
                            Password = "$2b$10$eTogdRTbhMqLHGO5m4vFxuNybkE8cNURSgvd/Ni1GvhSEMVXH5fJK",
                            Roles = "APP_ADMIN,APP_USER",
                            Salt = "Dat1vPnOX9AZG+9bu57SSg==",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Note.Core.Entities.Page", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("SpaceId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.HasIndex("SpaceId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Note.Core.Entities.Space", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Spaces");
                });

            modelBuilder.Entity("Note.Core.Entities.Page", b =>
                {
                    b.HasOne("Note.Core.Entities.AppUser", "Owner")
                        .WithMany("Pages")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Note.Core.Entities.Space", "Space")
                        .WithMany("Pages")
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Note.Core.Entities.Space", b =>
                {
                    b.HasOne("Note.Core.Entities.AppUser", "Owner")
                        .WithMany("Spaces")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}