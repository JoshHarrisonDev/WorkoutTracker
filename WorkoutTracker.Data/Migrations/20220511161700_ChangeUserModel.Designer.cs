﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkoutTracker.Data;

namespace WorkoutTracker.Data.Migrations
{
    [DbContext(typeof(WorkoutContext))]
    [Migration("20220511161700_ChangeUserModel")]
    partial class ChangeUserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkoutTracker.Data.Models.Exercise", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkoutID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("WorkoutID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("WorkoutTracker.Data.Models.Set", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ExerciseID");

                    b.ToTable("Set");
                });

            modelBuilder.Entity("WorkoutTracker.Data.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WorkoutTracker.Data.Models.Workout", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Workout");
                });

            modelBuilder.Entity("WorkoutTracker.Data.Models.Exercise", b =>
                {
                    b.HasOne("WorkoutTracker.Data.Models.Workout", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutID");
                });

            modelBuilder.Entity("WorkoutTracker.Data.Models.Set", b =>
                {
                    b.HasOne("WorkoutTracker.Data.Models.Exercise", null)
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseID");
                });

            modelBuilder.Entity("WorkoutTracker.Data.Models.Workout", b =>
                {
                    b.HasOne("WorkoutTracker.Data.Models.User", null)
                        .WithMany("Workouts")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("WorkoutTracker.Data.Models.Exercise", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("WorkoutTracker.Data.Models.User", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("WorkoutTracker.Data.Models.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
