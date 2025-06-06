﻿// <auto-generated />
using System;
using $safeprojectname$.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace $safeprojectname$.Migrations
{
    [DbContext(typeof($ext_safeprojectname$DbContext))]
    [Migration("20250414112833_InitialCommit")]
    partial class InitialCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("$safeprojectname$.Entities.LogMyAwesomeProduct", b =>
                {
                    b.Property<Guid>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("log_id");

                    b.Property<DateTime>("ChangedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("changed_date");

                    b.Property<int>("ChangedOperation")
                        .HasColumnType("integer")
                        .HasColumnName("changed_operation");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ProductType")
                        .HasColumnType("integer")
                        .HasColumnName("product_type");

                    b.HasKey("LogId");

                    b.HasIndex("Id");

                    b.ToTable("log_my_awesome_products", (string)null);
                });

            modelBuilder.Entity("$safeprojectname$.Entities.MyAwesomeProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ProductType")
                        .HasColumnType("integer")
                        .HasColumnName("product_type");

                    b.HasKey("Id");

                    b.ToTable("my_awesome_products", (string)null);
                });

            modelBuilder.Entity("$safeprojectname$.Entities.LogMyAwesomeProduct", b =>
                {
                    b.HasOne("$safeprojectname$.Entities.MyAwesomeProduct", "Entity")
                        .WithMany("Logs")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("$safeprojectname$.Entities.MyAwesomeProduct", b =>
                {
                    b.Navigation("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
