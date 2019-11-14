﻿// <auto-generated />
using System;
using CourseLibrary.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace NewsAgregator.API.Migrations
{
    [DbContext(typeof(CourseLibraryContext))]
    partial class CourseLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseLibrary.API.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MainCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            FirstName = "Berry",
                            LastName = "Griffin Beak Eldritch",
                            MainCategory = "Ships"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1668, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            FirstName = "Nancy",
                            LastName = "Swashbuckler Rye",
                            MainCategory = "Rum"
                        },
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1701, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Eli",
                            LastName = "Ivory Bones Sweet",
                            MainCategory = "Singing"
                        },
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1702, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Arnold",
                            LastName = "The Unseen Stafford",
                            MainCategory = "Singing"
                        },
                        new
                        {
                            Id = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Seabury",
                            LastName = "Toxic Reyson",
                            MainCategory = "Maps"
                        },
                        new
                        {
                            Id = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1723, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            FirstName = "Rutherford",
                            LastName = "Fearless Cloven",
                            MainCategory = "General debauchery"
                        },
                        new
                        {
                            Id = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1721, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            FirstName = "Atherton",
                            LastName = "Crow Ridley",
                            MainCategory = "Rum"
                        });
                });

            modelBuilder.Entity("CourseLibrary.API.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            AuthorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers.",
                            Title = "Commandeering a Ship Without Getting Caught"
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                            AuthorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.",
                            Title = "Overthrowing Mutiny"
                        },
                        new
                        {
                            Id = new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                            AuthorId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk.",
                            Title = "Avoiding Brawls While Drinking as Much Rum as You Desire"
                        },
                        new
                        {
                            Id = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            AuthorId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note.",
                            Title = "Singalong Pirate Hits"
                        });
                });

            modelBuilder.Entity("NewsAgregator.API.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af1113cb-2c29-44af-b760-91dd7e852422"),
                            Title = "Let’s Build a Fast, Slick and Customizable Rich Text Editor With Slate.js and React",
                            Url = "https://medium.com/better-programming/lets-build-a-customizable-rich-text-editor-with-slate-and-react-beefd5d441f2",
                            UserEmail = "i.am.iron.man@slash.com",
                            UserId = new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17")
                        },
                        new
                        {
                            Id = new Guid("03fbcf0a-7ccb-433e-8b8a-086db3138638"),
                            Title = "Let’s Build a Fast, Slick and Customizable Rich Text Editor With Slate.js and React",
                            Url = "https://medium.com/better-programming/lets-build-a-customizable-rich-text-editor-with-slate-and-react-beefd5d441f2",
                            UserEmail = "black.widow@slash.com",
                            UserId = new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b")
                        });
                });

            modelBuilder.Entity("NewsAgregator.API.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a8bb30d3-4e33-41f3-8725-126ba71a8bd6"),
                            Name = "react"
                        },
                        new
                        {
                            Id = new Guid("bf4d4a26-036d-485d-bfc8-75756463cd5e"),
                            Name = "css"
                        },
                        new
                        {
                            Id = new Guid("565ccc30-95f5-472d-946e-5f5e5d38267d"),
                            Name = "redux"
                        },
                        new
                        {
                            Id = new Guid("7b19adf3-b384-4d7b-91bd-680262d3d0f6"),
                            Name = "saga"
                        },
                        new
                        {
                            Id = new Guid("b5f64544-3540-4a2b-82bb-0cf623b42173"),
                            Name = "javascript"
                        },
                        new
                        {
                            Id = new Guid("1f76c6e7-2933-435c-bacc-1a8092e75c20"),
                            Name = "other"
                        });
                });

            modelBuilder.Entity("NewsAgregator.API.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1980, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "i.am.iron.man@slash.com",
                            FirstName = "Tony",
                            LastName = "Stark",
                            Password = "LOBiaLjEX2Si8sVF0IQnvSFE0iimPPC6P43MHVlceO0="
                        },
                        new
                        {
                            Id = new Guid("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1982, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Email = "black.widow@slash.com",
                            FirstName = "Black",
                            LastName = "Widow",
                            Password = "/qjIg52/t9c5r4WW10kGSw+frkld5mcovGWI9A3aZJI="
                        });
                });

            modelBuilder.Entity("CourseLibrary.API.Entities.Course", b =>
                {
                    b.HasOne("CourseLibrary.API.Entities.Author", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewsAgregator.API.Entities.Article", b =>
                {
                    b.HasOne("NewsAgregator.API.Entities.User", null)
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
