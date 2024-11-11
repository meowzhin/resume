﻿// <auto-generated />
using System;
using System.Collections.Generic;
using FwksLabs.ResumeService.Core.OwnedTypes;
using FwksLabs.ResumeService.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FwksLabs.Migrations.History
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241110032857_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FwksLabs.ResumeService.Core.Entities.AcademicRecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateIntervalOwnedType>("DateInterval")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ReferenceId")
                        .HasColumnType("uuid");

                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_AcademicRecords");

                    b.HasIndex("ReferenceId")
                        .IsUnique()
                        .HasDatabaseName("IX_UK_AcademicRecords");

                    b.HasIndex("ResumeId");

                    b.ToTable("AcademicRecords", "App");
                });

            modelBuilder.Entity("FwksLabs.ResumeService.Core.Entities.CompetencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Level")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ReferenceId")
                        .HasColumnType("uuid");

                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_Competencies");

                    b.HasIndex("ReferenceId")
                        .IsUnique()
                        .HasDatabaseName("IX_UK_Competencies");

                    b.HasIndex("ResumeId");

                    b.ToTable("Competencies", "App");
                });

            modelBuilder.Entity("FwksLabs.ResumeService.Core.Entities.EmploymentHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateIntervalOwnedType>("DateInterval")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ReferenceId")
                        .HasColumnType("uuid");

                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_EmploymentHistory");

                    b.HasIndex("ReferenceId")
                        .IsUnique()
                        .HasDatabaseName("IX_UK_EmploymentHistory");

                    b.HasIndex("ResumeId");

                    b.ToTable("EmploymentHistory", "App");
                });

            modelBuilder.Entity("FwksLabs.ResumeService.Core.Entities.ResumeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<ContactInformationOwnedType>("ContactInformation")
                        .HasColumnType("jsonb");

                    b.Property<LocationOwnedType>("Location")
                        .HasColumnType("jsonb");

                    b.Property<NameOwnedType>("Name")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<Guid>("ReferenceId")
                        .HasColumnType("uuid");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<ICollection<SocialOwnedType>>("Socials")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_Resumes");

                    b.HasIndex("ReferenceId")
                        .IsUnique()
                        .HasDatabaseName("IX_UK_Resumes");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Resumes", "App");
                });

            modelBuilder.Entity("FwksLabs.ResumeService.Core.Entities.AcademicRecordEntity", b =>
                {
                    b.HasOne("FwksLabs.ResumeService.Core.Entities.ResumeEntity", "Resume")
                        .WithMany("AcademicRecords")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Resumes_ResumeId");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("FwksLabs.ResumeService.Core.Entities.CompetencyEntity", b =>
                {
                    b.HasOne("FwksLabs.ResumeService.Core.Entities.ResumeEntity", "Resume")
                        .WithMany("Competencies")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Resumes_ResumeId");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("FwksLabs.ResumeService.Core.Entities.EmploymentHistoryEntity", b =>
                {
                    b.HasOne("FwksLabs.ResumeService.Core.Entities.ResumeEntity", "Resume")
                        .WithMany("EmploymentHistory")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Resumes_ResumeId");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("FwksLabs.ResumeService.Core.Entities.ResumeEntity", b =>
                {
                    b.Navigation("AcademicRecords");

                    b.Navigation("Competencies");

                    b.Navigation("EmploymentHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
