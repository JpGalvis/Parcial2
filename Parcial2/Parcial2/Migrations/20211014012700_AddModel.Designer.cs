﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcial2.Data;

namespace Parcial2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211014012700_AddModel")]
    partial class AddModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Parcial2.Models.Suerte", b =>
                {
                    b.Property<string>("futuro")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vision")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("futuro");

                    b.ToTable("Suertes");
                });
#pragma warning restore 612, 618
        }
    }
}
