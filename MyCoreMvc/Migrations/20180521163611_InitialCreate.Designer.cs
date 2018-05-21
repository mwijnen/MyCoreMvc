﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyCoreMvc.Models;
using System;

namespace MyCoreMvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180521163611_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("MyCoreMvc.Models.Comment", b =>
                {
                    b.Property<string>("VersionId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(450);

                    b.Property<string>("Contents");

                    b.Property<DateTime>("DateTimeStamp");

                    b.Property<DateTime>("Deleted");

                    b.Property<string>("Id")
                        .HasMaxLength(450);

                    b.Property<string>("PostId")
                        .HasMaxLength(450);

                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.HasKey("VersionId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MyCoreMvc.Models.Post", b =>
                {
                    b.Property<string>("VersionId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(450);

                    b.Property<string>("Abstract");

                    b.Property<string>("Body");

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("DateTimeStamp");

                    b.Property<DateTime>("Deleted");

                    b.Property<string>("Id")
                        .HasMaxLength(450);

                    b.Property<string>("Subtitle");

                    b.Property<string>("Title");

                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.HasKey("VersionId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MyCoreMvc.Models.Comment", b =>
                {
                    b.HasOne("MyCoreMvc.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");
                });
#pragma warning restore 612, 618
        }
    }
}