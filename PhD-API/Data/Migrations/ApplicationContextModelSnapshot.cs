﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.Entities.Research", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRandomPassword")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Researchs");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRandomPassword")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Admin@gmail.com",
                            IsRandomPassword = true,
                            Name = "Admin",
                            PasswordHash = new byte[] { 57, 73, 84, 207, 202, 64, 11, 62, 175, 33, 180, 123, 17, 93, 50, 176, 166, 202, 252, 185, 138, 153, 243, 187, 241, 240, 139, 145, 155, 119, 93, 31, 120, 105, 104, 124, 155, 92, 218, 83, 7, 226, 201, 223, 84, 213, 232, 38, 161, 54, 169, 121, 193, 254, 117, 135, 52, 84, 229, 66, 113, 214, 5, 30 },
                            PasswordSalt = new byte[] { 149, 125, 185, 199, 146, 105, 142, 138, 136, 12, 32, 176, 48, 140, 79, 2, 184, 118, 95, 135, 231, 25, 159, 81, 217, 249, 93, 32, 40, 198, 50, 81, 234, 4, 132, 21, 168, 97, 114, 91, 97, 245, 206, 10, 99, 140, 197, 52, 8, 199, 98, 210, 208, 22, 109, 44, 238, 109, 210, 246, 253, 0, 154, 209, 93, 101, 52, 79, 204, 17, 78, 201, 225, 6, 210, 182, 34, 171, 137, 115, 248, 112, 100, 238, 136, 101, 50, 209, 110, 103, 187, 46, 204, 191, 35, 147, 199, 79, 208, 168, 206, 164, 162, 204, 22, 228, 204, 244, 228, 27, 206, 94, 16, 198, 130, 124, 46, 128, 150, 81, 209, 91, 38, 64, 146, 243, 90, 133 },
                            Role = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
