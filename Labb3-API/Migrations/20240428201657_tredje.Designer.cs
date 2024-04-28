﻿// <auto-generated />
using Labb3_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb3_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240428201657_tredje")]
    partial class tredje
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb3_API.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestId = 1,
                            Description = "Konsten att fånga ögonblick.",
                            Title = "Fotografering"
                        },
                        new
                        {
                            InterestId = 2,
                            Description = "Utmaningen att nå toppen.",
                            Title = "Bergsklättring"
                        });
                });

            modelBuilder.Entity("Labb3_API.Models.Links", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"));

                    b.Property<int>("PersonInterestId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkId");

                    b.HasIndex("PersonInterestId");

                    b.ToTable("Link");

                    b.HasData(
                        new
                        {
                            LinkId = 1,
                            PersonInterestId = 1,
                            Url = "http://example.com/foto"
                        },
                        new
                        {
                            LinkId = 2,
                            PersonInterestId = 2,
                            Url = "http://example.com/bergsbestigning"
                        });
                });

            modelBuilder.Entity("Labb3_API.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Name = "Anna Svensson",
                            PhoneNumber = "0701234567"
                        },
                        new
                        {
                            PersonId = 2,
                            Name = "Johan Karlsson",
                            PhoneNumber = "0722345678"
                        });
                });

            modelBuilder.Entity("Labb3_API.Models.PersonInterest", b =>
                {
                    b.Property<int>("PersonInterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonInterestId"));

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<string>("Links")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("PersonInterestId");

                    b.HasIndex("InterestId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonInterests");

                    b.HasData(
                        new
                        {
                            PersonInterestId = 1,
                            InterestId = 1,
                            Links = "[]",
                            PersonId = 1
                        },
                        new
                        {
                            PersonInterestId = 2,
                            InterestId = 2,
                            Links = "[]",
                            PersonId = 1
                        },
                        new
                        {
                            PersonInterestId = 3,
                            InterestId = 1,
                            Links = "[]",
                            PersonId = 2
                        });
                });

            modelBuilder.Entity("Labb3_API.Models.Links", b =>
                {
                    b.HasOne("Labb3_API.Models.PersonInterest", "PersonInterest")
                        .WithMany()
                        .HasForeignKey("PersonInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInterest");
                });

            modelBuilder.Entity("Labb3_API.Models.PersonInterest", b =>
                {
                    b.HasOne("Labb3_API.Models.Interest", "Interest")
                        .WithMany("PersonInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb3_API.Models.Person", "Person")
                        .WithMany("PersonInterests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Labb3_API.Models.Interest", b =>
                {
                    b.Navigation("PersonInterests");
                });

            modelBuilder.Entity("Labb3_API.Models.Person", b =>
                {
                    b.Navigation("PersonInterests");
                });
#pragma warning restore 612, 618
        }
    }
}
