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

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsRandomPassword = true,
                            Name = "Admin",
                            PasswordHash = new byte[] { 82, 139, 184, 19, 25, 98, 194, 174, 242, 67, 140, 131, 217, 113, 199, 22, 21, 170, 248, 77, 20, 58, 207, 193, 89, 239, 227, 91, 180, 93, 106, 142, 122, 178, 19, 136, 140, 56, 113, 173, 192, 183, 12, 220, 179, 47, 73, 154, 179, 97, 67, 110, 63, 107, 158, 252, 172, 147, 35, 18, 253, 76, 80, 143 },
                            PasswordSalt = new byte[] { 13, 205, 75, 12, 47, 207, 171, 47, 114, 241, 116, 85, 36, 19, 242, 45, 255, 181, 200, 123, 134, 233, 166, 118, 82, 4, 103, 240, 62, 237, 152, 255, 143, 95, 140, 162, 238, 41, 97, 216, 47, 49, 177, 193, 148, 173, 253, 156, 63, 43, 60, 211, 244, 32, 10, 226, 97, 4, 115, 72, 251, 233, 89, 57, 170, 82, 236, 62, 216, 59, 90, 233, 44, 12, 2, 94, 17, 65, 103, 163, 123, 235, 54, 131, 220, 118, 65, 179, 115, 199, 115, 212, 117, 35, 131, 188, 6, 51, 117, 78, 206, 48, 235, 130, 149, 23, 89, 137, 16, 255, 230, 244, 122, 200, 21, 140, 106, 73, 147, 6, 40, 35, 75, 222, 41, 6, 149, 54 },
                            Role = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
