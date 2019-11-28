using CourseLibrary.API.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using NewsAgregator.API.Entities;
using System;
using System.Security.Cryptography;

namespace CourseLibrary.API.DbContexts
{
    public class CourseLibraryContext : DbContext
    {
        public CourseLibraryContext(DbContextOptions<CourseLibraryContext> options)
           : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            //Console.WriteLine($"Hashed: {hashed}");
            return hashed;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new Tag()
                {
                    Id = Guid.Parse("a8bb30d3-4e33-41f3-8725-126ba71a8bd6"),
                    Name = "react",
                },
                new Tag()
                {
                    Id = Guid.Parse("bf4d4a26-036d-485d-bfc8-75756463cd5e"),
                    Name = "css",
                },
                new Tag()
                {
                    Id = Guid.Parse("565ccc30-95f5-472d-946e-5f5e5d38267d"),
                    Name = "redux",
                },
                new Tag()
                {
                    Id = Guid.Parse("7b19adf3-b384-4d7b-91bd-680262d3d0f6"),
                    Name = "saga",
                },
                new Tag()
                {
                    Id = Guid.Parse("b5f64544-3540-4a2b-82bb-0cf623b42173"),
                    Name = "javascript",
                },
                new Tag()
                {
                    Id = Guid.Parse("1f76c6e7-2933-435c-bacc-1a8092e75c20"),
                    Name = "other",
                });

            
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = Guid.Parse("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                    FirstName = "Tony",
                    LastName = "Stark",
                    Email = "i.am.iron.man@slash.com",
                    Password =HashPassword("tony"),
                    DateOfBirth = new DateTime(1980, 7, 23),
                    Token = null,
                },
                new User()
                {
                    Id = Guid.Parse("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                    FirstName = "Black",
                    LastName = "Widow",
                    Email = "black.widow@slash.com",
                    Password = HashPassword("black"),
                    DateOfBirth = new DateTime(1982, 7, 23),
                    Token = null,
                }
                );

            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = Guid.Parse("af1113cb-2c29-44af-b760-91dd7e852422"),
                    Title = "Let’s Build a Fast, Slick and Customizable Rich Text Editor With Slate.js and React",
                    Url = "https://medium.com/better-programming/lets-build-a-customizable-rich-text-editor-with-slate-and-react-beefd5d441f2",
                    UserEmail = "i.am.iron.man@slash.com",
                    UserId = Guid.Parse("e9cf0077-6ee7-472f-912d-441d4a0eca17"),
                    AddedDate = new DateTime(2019, 11, 18),
                    EditDate = new DateTime(2019,11,19),
                },
                new Article
                {
                    Id = Guid.Parse("03fbcf0a-7ccb-433e-8b8a-086db3138638"),
                    Title = "Let’s Build a Fast, Slick and Customizable Rich Text Editor With Slate.js and React",
                    Url = "https://medium.com/better-programming/lets-build-a-customizable-rich-text-editor-with-slate-and-react-beefd5d441f2",
                    UserEmail = "black.widow@slash.com",
                    UserId = Guid.Parse("faf31b0e-076f-4cf9-be97-c039d6eb7c6b"),
                    AddedDate = new DateTime(2019, 10, 28),
                    EditDate = new DateTime(2019, 11, 28),
                });

            // seed the database with dummy data
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Berry",
                    LastName = "Griffin Beak Eldritch",
                    DateOfBirth = new DateTime(1650, 7, 23),
                    MainCategory = "Ships"
                },
                new Author()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Nancy",
                    LastName = "Swashbuckler Rye",
                    DateOfBirth = new DateTime(1668, 5, 21),
                    MainCategory = "Rum"
                },
                new Author()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    FirstName = "Eli",
                    LastName = "Ivory Bones Sweet",
                    DateOfBirth = new DateTime(1701, 12, 16),
                    MainCategory = "Singing"
                },
                new Author()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    FirstName = "Arnold",
                    LastName = "The Unseen Stafford",
                    DateOfBirth = new DateTime(1702, 3, 6),
                    MainCategory = "Singing"
                },
                new Author()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    FirstName = "Seabury",
                    LastName = "Toxic Reyson",
                    DateOfBirth = new DateTime(1690, 11, 23),
                    MainCategory = "Maps"
                },
                new Author()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    FirstName = "Rutherford",
                    LastName = "Fearless Cloven",
                    DateOfBirth = new DateTime(1723, 4, 5),
                    MainCategory = "General debauchery"
                },
                new Author()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    FirstName = "Atherton",
                    LastName = "Crow Ridley",
                    DateOfBirth = new DateTime(1721, 10, 11),
                    MainCategory = "Rum"
                }
                );

            modelBuilder.Entity<Course>().HasData(
               new Course
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Title = "Commandeering a Ship Without Getting Caught",
                   Description = "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers."
               },
               new Course
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   AuthorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Title = "Overthrowing Mutiny",
                   Description = "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny."
               },
               new Course
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   AuthorId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   Title = "Avoiding Brawls While Drinking as Much Rum as You Desire",
                   Description = "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk."
               },
               new Course
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   AuthorId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   Title = "Singalong Pirate Hits",
                   Description = "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note."
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
