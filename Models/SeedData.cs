using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BowlsApp.Data;

namespace BowlsApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BowlsAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BowlsAppContext>>()))
            {
                // Look for any movies.
                if (context.Bowl.Any())
                {
                    return;   // DB has been seeded
                }

                context.Bowl.AddRange(
                    new Bowl
                    {
                        Title = "Party Bowl",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Party",
                        Rating = "4.5/5",
                        Price = 8.99M
                    },

                    new Bowl
                    {
                        Title = "Mixing Bowl",
                        ReleaseDate = DateTime.Parse("2022-1-12"),
                        Genre = "Mixing",
                        Rating = "3/5",
                        Price = 10.99M
                    },

                    new Bowl
                    {
                        Title = "ceramic Bowl",
                        ReleaseDate = DateTime.Parse("2020-4-20"),
                        Genre = "Eating",
                        Rating = "3/5",
                        Price = 4.99M
                    },

                    new Bowl
                    {
                        Title = "glass Bowl",
                        ReleaseDate = DateTime.Parse("2018-4-14"),
                        Genre = "Eating",
                        Rating = "4/5",
                        Price = 4.99M
                    },

                    new Bowl
                    {
                        Title = "Bowl-ing ball",
                        ReleaseDate = DateTime.Parse("2015-7-12"),
                        Genre = "NotABowl",
                        Rating = "1",
                        Price = 25.99M
                    },

                    new Bowl
                    {
                        Title = "Large Mixing Bowl",
                        ReleaseDate = DateTime.Parse("2022-1-12"),
                        Genre = "Mixing",
                        Rating = "3.5/5",
                        Price = 15.99M
                    },

                    new Bowl
                    {
                        Title = "Child's Bowl",
                        ReleaseDate = DateTime.Parse("2010-7-10"),
                        Genre = "Eating",
                        Rating = "2.5/5",
                        Price = 2.99M
                    },

                    new Bowl
                    {
                        Title = "Stone Bowl",
                        ReleaseDate = DateTime.Parse("2013-8-14"),
                        Genre = "Eating",
                        Rating = "1/5",
                        Price = 1.99M
                    },

                    new Bowl
                    {
                        Title = "Small Mixing Bowl",
                        ReleaseDate = DateTime.Parse("2022-1-12"),
                        Genre = "Mixing",
                        Rating = "2/5",
                        Price = 1.99M
                    },

                    new Bowl
                    {
                        Title = "The Best Bowl",
                        ReleaseDate = DateTime.Parse("2016-4-23"),
                        Genre = "Party",
                        Rating = "5/5",
                        Price = 99.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
